using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Service.Abstract;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Core.Domains; 
using SRT.Dao;
using SRT.Common;
namespace SRT.Service.Concrete
{
    public class TicketService : ITicketService
    {
        ITicketManager tManager = DaoFactory.GetTicketManager();
        public Core.Domains.Ticket Save(Core.Domains.Ticket entity)
        {
            return tManager.IssueTicket(entity);
        }
        public bool UpdateSolvedTicket(Ticket entity)
        {
            return tManager.UpdateSolvedTicket(entity);
        }
        #region UnImplemented
        public Core.Domains.Ticket SaveOrUpdate(Core.Domains.Ticket entity)
        {
            throw new NotImplementedException();
        }

        public Core.Domains.Ticket FindById(long id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList FindAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
