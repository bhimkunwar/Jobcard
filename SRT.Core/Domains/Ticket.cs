using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.ServiceDomain;
using System.Xml.Serialization;
namespace SRT.Core.Domains
{
    public class Ticket : ServiceResponse
    {
        public virtual int Id { get; set; }
        public virtual string Subject { get; set; }
        public virtual int RaisedBy { get; set; }
        public virtual int RaisedTo { get; set; }
        public virtual bool IsCancelled { get; set; }
        public virtual DateTime RaisedDate { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime SolvedDate { get; set; }
        public virtual string Email { get; set; }
        public virtual String status { get; set; }
        public virtual string Urgency { get; set; }

        [XmlIgnore]
        public virtual User user { get; set; }
    }
}
