namespace Pureminds.Server;

public class ProductService : BaseService<Product>, IProductService
{
    MigrationsDbContext _context;
    IAttachmentService _attachmentService;
    public ProductService(MigrationsDbContext context, IAttachmentService attachmentService) : base(context)
    {
        _context = context;
        _attachmentService = attachmentService;
    }

    public async Task<List<Product>> GetProductsWithAttachments()
    {
        try
        {
            var products = await _context.Set<Product>()
                .Include(e => e.ProductAttachments)
                .ThenInclude(e => e.Attachment).Where(e=>e.IsPrioritized)
                .ToListAsync();

            return products;
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
    public async Task<List<Product>> GetPrioritizedProducts()
    {
        try
        {
            return await _context.Set<Product>().Where(e => e.IsPrioritized).ToListAsync(); 
        }
        catch(Exception exception)
        {
            throw exception;
        }
    }

    public override async Task<Product> Create(Product entity)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            if (entity.ProductAttachments is not null && entity.ProductAttachments.Count() != 0)
            {
                List<Attachment>? attachments = new List<Attachment>();
                foreach (ProductAttachment productAttachment in entity.ProductAttachments)
                {
                    if (productAttachment.Attachment is not null)
                        attachments.Add(productAttachment.Attachment);
                }
                entity.ProductAttachments = null;
                entity = await base.Create(entity);
                attachments = await _attachmentService.CreateBulk(attachments, transaction);
                foreach (Attachment attachment in attachments)
                {
                    await _context.Set<ProductAttachment>().AddAsync(new ProductAttachment
                    {
                        ProductId = entity.Id,
                        AttachmentId = attachment.Id,
                        Attachment = null
                    });
                }
                if (transaction is not null)
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                }
                else
                    await transaction.RollbackAsync();
                return entity;
            }
            else
            {
                entity = await base.Create(entity);
                await transaction.CommitAsync();
                return entity;
            }
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync();
            throw exception;
        }
    }
    public override async Task<Product> Update(Product entity)
    {
        var transaction = _context.Database.BeginTransaction();
        try
        {
            if (entity.ProductAttachments is not null && entity.ProductAttachments.Count() != 0)
            {
                await Task.Run(async () =>
                {
                    entity.ProductAttachments.ForEach(e => e.ProductId = entity.Id);
                    _context.Set<ProductAttachment>().UpdateRange(entity.ProductAttachments);
                });
                entity.ProductAttachments = null;
                entity = await base.Update(entity);
            }
            else
            {
                entity.ProductAttachments = null;
                entity = await base.Update(entity);
            }
            if (transaction is not null)
            {
                await transaction.CommitAsync();
            }
        }
        catch (Exception exception)
        {
            await transaction.RollbackAsync();
            throw exception;
        }
        
        return entity;
    }

    public async Task<Product> GetProductWithAttachments(int id)
    {
        try
        {
            return await _context.Set<Product>().Include(e=>e.ProductAttachments).ThenInclude(e=>e.Attachment).FirstOrDefaultAsync(e => e.Id == id);
        }
        catch(Exception exception)
        {
            throw exception;
        }
    }
}