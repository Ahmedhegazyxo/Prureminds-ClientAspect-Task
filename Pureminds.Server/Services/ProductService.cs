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
                foreach(Attachment attachment in attachments)
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
}