using System.Security.Cryptography.X509Certificates;

namespace Pureminds.Shared;

public class MediaClient : BaseEntity
{
    public string Name { get; set; }    
    public string PhoneNumber { get; set; }    
    public string SecondaryPhoneNumber { get; set; }    
    public string Email { get; set; }
    public string Company { get; set; }
    public string Address { get; set; }
    public string Feedback { get; set; } 
}
