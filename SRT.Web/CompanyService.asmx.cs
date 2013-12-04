using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml.Serialization;
using System.Security.Cryptography;
using System.Web.Services.Protocols;
using SRT.Service.Abstract;
using SRT.Service;
using SRT.Core.Domains;
using SRT.Core.ServiceDomain;
using SRT.Service.Validatior;
namespace SRT.Web
{
    /// <summary>
    /// Summary description for CompanyService
    /// </summary>
    [WebService(Description = "Ticket Webservice", Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class CompanyService : System.Web.Services.WebService
    {
        public CompanyService() { }

        Validator _validator = new Validator();
        public AuthenticationHeader IsAuthincated;
        string authstatus;
        string authStatusCode;

        [WebMethod(Description = "Method to create new company", EnableSession = true)]
        public Company CreateCompany(Company entity)
        {
            Company _company = null;
            Session.Clear();

            ICompanyService _companyService = ServiceFactory.GetCompanyService();
            _company = _companyService.Save(entity);
            return _company;
        }

        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        [WebMethod(Description = "Method to delete company", EnableSession = true)]
        public Company DeleteCompany(Company entity)
        {
            Company _comp = new Company();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _comp.Message = authstatus;
                _comp.Status = authStatusCode;
                return _comp;
            }

            Session.Clear();
            ICompanyService _companyService = ServiceFactory.GetCompanyService();
            if (_companyService.DeleteCompanyById(entity) == true)
            {
                _comp.Message = "Company Deleted successfully";
                _comp.Status = "000";
            }
            return _comp;
        }

        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        [WebMethod(Description = "Method to get Company Info. by Id", EnableSession = true)]
        public Company GetCompanyById(int Id)
        {
            Company _comp = new Company();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _comp.Message = authstatus;
                _comp.Status = authStatusCode;
                return _comp;
            }
            Session.Clear();
            ICompanyService _companyService = ServiceFactory.GetCompanyService();
            return (_companyService.FindById(Id));
        }
    }
}
