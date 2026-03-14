using Discounts.Application.Coupons.Commands.Create;
using Discounts.Application.Coupons.Commands.Delete;
using Discounts.Application.Coupons.Commands.Update;
using Discounts.Application.Coupons.Queries.GetDiscountsList;
using Discounts.Domain.Coupons;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discounts.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DiscountController : ControllerBase
{
    private readonly IMediator _mediator;

    public DiscountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Add")]
    public async Task<int> Post(AddCouponCommand request)
    {
        return await _mediator.Send(request);
    }

    // GET: api/<DicountsController>
    [HttpGet("GetAll")]
    public async Task<IEnumerable<CouponDto>> GetAllAsync()
    {
        return await _mediator.Send(new GetDiscountsListQuery());
    }

    [HttpPut("Update/{id}")]
    public async Task<ActionResult<bool>> UpdateDiscountAsync(int id, UpdateDiscountCommand request)
    {
        if (id != request.Id)
        {
            return BadRequest("Id in body and query must be equal");
        }

        var res = await _mediator.Send(request);
        return res;
    }

    [HttpDelete("Delete")]
    public async Task<bool> DeleteDiscountAsync(DeleteDiscountCommand request)
    {
        return await _mediator.Send(request);
    }
}