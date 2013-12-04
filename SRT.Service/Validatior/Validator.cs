using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.ServiceDomain;

namespace SRT.Service.Validatior
{
    public class Validator
    {
        public bool IsHeaderValid(AuthenticationHeader sHeader, out string status, out string statusCode)
        {
            if (sHeader == null)
            {
                status = "ERROR: Please supply credentials";
                statusCode = "001";
                return false;
            }

            if (String.IsNullOrEmpty(sHeader.LoginId) || String.IsNullOrEmpty(sHeader.LoginPassword))
            {
                status = "ERROR: Please supply credentials";
                statusCode = "001";
                return false;
            }

            bool isValid = true;
            StringBuilder sb = new StringBuilder();
            
            status = "Valid Header Format";
            statusCode = "000";
            return isValid;
        }
    }
}
