using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
using SRT.Dao.Abstract;

namespace SRT.Dao.Abstract
{
    public interface ITicketManager : IBaseDao<Ticket, long>
    {
        
        Ticket IssueTicket(Ticket entity);
        bool UpdateSolvedTicket(Ticket entity);
        bool CancelIssuedTicket(Ticket entity);

    }
}
