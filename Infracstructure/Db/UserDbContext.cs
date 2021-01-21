using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infracstructure.Db
{
    public class UserDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
