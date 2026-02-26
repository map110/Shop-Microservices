using Products.Domain;
using Products.Domain.Products;
using Products.Infrastructure.Products;

namespace Products.Infrastructure;

public class ReadUnitOfWork : IReadUnitOfWork
{
    private readonly ProductDbContext _dbContext;

    public ReadUnitOfWork(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    private ProductReadRepository productReadRepository;

    public IProductReadRepository ProductReadRepository
    {
        get { return productReadRepository ?? new ProductReadRepository(_dbContext); }
    }
}