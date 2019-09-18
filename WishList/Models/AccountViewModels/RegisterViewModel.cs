using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WishList.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        [MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [MaxLength(100)]
        [Compare("Password",ErrorMessage ="Password do not match")]
        [DataType(DataType.Password)]
        public string  ConfirmPaasword { get; set; }
    }
}
