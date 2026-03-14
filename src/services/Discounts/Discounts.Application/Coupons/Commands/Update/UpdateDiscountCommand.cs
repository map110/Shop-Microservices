using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Commands.Update;

public class UpdateDiscountCommand : CouponDto, IRequest<bool>
{
}