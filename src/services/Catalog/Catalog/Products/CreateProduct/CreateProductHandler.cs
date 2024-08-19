using BuildingBlocks.CQRS;
using Catalog.Models;
using MediatR;

namespace Catalog.Products.CreateProduct
{
    public record CreateProductCommand(string name, List<string> Category, string Description, string ImageFile, decimal Price): ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class CreateProductHandler: ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = command.Name,
                CategoryAttribute = command.Category,
                DescriptionAttribute = command.Description,
                ImageFileMachine = command.ImageFile,
                Price = command.Price

            };

            return new CreateProductResult(Guid.NewGuid());

        }
    }
}
