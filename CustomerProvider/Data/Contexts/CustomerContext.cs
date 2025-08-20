using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class CustomerContext(DbContextOptions<CustomerContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; }
}
