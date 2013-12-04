using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Protocols;
namespace SRT.Core.ServiceDomain
{
    public class AuthenticationHeader : SoapHeader
    {
        public string LoginId { get; set; }
        public string LoginPassword { get; set; }
    }
}
