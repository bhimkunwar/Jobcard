using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRT.Core.ServiceDomain
{
    public class ServiceResponse
    {
        public virtual string Status { get; set; }
        public virtual string Message { get; set; }
    }
}
