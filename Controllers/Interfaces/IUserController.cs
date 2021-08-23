using beerOfThings.Models;
using Microsoft.AspNetCore.Mvc;


namespace beerOfThings.Controllers.Interfaces
{
    public interface IUserController
    {
        public IActionResult SignUp();
        public IActionResult SignUp([Bind("Nickname,Password,Password2")] AuthenticateModel model);
        public IActionResult SignIn();
        public IActionResult SignIn([Bind("Nickname,Password")] AuthenticateModel model);
    }
}
