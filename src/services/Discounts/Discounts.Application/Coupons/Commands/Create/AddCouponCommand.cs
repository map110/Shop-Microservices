using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Commands.Create;

public class AddCouponCommand : CouponDto, IRequest<int>
{
}