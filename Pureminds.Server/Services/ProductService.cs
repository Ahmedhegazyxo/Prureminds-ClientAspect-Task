namespace Pureminds.Server;

public class ProductService : BaseService<Product>, IProductService
{
    MigrationsDbContext _context;
    public ProductService(MigrationsDbContext context) : base(context)
    {
        _context = context;
    }

    public Task<List<Product>> GetProductsWithAttachments()
    {
        try
        {
            return _context.Set<Product>().Include(e => e.ProductAttachments).ToListAsync();
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    public override async Task<Product> Create(Product entity)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            if (entity.ProductAttachments is not null && entity.ProductAttachments.Count() > 0)
            {

                List<ProductAttachment> productAttachments = entity.ProductAttachments;
                foreach (ProductAttachment attachment in productAttachments)
                {
                    await _context.Set<ProductAttachment>().AddAsync(attachment);
                }
            }
            if (transaction is not null)
                await transaction.CommitAsync();
            else
                await transaction.RollbackAsync();
            entity.ProductAttachments = null;
            return await base.Create(entity);
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync();
            throw exception;
        }
    }
}