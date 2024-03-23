namespace Catalog.API.Products.DeleteProduct;

public record DeleteProductCommand(Guid Id): ICommand<DeleteProductResult>;

public record DeleteProductResult(bool IsSuccess);

public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
{    
    public DeleteProductCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Product Id is required");
    }
}

internal class DeleteProductCommandHandler(IDocumentSession documentSession, ILogger<DeleteProductCommandHandler> logger)
    : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("DeleteProductCommandHanlder called with the command {@command}", command);

        var product = await documentSession.LoadAsync<Product>(command.Id);

        if (product == null)         
        {
            throw new ProductNotFoundException(command.Id);
        }

        documentSession.Delete<Product>(command.Id);
        await documentSession.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
