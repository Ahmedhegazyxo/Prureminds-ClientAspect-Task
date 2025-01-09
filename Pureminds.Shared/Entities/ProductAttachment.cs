namespace Pureminds.Shared;

public class ProductAttachment : BaseEntity
{
    public string AttachmentAttribute { get; set; }
    public string FileName { get; set; }
    public string FileType { get; set; }
    public byte[]? Content { get; set; }
    public int ProductId { get; set; }
}
