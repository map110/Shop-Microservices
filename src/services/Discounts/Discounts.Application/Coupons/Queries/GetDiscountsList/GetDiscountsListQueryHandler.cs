using AutoMapper;
using Discounts.Domain.Coupons;
using MediatR;

namespace Discounts.Application.Coupons.Queries.GetDiscountsList;

public class GetDiscountsListQueryHandler : IRequestHandler<GetDiscountsListQuery, List<CouponDto>>
{
    private readonly ICouponRepository _couponRepository;
    private readonly IMapper _mapper;

    public GetDiscountsListQueryHandler(ICouponRepository couponRepository, IMapper mapper)
    {
        _couponRepository = couponRepository;
        _mapper = mapper;
    }

    public async Task<List<CouponDto>> Handle(GetDiscountsListQuery request, CancellationToken cancellationToken)
    {
        var coupon = _mapper.Map<Coupon>(request);
        var result = await _couponRepository.GetAllAsync();
        return _mapper.Map<List<CouponDto>>(result);
    }
}