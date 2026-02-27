using MediatR;

namespace Products.Application.Products.Commands.Delete;

public class DeleteProductCommand:IRequest<bool>
{
    public int Id  { get; set; }
}