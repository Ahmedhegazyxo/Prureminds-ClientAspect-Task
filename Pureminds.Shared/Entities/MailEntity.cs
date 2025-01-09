using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pureminds.Shared;

public class MailEntity
{
    public string SenderName { get; set; }
    public string RecipentEmail { get; set; }
    public string RecipentName { get; set; }
    public string MailSubject { get; set; }
    public string MailBody { get; set; }
}
