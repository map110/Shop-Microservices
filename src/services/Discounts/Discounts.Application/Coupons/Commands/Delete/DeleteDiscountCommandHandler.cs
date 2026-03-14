using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Commands.Delete;

public class DeleteDiscountCommandHandler : IRequestHandler<DeleteDiscountCommand, bool>
{
    private readonly ICouponRepository _couponRepository;


    public DeleteDiscountCommandHandler(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public async Task<bool> Handle(DeleteDiscountCommand request, CancellationToken cancellationToken)
    {
        var findProduct = await _couponRepository.GetAsync(request.Id);
        if (findProduct == null)
        {
            throw new KeyNotFoundException($"product with {request.Id} not found.");
        }

        _couponRepository.Delete(findProduct);
        await _couponRepository.CommitAsync();
        return true;
    }
}