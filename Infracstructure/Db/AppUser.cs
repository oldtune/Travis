using Microsoft.AspNetCore.Identity;
using Sharedkernel.Entities;

namespace Infracstructure.Db
{
    public class AppUser: IdentityUser<string>, IEntity
    {

    }
}
