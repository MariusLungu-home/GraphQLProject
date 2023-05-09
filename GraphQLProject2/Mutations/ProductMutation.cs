using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace GraphQLProject.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct",
                            arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),
                            resolve: context =>
                            {
                                return productService.AddProduct(context.GetArgument<Product>("product"));
                            });

            Field<ProductType>("updateProduct",
                            arguments:  new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                                        new QueryArgument<ProductInputType> { Name = "product" }),
                            resolve: context =>
                            {
                                var productId = context.GetArgument<int>("id");
                                var productObj = context.GetArgument<Product>("product");

                                return productService.UpdateProduct(productId, productObj);
                            });

            Field<StringGraphType>("deleteProduct",
                            arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                            resolve: context =>
                            {
                                productService.DeleteProduct(context.GetArgument<int>("id"));
                                return "The product record is deleted successfully.";
                            });

        }
    }
}
