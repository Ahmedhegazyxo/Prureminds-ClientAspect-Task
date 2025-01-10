using System.ComponentModel.DataAnnotations;

namespace Pureminds.Shared;

public class Product : BaseEntity
{
    [Required(ErrorMessage = "Product title is required.")]
    [StringLength(100, ErrorMessage = "Product Title cannot exceed 30 characters.")]
    public string ProductTitle { get; set; }

    [Required(ErrorMessage = "Product title is required.")]
    public string Description { get; set; }
    public bool IsPrioritized { get; set; }
    public List<ProductAttachment>? ProductAttachments { get; set; }

}
