using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TrackerClient.Models
{
    public class TrackerClientContext : IdentityDbContext<ApplicationUser>
    {
        public TrackerClientContext(DbContextOptions options) : base(options) { }
    }
}
