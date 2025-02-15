using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restino.Identity.Models;

namespace Restino.Identity
{
    public class RestinoIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public RestinoIdentityDbContext()
        {
            
        }

        public RestinoIdentityDbContext(DbContextOptions<RestinoIdentityDbContext> options) : base(options)
        {
            
        }
    }
}
