using AutoMapper;
using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Commands.Create;

public class AddCouponCommandHandler : IRequestHandler<AddCouponCommand, int>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public AddCouponCommandHandler(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddCouponCommand request, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<Coupon>(request);
        var result = await _couponRepository.AddAsync(coupon);
        await _couponRepository.CommitAsync();
        return result.Entity.Id;
    }
}