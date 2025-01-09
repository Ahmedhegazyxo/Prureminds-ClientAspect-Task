namespace Pureminds.Shared;

public  class ProjectRequest : BaseEntity
{
    public string ClientName { get; set; }
    public string ClientEmail { get; set; }
    public string ClientPhoneNumber { get; set; }
    public string ClientCompany { get; set; }
    public DateTime? SuggestedStartDate { get; set; }
    public decimal BudgetStartLimit { get; set; } 
    public decimal BudgetEndLimit { get; set; } 
    public string ProjectBrief { get; set; }
    public Attachment? ProjectRequestAttachment { get; set; }
    public int? AttachmentId { get; set;}  
}
