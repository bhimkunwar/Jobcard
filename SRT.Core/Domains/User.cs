using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Common;
using System.ComponentModel.DataAnnotations;
using SRT.Core.ServiceDomain;
using System.Xml.Serialization;
namespace SRT.Core.Domains
{
    public class User : ServiceResponse
    {
        public virtual int Id { get; set; }
        public virtual string UserName { get; set; }
        public virtual string OldPassword { get; set; }
        public virtual string NewPassword { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual String Name { get; set; }
        public virtual string Designation { get; set; }
        public virtual string UserType { get; set; }        

        [XmlIgnore]
        public virtual IList<Ticket> ticket { get; set; }
        [XmlIgnore]
        public virtual Company company { get; set; }
    }
}
