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
using SRT.Core.ServiceDomain;
using SRT.Service.Validatior;
namespace SRT.Web
{
    /// <summary>
    /// Summary description for TicketService
    /// </summary>
    /// 

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class TicketService : System.Web.Services.WebService
    {
        Validator _validator = new Validator();
        string authstatus;
        string authStatusCode;

        public AuthenticationHeader IsAuthincated;

        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        [WebMethod(Description = "Method to raise ticket", EnableSession = true)]
        public Ticket RaiseTicket(Ticket entity)
        {
            Ticket _ticket = new Ticket();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _ticket.Message = authstatus;
                _ticket.Status = authStatusCode;
                return _ticket;
            }

            Session.Clear();
            ITicketService _ticketService = ServiceFactory.GetTicketService();
            Ticket ticket = new Ticket();
            ticket = _ticketService.Save(entity);
            return ticket;
        }

        [SoapHeader("IsAuthincated", Direction = SoapHeaderDirection.In)]
        [WebMethod(Description = "Method to Update statusos solved ticket", EnableSession = true)]
        public Ticket UpdateSatus(Ticket entity)
        {
            Ticket _ticket = new Ticket();
            if (!_validator.IsHeaderValid(IsAuthincated, out authstatus, out authStatusCode))
            {
                _ticket.Message = authstatus;
                _ticket.Status = authStatusCode;
                return _ticket;
            }
            Session.Clear();
            ITicketService _ticketService = ServiceFactory.GetTicketService();
            Ticket ticket = new Ticket();
            if (_ticketService.UpdateSolvedTicket(entity) == true)
            {
                ticket.Message = "Status updated successfully";
                ticket.status = "000";
            }
            return ticket;
        }
    }
}
