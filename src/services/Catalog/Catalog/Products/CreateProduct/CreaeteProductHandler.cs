using MediatR;

namespace Catalog.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> Category, string Description, string ImageFile, decimal Price): IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreaeteProductHandler: IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        Task<CreateProductResult> IRequestHandler<CreateProductCommand, CreateProductResult>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
