using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurents.Domain.Entities;

namespace Restaurents.Infrastructure.Persistance;

public class RestaurentDbContext : IdentityDbContext<User>
{
    public RestaurentDbContext(DbContextOptions<RestaurentDbContext> options) : base(options)
    {

    }
    public DbSet<Restaurent> Restaurents { get; set; }
    public DbSet<Dish> Dishes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Restaurent>(e => e.OwnsOne(r => r.Address));

        modelBuilder.Entity<Restaurent>(e => e.HasMany(r => r.Dishes).WithOne().HasForeignKey(d => d.RestaurentId));

        modelBuilder.Entity<User>(e => e.HasMany(o => o.Restaurents).WithOne(r => r.Owner).HasForeignKey(u => u.OwnerId));
    }

}
