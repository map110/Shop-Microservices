using AutoMapper;
using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Commands.Update;

public class UpdateDiscountCommandHandler : IRequestHandler<UpdateDiscountCommand, bool>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;


    public UpdateDiscountCommandHandler(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<bool> Handle(UpdateDiscountCommand request, CancellationToken cancellationToken)
    {
        var updateProduct = _mapper.Map<Coupon>(request);
        _couponRepository.Update(updateProduct);
        await _couponRepository.CommitAsync();
        return true;
    }
}