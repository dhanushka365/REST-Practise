using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace REST_Practise.Data
{
    public class ERPAuthContext:IdentityDbContext
    {
        public ERPAuthContext(DbContextOptions<ERPAuthContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var readerRoleId = Guid.NewGuid().ToString();
            var writerRoleId = Guid.NewGuid().ToString();
            var roles = new List<IdentityRole>
            { //create two identity roles
                new IdentityRole
                {
                    Id=readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp=writerRoleId,
                    Name="Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
