using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using MediatR;
using Products.Api.GQL.Types.Products;
using Products.Application.Products.Commands.Create;

namespace Products.Api.GQL.Mutations;

public static class ProductsMutations
{
    public static void ProductMutations(this ObjectGraphType schema, IMediator mediator)
    {
        schema.FieldAsync<ProductResType>(
            name: "addProduct",
            description: "Is used to add a new product to the database",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ProductReqType>>
                { Name = "productInput", Description = "Product input parameter" }),
            resolve: async context =>
            {
                var addProduct = context.GetArgument<AddProductCommand>("productInput");
                return await mediator.Send(addProduct);
            }
        );
    }
}