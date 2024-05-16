using Microsoft.EntityFrameworkCore;
using Web.Core;

namespace Web.Persistence;

public class WebDbContext(DbContextOptions<WebDbContext> opciones) : DbContext(opciones)
{
    public DbSet<User>? Users { get;}
}