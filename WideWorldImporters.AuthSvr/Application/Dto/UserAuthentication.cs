using System.ComponentModel.DataAnnotations;

namespace WideWorldImporters.AuthSvr.Application.Dto
{
    public class UserAuthentication
    {
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
