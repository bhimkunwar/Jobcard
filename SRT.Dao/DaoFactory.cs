using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
namespace SRT.Dao
{
    public static class DaoFactory
    {
        public static ICompanyManager GetCompanyManager()
        {
            return new CompanyManager();
        }

        public static IUserManager GetUserManager()
        {
            return new UserManager();
        }

        public static ITicketManager GetTicketManager()
        {
            return new TicketManager();
        }
    }
}
