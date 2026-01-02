using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Contact>().HasData(
                new Contact { Id = 1, Name = "Mateus Lecchi", Email = "mateuslecchi@gmail.com" },
                new Contact { Id = 2, Name = "Mateus Reisen", Email = "mateusreisen@gmail.com" },
                new Contact { Id = 3, Name = "Helio Fabio", Email = "heliofabio@gmail.com" });
        }
    }
}
