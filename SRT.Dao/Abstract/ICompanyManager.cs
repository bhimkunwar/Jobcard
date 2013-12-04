using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
namespace SRT.Dao.Abstract
{
    public interface ICompanyManager : IBaseDao<Company, long>
    {
        Company SaveCompany(Company entity);
        IList<Company> FindAllCompanies();
        Company FindCompanyById(long companyId);
        bool IfVendorExists(Company entity);
        bool DeleteCompanyById(Company entity);
    }
}
