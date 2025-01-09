namespace Pureminds.Server;

public interface IProductService : IBaseService<Product>
{
    Task<List<Product>> GetProductsWithAttachments();
}
