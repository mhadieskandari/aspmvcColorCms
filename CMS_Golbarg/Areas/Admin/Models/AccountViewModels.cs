using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CMS_Golbarg.Areas.Admin.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "کد")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "در این مرورگر به خاطر بسپار")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        //[Required]
        //[Display(Name = "ایمیل")]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required(ErrorMessage ="شماره موبایل باید وارد شود")]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage ="رمز عبور باید وارد شود")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Display(Name = "به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "نام کاربری (ایمیل)")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "شماره موبایل باید وارد شود")]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز عبور باید وارد شود")]
        [StringLength(100, ErrorMessage = "باید حداقل {2} کااراکتر باشد /n{0}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن همخوانی ندارد")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "ایمیل")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "شماره موبایل باید وارد شود")]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز عبور باید وارد شود")]
        [StringLength(100, ErrorMessage = "باید حداقل {2} کااراکتر باشد /n{0}", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تکرار رمز عبور")]
        [Compare("Password", ErrorMessage = "رمز عبور و تکرار آن همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        //[Required]
        //[EmailAddress]
        //[Display(Name = "ایمیل")]
        //public string Email { get; set; }

        [Required(ErrorMessage = "شماره موبایل باید وارد شود")]
        [EmailAddress]
        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }
    }
}
