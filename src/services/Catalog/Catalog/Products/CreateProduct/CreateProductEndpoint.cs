namespace Catalog.Products.CreateProduct
{
    public record CreateProductRequest(string name, List<string> Category, string Description, string ImageFile, decimal Price)

    public record CreateProductResponse(Guid Id);

    public class CreateProductEndpoint
    {

    }
}
