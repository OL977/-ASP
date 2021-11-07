using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.ViewModels.Register
{
    public class LoginViewModel
    {

        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"\w",ErrorMessage = "Допускаются только алфавитно-цифровые знаки!")]
        public string Password { get; set; }


        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
