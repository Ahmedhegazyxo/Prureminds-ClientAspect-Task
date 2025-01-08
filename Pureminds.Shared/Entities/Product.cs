namespace Pureminds.Shared;

public class Product : BaseEntity
{
    public string ProductTitle { get; set; }
    public string Description { get; set; }
    public bool IsPrioritized { get; set; }
}
