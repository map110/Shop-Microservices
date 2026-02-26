using Microsoft.EntityFrameworkCore;
using Products.Domain.Products;

namespace Products.Infrastructure.Products;

public class ProductReadRepository:IProductReadRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductReadRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products.Include(p=>p.Category).ToListAsync();
    }

    public Task<Tuple<List<Product>, int>> GetByFilterPagedAsync(ProductDtos.ProductFilterPageReqDto request)
    {
        throw new NotImplementedException();
    }

    public async Task<Product> GetAsync(int id)
    {
        return await _dbContext.Products.FirstOrDefaultAsync(a => a.Id == id);
    }

    public Task<Product> GetAsyncNoTracking(int id)
    {
        throw new NotImplementedException();
    }
}