using GraphQL;
using GraphQL.Types;
using MediatR;
using Products.Api.GQL.Types;
using Products.Api.GQL.Types.Products;
using Products.Application.Products.Queries.GetProductsList;

namespace Products.Api.GQL.Queries;

public static class ProductsQueries
{
    public static void ProductQueries(this ObjectGraphType schema, IMediator mediator)
    {
        schema.Field<ListGraphType<ProductResType>>(
            name: "getProducts",
            description: "return list of products",
            resolve: context => mediator.Send(request: new GetProductsListQuery())
        );
        schema.FieldAsync<PaginataionResType.PaginationResType<ListGraphType<ProductResType>>>(
            "getProductsByFilter",
            description: "return list of filtered prdoucts",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductFilterType>> { Name = "filter" }),


            resolve: async context =>
            {
                var filterParams = context.GetArgument<GetProductsListQuery>("filter");
                var res = await mediator.Send(filterParams);

                return res;
            });
    }
}