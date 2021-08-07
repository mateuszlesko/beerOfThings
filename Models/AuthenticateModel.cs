using System.ComponentModel.DataAnnotations;
namespace beerOfThings.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Nickname { get; set; }
        [Required]
        public string Password { get; set; }
        public string Password2 { get; set; }
    }
}
