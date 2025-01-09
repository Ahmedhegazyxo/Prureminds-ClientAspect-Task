using System.ComponentModel.DataAnnotations;

namespace Pureminds.Shared;

public  class ProjectRequest : BaseEntity
{
    [Required(ErrorMessage = "Client Name is required.")]
    [StringLength(100, ErrorMessage = "Client Name cannot exceed 100 characters.")]
    public string ClientName { get; set; }

    [Required(ErrorMessage = "Client Email is required.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string ClientEmail { get; set; }

    [Required(ErrorMessage = "Client Phone Number is required.")]
    [Phone(ErrorMessage = "Please enter a valid phone number.")]
    public string ClientPhoneNumber { get; set; }

    [Required(ErrorMessage = "Client Company is required.")]
    [StringLength(100, ErrorMessage = "Client Company cannot exceed 100 characters.")]
    public string ClientCompany { get; set; }

    [Required(ErrorMessage = "Suggested Start Date is required.")]
    [DataType(DataType.Date, ErrorMessage = "Please provide a valid date.")]
    public DateTime? SuggestedStartDate { get; set; }

    [Required(ErrorMessage = "Budget Start Limit is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Budget Start Limit must be a positive number.")]
    public decimal BudgetStartLimit { get; set; }

    [Required(ErrorMessage = "Budget End Limit is required.")]
    [Range(0, double.MaxValue, ErrorMessage = "Budget End Limit must be a positive number.")]
    public decimal BudgetEndLimit { get; set; }

    [Required(ErrorMessage = "Project Brief is required.")]
    [StringLength(1000, ErrorMessage = "Project Brief cannot exceed 1000 characters.")]
    public string ProjectBrief { get; set; }

    public Attachment? ProjectRequestAttachment { get; set; }
    public int? AttachmentId { get; set; }
}
