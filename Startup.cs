using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using beerOfThings.Controllers;
using beerOfThings.Controllers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using beerOfThings.AuthorizationRequirments;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace beerOfThings
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           

            services.AddDbContext<beerOfThings.Models.BeerOfThingsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
           
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", config =>
             {
                 config.Cookie.Name = "IdentityAuth";
                 config.LoginPath = "/User/SignIn";
                 config.AccessDeniedPath = "/User/AccessDenied";
             });

            services.AddAuthorization(options =>
             {
                 options.AddPolicy("Claim.Role", policyBuilder =>
                 {
                     policyBuilder.AddRequirements(new OwnRequireClaim(ClaimTypes.Role));
                 });
                 options.AddPolicy("Admin", policyBuilder =>
                  {
                      policyBuilder.RequireClaim(ClaimTypes.Role, "Admin");
                  });
               
             });

            services.AddSession(options => {
                options.IdleTimeout = System.TimeSpan.FromHours(8);// usatwione na tyle ile trwa dzien roboczy   
            });

            //singleton = objects are the same for every obejct and every request
            //scoped = objects are the same with a request but diffrent across different requests
            //transient = new objects are created with every request

            _ = services.AddScoped<IAuthorizationHandler, OwnRequireClaimHandler>();
            _ = services.AddScoped<ICategoriesController, CategoriesController>();
            _ = services.AddScoped<IIngredientsController, IngredientsController>();
            _ = services.AddTransient<IRecipeController, RecipeController>();
            _ = services.AddTransient<IStageController, StageController>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            var cookiePolicyOptions = new CookiePolicyOptions()
            {
                MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
                HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always,
                Secure = Microsoft.AspNetCore.Http.CookieSecurePolicy.None
            };

            app.UseCookiePolicy(cookiePolicyOptions);
            
            app.UseSession();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
