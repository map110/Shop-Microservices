using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Discounts.Domain.Coupons;

public interface ICouponRepository
{
    Task<EntityEntry<Coupon>> AddAsync(Coupon coupon);
    void Update(Coupon coupon);
    Task<Coupon> GetAsync(int couponId);
    Task<IEnumerable<Coupon>> GetAllAsync();
    Task CommitAsync();
    void Delete(Coupon coupon);
}