
namespace Pureminds.Shared;

public class Employee : BaseEntity
{
    public string Name { get; set; }
    public string JobDescription { get; set; }
    public Attachment? ProfileAttachment { get; set; }
    public int? ProfileAttachmentId { get;set; }

}
