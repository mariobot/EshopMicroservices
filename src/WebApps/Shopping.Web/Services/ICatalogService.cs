namespace Shopping.Web.Services;

public interface ICatalogService
{
    [Get("/catalog-service/products?pageNumber={pageNumber}&pageSize={pageSize}")]
    Task<GetProductResponse> GetProducts(int? pageNumber = 1, int? pageSize = 10);

    [Get("/catalog-service/products/{id}")]
    Task<GetProductByIdResponse> GetProduct(Guid id);

    [Get("/catalog-service/products/category/{category}")]
    Task<GetProductByCategoryResponse> GetProductByCategory(string category);
}
