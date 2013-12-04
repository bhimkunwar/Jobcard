using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
using SRT.Dao;
using SRT.Dao.Abstract;
namespace SRT.Service
{    
    public class CustomerService
    {
        public void Save(Company entity)
        {
            ICompanyManager companyManager = DaoFactory.GetCompanyManager();
            companyManager.SaveCompany(entity);
        }
    }
}
