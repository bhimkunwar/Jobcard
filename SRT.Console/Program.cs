using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
using SRT.Dao;
using SRT.Dao.Mappers;
using System.Collections;
using NHibernate.Mapping;
namespace SRT.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                IList<Ticket> _ticket = new List<Ticket>();
                using (var session = NhibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        var _company = new Company
                        {
                            Id = 1
                        };

                        var ticket = new Ticket
                        {
                            Description = "test support",
                            Subject = "test",
                            RaisedDate = DateTime.Now,
                            SolvedDate = DateTime.Now
                        };

                        session.SaveOrUpdate(ticket);

                        transaction.Commit();
                    }
                }
            }
            catch
            {
            }
        }
    }
}
