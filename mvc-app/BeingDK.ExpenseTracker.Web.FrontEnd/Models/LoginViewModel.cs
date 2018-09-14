using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BeingDK.ExpenseTracker.Web.FrontEnd.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        internal bool TryAuthenticate(out User user)
        {
            using (var dbContext = new AppDataContext())
            {
                user = dbContext.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
            }

            return user != null;
        }
    }
}