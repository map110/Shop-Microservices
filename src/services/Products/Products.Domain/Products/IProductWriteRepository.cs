namespace Products.Domain.Products;

public interface IProductWriteRepository
{
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(Product product);
}