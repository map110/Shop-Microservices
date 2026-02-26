using System.Reflection;
using Products.Application.Products.Commands.Create;
using Products.Domain.Products;
using Products.Infrastructure;

namespace Products.Api;

public static class Assemblies
{
   public static readonly Assembly EntityAssembly = typeof(Product).Assembly;
   public static readonly Assembly ApplicationAssembly = typeof(AddProductCommand).Assembly;
   public static readonly Assembly InfrastructureAssembly = typeof(ProductDbContext).Assembly;
}