using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayersDLL.BL
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false)]
   
        public string Email { get; set; }
        [Required(ErrorMessage = "Password must contain \n" +
            "at least 6 chartchers and maximum of 20\n" +
            "must contains one lowercase characters\n" +
            "must contains one uppercase characters\n" +
            "")]
        [DataType(DataType.Password)]
        [RegularExpression(pattern: @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,20})", ErrorMessage = "Password must contain at least 5 letters and 1 digit and password must start with uppercase")]
        public string Password { get; set; }
        [Compare("Password")]
        [Required(ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
        [StringLength(15, MinimumLength = 5, ErrorMessage = "Nickname must contain at least 5 chartchers and maximum of 15")]
        public string Nickname { get; set; }

    }
}
