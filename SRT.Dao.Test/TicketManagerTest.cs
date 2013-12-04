using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRT.Core.Domains;
using SRT.Dao.Abstract;

namespace SRT.Dao.Test
{
    [TestClass]
    public class TicketManagerTest
    {
        [TestMethod]
        public void IssueTicketTest()
        {
            ITicketManager ticketManager = DaoFactory.GetTicketManager();
            Ticket ticket = new Ticket();
            var _user = new User();
            _user.Id = 1;

            ticket.Subject = "test support";
            ticket.Description = "test description";
            ticket.SolvedDate = DateTime.Now;
            ticket.RaisedDate = DateTime.Now;
            ticket.user = _user;
            ticketManager.IssueTicket(ticket);
        }
    }
}
