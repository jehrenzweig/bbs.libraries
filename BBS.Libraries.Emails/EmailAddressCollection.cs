using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BBS.Libraries.Emails
{
  public class EmailAddressCollection : List<EmailAddress>
  {
    public EmailAddressCollection()
    {
      
    }

    public EmailAddressCollection(IEnumerable<string> emailAddresses)
    {
      foreach (var emailAddress in emailAddresses)
      {
        this.Add(new EmailAddress(emailAddress));
      }
    }
  }
}
