using Discounts.Domain.Coupons;
using Microsoft.EntityFrameworkCore;

namespace Discounts.Infrastructure;

public class DiscountDbContext : DbContext
{
    public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
    {
    }

    public DbSet<Coupon> Coupons { get; set; }
}