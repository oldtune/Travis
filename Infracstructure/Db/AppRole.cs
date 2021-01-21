using Microsoft.AspNetCore.Identity;
using Sharedkernel.Entities;

namespace Infracstructure.Db
{
    public class AppRole : IdentityRole<string>, IEntity
    {
    }
}
