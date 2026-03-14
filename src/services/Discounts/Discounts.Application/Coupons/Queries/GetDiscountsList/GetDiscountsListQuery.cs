using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Queries.GetDiscountsList;

public class GetDiscountsListQuery : CouponDto, IRequest<List<CouponDto>>
{
}