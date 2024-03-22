namespace Catalog.API.Products.GetProductById;

// public record GetProductByIdRequest();
public record GetProductByIdResponse(Product Product);

public class GetProductByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{Id}", async (Guid Id, ISender sender) => 
        {
            var request = await sender.Send(new GetProductByIdQuery(Id));

            var result = request.Adapt<GetProductByIdResponse>();

            return Results.Ok(result);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Product by Id")
        .WithDescription("Get Product by Id");
    }
}
