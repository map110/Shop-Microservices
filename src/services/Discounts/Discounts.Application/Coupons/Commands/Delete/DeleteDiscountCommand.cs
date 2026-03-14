using MediatR;

namespace Discounts.Application.Coupons.Commands.Delete;

public class DeleteDiscountCommand : IRequest<bool>
{
    public int Id { get; set; }
}