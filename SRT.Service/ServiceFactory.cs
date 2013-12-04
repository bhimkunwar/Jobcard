using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Service.Abstract;
using SRT.Service.Concrete;
namespace SRT.Service
{
    public static class ServiceFactory
    {
        public static ICompanyService GetCompanyService()
        {
            return new CompanyService();
        }
        public static IUserService GetUserService()
        {
            return new UserService();
        }
        public static ITicketService GetTicketService()
        {
            return new TicketService();
        }
    }
}
