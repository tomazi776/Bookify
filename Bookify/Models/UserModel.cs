using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to provide First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to provide Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "You need to provide Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Display(Name = "Confirm Email")]
        [Compare("EmailAddress", ErrorMessage ="Email Address and Compare Email must match.")]
        public string ConfirmEmail { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to provide password")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage ="You need to provide long enough password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Your password and Compare password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
