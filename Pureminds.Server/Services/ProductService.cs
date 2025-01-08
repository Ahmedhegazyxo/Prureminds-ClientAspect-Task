namespace Pureminds.Server;

public class ProductService : BaseService<Product> , IProductService
{
    public ProductService(MigrationsDbContext context) : base(context)
    {
    }
}
