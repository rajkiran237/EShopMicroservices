
namespace Catalog.API.Products.DeleteProduct;

//public record DeleteProductRequest(Guid Id);//, string Name, List<string> Category, string Description, string ImageFile, decimal Price);

public record DeleteProductResponse(bool IsSuccess);
public class DeleteProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) =>
        {
            //var command = request.Adapt<DeleteProductRequest>();

            var result = await sender.Send(new DeleteProductCommand(id));

            var response = result.Adapt<DeleteProductResponse>();

            return Results.Ok(response);
        })
            .WithName("DeleteProduct")
            .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Delete Products")
            .WithDescription("Delete Products");
    }
}
