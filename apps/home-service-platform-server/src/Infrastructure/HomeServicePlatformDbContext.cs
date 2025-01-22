using HomeServicePlatform.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeServicePlatform.Infrastructure;

public class HomeServicePlatformDbContext : DbContext
{
    public HomeServicePlatformDbContext(DbContextOptions<HomeServicePlatformDbContext> options)
        : base(options) { }

    public DbSet<AdminDbModel> Admins { get; set; }

    public DbSet<ServiceProviderDbModel> ServiceProviders { get; set; }

    public DbSet<ServiceCategoryDbModel> ServiceCategories { get; set; }

    public DbSet<BookingDbModel> Bookings { get; set; }

    public DbSet<ReviewDbModel> Reviews { get; set; }

    public DbSet<UserDbModel> Users { get; set; }
}
