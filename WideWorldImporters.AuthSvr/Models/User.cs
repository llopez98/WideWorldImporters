using Microsoft.AspNetCore.Identity;

namespace WideWorldImporters.AuthSvr.Models
{
    public class User : IdentityUser
    {
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpriryTime { get; set; }
    }
}
