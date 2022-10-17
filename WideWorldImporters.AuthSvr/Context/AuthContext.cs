using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WideWorldImporters.AuthSvr.Models;

namespace WideWorldImporters.AuthSvr.Context
{
    public class AuthContext : IdentityDbContext<User>
    {
        public AuthContext(DbContextOptions options) : base(options) { }
    }
}
