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

namespace beerOfThings.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly BeerOfThingsContext _context;
        
        public UserController(BeerOfThingsContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp([FromBody] AuthenticateModel model) {

            if (_context.Profiles.Any(profile => profile.Nick.Equals(model.Nickname)))
            {
                ViewBag.ErrorMessage = "Nickname zajęty";
                return RedirectToAction("SignUp");
            }

            if (!model.Password.Equals(model.Password2))
            {
                ViewBag.ErrorMessage = "Hasła nie pasują do siebie";
                return RedirectToAction("SignUp");
            }

            HashedPassword hashed = HashingHelper.hashPassword(model.Password);

            Password password = new Password()
            {
                HashedPassword = hashed.Hashed,
                Salt = hashed.Salt
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

            _context.SaveChanges();

            UserSession userSession = new UserSession()
            {
                Id = profile.Id,
                Role = profile.Occupation,
                Nickname = profile.Nick
            };

            SessionHelper.SetObjectAsJson(HttpContext.Session, "userAuthSession", userSession);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name ,profile.Id.ToString()),
                new Claim(ClaimTypes.Role,"User")
            };

            return RedirectToAction("Index","Home");
        }

        public IActionResult SignIn([FromBody] AuthenticateModel model)
        {
            Profile user = _context.Profiles.Include(profile => profile.Password).Where(user => user.Nick == model.Nickname).FirstOrDefault();
           

            return RedirectToAction("Index", "Home");
        }

        private void CreateAuthSession(Profile profile, AuthenticateModel model) 
        {
            bool isMatch = HashingHelper.Match(model.Password, profile.Password.HashedPassword, profile.Password.Salt);
            if (isMatch)
            {
                UserSession userSession = new UserSession()
                {
                    Id = profile.Id,
                    Role = profile.Occupation
                };

                SessionHelper.SetObjectAsJson(HttpContext.Session, "userAuthSession", userSession);
            }
        }
    }
}
