namespace Pureminds.Shared;

public class BaseEntity 
{
    public int Id { get; set; }
    public string? Notes {  get; set; } 
    public string? CreatorIPAddress { get; set; }   
    public bool IsArchieved { get; set; }
}
