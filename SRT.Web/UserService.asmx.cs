using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SRT.Service.Abstract;
using SRT.Service;
using SRT.Core.Domains;
using SRT.Core.ServiceDomain;
using System.Web.Services.Protocols;
using SRT.Service.Validatior;
namespace SRT.Web
{
    /// <summary>
    /// Summary description for UserService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class UserService : System.Web.Services.WebService
    {
        Validator _validator = new Validator();
        string authstatus;
        string authStatusCode;

        public AuthenticationHeader IsAuthincated;

        [WebMethod(Description = "Method to create new user", EnableSession = true)]
        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        public User CreateUser(User entity)
        {
            Session.Clear();

            SRT.Core.Domains.User _user = new User();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _user.Message = authstatus;
                _user.Status = authStatusCode;
                return _user;
            }
            IUserService _userService = ServiceFactory.GetUserService();
            if (_userService.IsUserCreated(entity) == true)
            {
                _user.Message = "User Created Successfully";
                _user.Status = "000";
            }

            return _user;
        }

        [WebMethod(Description = "Method to Get user info.", EnableSession = true)]
        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        public User GetUserInfoByUserName(User entity)
        {
            SRT.Core.Domains.User _user = new User();
            Session.Clear();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _user.Message = authstatus;
                _user.Status = authStatusCode;
                return _user;
            }

            IUserService _userService = ServiceFactory.GetUserService();
            return _userService.GetUSerinfoByUsername(entity);
        }

        [WebMethod(Description = "Method to change password", EnableSession = true)]
        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        public User IsPasswordChanged(User entity)
        {
            SRT.Core.Domains.User _user = new User();
            Session.Clear();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _user.Message = authstatus;
                _user.Status = authStatusCode;
                return _user;
            }
            IUserService _userService = ServiceFactory.GetUserService();

            if (_userService.IsPasswordValid(entity) == true)
            {
                _user.Message = "Password Changed Successfully ";
                _user.Status = "000";
            }
            return _user;
        }
    }
}
