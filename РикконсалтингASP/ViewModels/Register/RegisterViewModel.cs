using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace РикконсалтингASP.ViewModels.Register
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Не указан электронный адрес")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Не указан индивидуальный код")]
        //[StringLength(16, MinimumLength = 16, ErrorMessage = "Длина строки должна быть 16 символов")]
        //[Display(Name = "Индивидуальный код")]
        //public string Code { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }




    }
}
