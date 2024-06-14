﻿using MinRep.Server.Models.Categories;
using MinRep.Server.Models.Products;
using MinRep.Server.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MinRep.Server.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options)
    : IdentityDbContext<User, Role, int>(options), IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        ConfigureIdentityTables(builder);
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        try
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        catch (DbUpdateConcurrencyException exception)
        {
            throw new ConflictException(nameof(AppStrings.UpdateConcurrencyException), exception);
        }
    }

    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken())
    {
        try
        {
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        catch (DbUpdateConcurrencyException exception)
        {
            throw new ConflictException(nameof(AppStrings.UpdateConcurrencyException), exception);
        }
    }


    private void ConfigureIdentityTables(ModelBuilder builder)
    {
        builder.Entity<User>().ToTable("Users", "identity");
        builder.Entity<Role>().ToTable("Roles", "identity");
        builder.Entity<IdentityUserRole<int>>().ToTable("UserRoles", "identity");
        builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaims", "identity");
        builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins", "identity");
        builder.Entity<IdentityUserToken<int>>().ToTable("UserTokens", "identity");
        builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims", "identity");
    }
}
