using Products.Domain.Products;

namespace Products.Domain;

public interface IReadUnitOfWork
{
    IProductReadRepository ProductReadRepository { get; }
}