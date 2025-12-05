using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class AppDbContext(DbContextOptions options):DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
}
