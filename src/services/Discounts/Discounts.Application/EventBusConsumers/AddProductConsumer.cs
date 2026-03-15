using Discounts.Application.Coupons.Commands.Create;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore.Internal;

namespace Discounts.Application.EventBusConsumers;

public class AddProductConsumer:IConsumer<AddProductEvent>
{
    private readonly IMediator _mediator;

    public AddProductConsumer(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Consume(ConsumeContext<AddProductEvent> context)
    {
        var addCouponCommand = new AddCouponCommand
        {
            ProductId = context.Message.ProductId,
            ProductTitle = context.Message.ProductTitle
        };
        await _mediator.Send(addCouponCommand);
    }
}