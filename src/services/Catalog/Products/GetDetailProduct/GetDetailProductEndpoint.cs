namespace Catalog.Products.GetDetailProduct
{
    //public record GetDetailProductRequest();
    public record GetDetailProductResponse(Product Product);
    public class GetDetailProductEndpoint
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new GetDetailProductQuery(id));

                var response = result.Adapt<GetDetailProductResponse>();

                return Results.Ok(response);
            })
            .WithName("GetDetailProdct")
            .Produces<GetDetailProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Detail Product")
            .WithDescription("Get Detail Product");
        }
    }
}
