using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Products.Domain.Products;

namespace Products.Infrastructure.Products;

public class ProductReadRepository : IProductReadRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductReadRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        return await _dbContext.Products.Include(p => p.Category).ToListAsync();
    }

    public async Task<Tuple<List<Product>, int>> GetByFilterPagedAsync(ProductDtos.ProductFilterPageReqDto request)
    {
        var filteredProducts = _dbContext.Products.AsQueryable();
        if (request.Id != 0)
        {
            filteredProducts = filteredProducts.Where(p => p.Id == request.Id);
        }

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {
            request.SearchTerm = request.SearchTerm.Trim().ToLower();
            filteredProducts = filteredProducts.Where(p => p.Title.ToLower().Contains(request.SearchTerm)
                                                           || p.Description.ToLower().Contains(request.SearchTerm)
                                                           || p.Code.ToLower().Contains(request.SearchTerm));
        }

        if (request.MinPrice != null)
        {
            filteredProducts = filteredProducts.Where(p => p.Price >= request.MinPrice);
        }

        if (request.MaxPrice != null)
        {
            filteredProducts = filteredProducts.Where(p => p.Price <= request.MaxPrice);
        }

        if (request.CategoryId != 0)
        {
            filteredProducts = filteredProducts.Where(p => p.CategoryId == request.CategoryId);
        }

        var filteredProductsCount = filteredProducts.Count();
        filteredProducts = filteredProducts.Skip(request.PageIndex * request.PageSize).Take(request.PageSize);
        return Tuple.Create(await filteredProducts.ToListAsync(), filteredProductsCount);
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