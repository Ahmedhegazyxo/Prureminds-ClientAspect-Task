namespace Pureminds.Shared;

public class ProductAttachment : BaseEntity
{
    public int AttachmentId { get; set; }
    public int ProductId { get; set; }
    public Attachment? Attachment { get; set; }
}
