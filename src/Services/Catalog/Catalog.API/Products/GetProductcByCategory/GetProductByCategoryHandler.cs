﻿
namespace Catalog.API.Products.GetProductcByCategory;

public record GetProductByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);

public class GetProductByCategoryQueryHandler(IDocumentSession documentSession)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await documentSession.Query<Product>()
                            .Where(p => p.Category.Contains(query.Category))
                            .ToListAsync();

        return new GetProductByCategoryResult(products);
    }
}
