

namespace Catalog.Products.GetDetailProduct
{
    public record GetDetailProductQuery(Guid Id) : IQuery<GetDetailProductResult>;

    public record GetDetailProductResult(Product Product);

    internal class GetDetailProductQueryHandler(IDocumentSession session, ILogger<GetDetailProductQueryHandler> logger) : IQueryHandler<GetDetailProductQuery, GetDetailProductResult>
    {
        public async Task<GetDetailProductResult> Handle(GetDetailProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetDetailProductQueryHandler.Handle called with {@Query}", query);

            var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

            if (product is null)
            {
                throw new ProductNotFoundException();
            }

            return new GetDetailProductResult(product);
        }
    }
}
