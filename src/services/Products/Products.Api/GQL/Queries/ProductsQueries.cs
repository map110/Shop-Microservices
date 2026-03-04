using GraphQL.Types;
using MediatR;
using Products.Api.GQL.Types.Products;
using Products.Application.Products.Queries.GetProductList;

namespace Products.Api.GQL.Queries;

public static class ProductsQueries
{
    public static void ProductQueries(this ObjectGraphType schema, IMediator mediator)
    {
        schema.Field<ListGraphType<ProductResType>>(
            name: "getProducts",
            description: "return list of products",
            resolve: context => mediator.Send(request: new GetProductListQuery())
        );
    }
}