using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using SRT.Core.ServiceDomain;
namespace SRT.Core.Domains
{
    public class Company : ServiceResponse
    {
        public virtual int Id { get; set; }
        public virtual string CompanyName { get; set; }

        public virtual string Address { get; set; }
        public virtual DateTime JoinedDate { get; set; }
        public virtual DateTime ValidTillDate { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual string ContactPerson { get; set; }
        public virtual string Mobile { get; set; }
        public virtual string FaxNo { get; set; }
        public virtual string Email { get; set; }

        [XmlIgnore]
        public virtual IList<User> user { get; set; }
    }
}
