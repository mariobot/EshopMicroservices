namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShopingCart Cart);

public class GetBasketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{usename}", async (string userNaqme, ISender sender) =>
        {
            var result = await sender.Send(new GetBasketQuery(userNaqme));

            var response = result.Adapt<GetBasketResponse>();

            return Results.Ok(response);
        })
        .WithName("GetBasket")
        .Produces<GetBasketResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Get Basket by UserName")
        .WithDescription("Get Basket by UserName");
    }
}
