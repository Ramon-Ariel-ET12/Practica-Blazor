using Microsoft.EntityFrameworkCore;
using Web.Core;

namespace Web.Persistence;

public class WebDbContext(DbContextOptions<WebDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}


// dotnet ef migrations add InitialMigration --context WebDbContext --output-dir Persistence/Migrations --project Web --startup-project Web