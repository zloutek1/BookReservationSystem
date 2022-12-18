using BookReservationSystem.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BookReservationSystem.DAL.Data;

public class BookReservationSystemDbContext: IdentityDbContext<User, IdentityRole<Guid>, Guid>
{
    private readonly bool _shouldSeed; 

    public BookReservationSystemDbContext(DbContextOptions options, bool shouldSeed = true) : base(options)
    {
        _shouldSeed = shouldSeed;
    }

    public DbSet<Address> Address { get; set; } = null!;
    public DbSet<Author> Author { get; set; } = null!;
    public DbSet<Book> Book { get; set; } = null!;
    public DbSet<Genre> Genre { get; set; } = null!;
    public DbSet<Library> Library { get; set; } = null!;
    public DbSet<Publisher> Publisher { get; set; } = null!;
    public DbSet<Reservation> Reservation { get; set; } = null!;
    public DbSet<Review> Review { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        var connectionString = config.GetConnectionString("Default")!;
            
        optionsBuilder
            .UseSqlServer(connectionString)
            .UseLazyLoadingProxies()
            .EnableSensitiveDataLogging();
    }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Restrict;
        }

        modelBuilder.Entity<Book>()
            .HasMany(s => s.Genres)
            .WithMany(c => c.Books)
            .UsingEntity(j => j.ToTable("BookGenres"));

        modelBuilder.Entity<Author>()
           .HasMany(s => s.Books)
           .WithMany(c => c.Authors)
           .UsingEntity(j => j.ToTable("AuthorBooks"));

        modelBuilder.Entity<Publisher>()
            .HasMany(s => s.Books)
            .WithMany(c => c.Publishers)
            .UsingEntity(j => j.ToTable("AuthorPublishers"));

        modelBuilder.Entity<BookQuantity>()
            .HasKey(x => new { x.BookId, x.LibraryId });

        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Role>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserToken");
        
        if (_shouldSeed)
        {
            modelBuilder.Seed();
        }

        base.OnModelCreating(modelBuilder);
    }
}