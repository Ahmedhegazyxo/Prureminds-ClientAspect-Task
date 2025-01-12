namespace Pureminds.Server;

public interface IProductService : IBaseService<Product>
{
    Task<List<Product>> GetProductsWithAttachments();
    Task<Product> GetProductWithAttachments(int id);
    Task<List<Product>> GetPrioritizedProducts();
}
