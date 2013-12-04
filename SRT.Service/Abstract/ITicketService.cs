using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;

namespace SRT.Service.Abstract
{
    public interface ITicketService : IBaseService<Ticket, long>
    {
        bool UpdateSolvedTicket(Ticket entity);
    }
}
