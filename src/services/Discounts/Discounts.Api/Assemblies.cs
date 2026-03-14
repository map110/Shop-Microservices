using System.Reflection;
using Discounts.Application.Coupons.Commands.Create;
using Discounts.Domain.Coupons;
using Discounts.Infrastructure;

namespace Discounts.Api;

public static class Assemblies
{
    public static readonly Assembly EntityAssembly = typeof(Coupon).Assembly;
    public static readonly Assembly ApplicationAssembly = typeof(AddCouponCommand).Assembly;
    public static readonly Assembly InfrastructureAssembly = typeof(DiscountDbContext).Assembly;
}