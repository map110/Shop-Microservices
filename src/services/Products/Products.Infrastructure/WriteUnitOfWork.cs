using Products.Domain;
using Products.Domain.Products;
using Products.Infrastructure.Products;

namespace Products.Infrastructure;

public class WriteUnitOfWork : IWriteUnitOfWork
{
    private readonly ProductDbContext _dbContext;

    public WriteUnitOfWork(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private ProductWriteRepository _productWriteRepository;

    public IProductWriteRepository ProductWriteRepository
    {
        get { return _productWriteRepository ?? new ProductWriteRepository(_dbContext); }
        //public IProductWriteRepository ProductWriteRepository => _productWriteRepository ?? new ProductWriteRepository(_dbContext);
    }
}