using AutoMapper;
using Discounts.Domain.Coupons;

namespace Discounts.Infrastructure.Coupons;

public class CouponMappingProfile:Profile
{
    public CouponMappingProfile()
    {
        CreateMap<Coupon, CouponDto>().ReverseMap();
    }
}