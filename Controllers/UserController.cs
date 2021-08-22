using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using beerOfThings.ViewModels;
using beerOfThings.Models;
using beerOfThings.Helpers;
using beerOfThings.Entities;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace beerOfThings.Controllers
{
    
    public class UserController : Controller
    {
        private readonly BeerOfThingsContext _context;
        
        public UserController(BeerOfThingsContext context) 
        {
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([Bind("Nickname,Password,Password2")] AuthenticateModel model) {

            if (await _context.Profiles.AnyAsync(profile => profile.Nick.Equals(model.Nickname)))
            {
                ViewBag.ErrorMessage = "Nickname zajęty";
                return RedirectToAction("SignUp");
            }

            if (!model.Password.Equals(model.Password2))
            {
                ViewBag.ErrorMessage = "Hasła nie pasują do siebie";
                return RedirectToAction("SignUp");
            }

            string salt = HashingHelper.GenerateSalt();
            string hashed =  HashingHelper.HashPassword(model.Password,salt);

            Password password = new Password()
            {
                HashedPassword = hashed,
                Salt = salt
            };
            _context.Add(password);

            Profile profile = new Profile()
            {
                Nick = model.Nickname,
                Password = password,
                PasswordId = password.Id,
                Occupation = "User"
            };

            _context.Add(profile);

            await _context.SaveChangesAsync();

            UserSession userSession = new UserSession()
            {
                Id = profile.Id,
                Role = profile.Occupation,
                Nickname = profile.Nick
            };

            SessionHelper.SetObjectAsJson(HttpContext.Session, "userAuthSession", userSession);

            CreateIdentityClaim(profile);

            return RedirectToAction("Index","Home");
        }

        [Authorize(Policy = "Claim.Role")]
        public string TEST()
        {
            return "Test";
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn([Bind("Nickname,Password")] AuthenticateModel model)
        {
            Profile user = _context.Profiles.Include(profile => profile.Password).Where(user => user.Nick == model.Nickname).FirstOrDefault();

            if (user == null)
            {
                ViewBag.ErrorMessage = "Konto nie istnieje";
                return RedirectToAction("SignIn");
            }


            if (HashingHelper.Match(user.Password.HashedPassword, model.Password, user.Password.Salt))
            {

                UserSession userSession = new UserSession()
                {
                    Id = user.Id,
                    Role = user.Occupation
                };

                CreateIdentityClaim(user);

                SessionHelper.SetObjectAsJson(HttpContext.Session, "userAuthSession", userSession);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.ErrorMessage = "Nie udało się zalogować";
            return RedirectToAction("SignIn");
        }

        public IActionResult LogOut()
        {
            Response.Cookies.Append("IdentityAuth", "", new Microsoft.AspNetCore.Http.CookieOptions() { Expires = System.DateTime.Now.AddHours(-8) });

            return RedirectToAction("Index", "Home");
        }

        private void CreateIdentityClaim(Profile user)
        {
            var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,"Identity"),
                    new Claim(ClaimTypes.Role,user.Occupation),
                    new Claim("UId",user.Id.ToString()),
                };

            var userIdentityClaims = new ClaimsIdentity(claims, "User Identity");
            var userPrincipal = new ClaimsPrincipal(new[] { userIdentityClaims });
            HttpContext.SignInAsync(userPrincipal);
        }
    }
}
