using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Core.Domains;
using SRT.Dao;
using SRT.Service.Abstract;
using System.Collections;

namespace SRT.Service.Concrete
{
    public class CompanyService : ICompanyService
    {
        ICompanyManager cManager = DaoFactory.GetCompanyManager();

        public Core.Domains.Company Save(Core.Domains.Company entity)
        {
            Company _company = null;
            try
            {
                if (entity.Id == 0)
                   _company = cManager.SaveCompany((Company)entity);
                else
                    _company = cManager.SaveOrUpdate((Company)entity);
                return _company;
            }
            catch (NullReferenceException ex)
            {
                throw new Exception("");
            }
        }
        
        public Core.Domains.Company SaveOrUpdate(Core.Domains.Company entity)
        {
            ICompanyManager cManager = DaoFactory.GetCompanyManager();
            Company _company = null;

            try
            {
                _company = cManager.SaveCompany((Company)entity);
                return _company;
            }
            catch(NullReferenceException ex)
            {
                throw new Exception("");
            }
        }

        public Core.Domains.Company FindById(long id)
        {
            Company _company = null;
            try
            {
                _company = cManager.FindCompanyById(id);
                return _company;
            }
            catch
            {
                throw new Exception("");
            }
        }

        public System.Collections.IList FindAll()
        {
            try
            {
                return cManager.FindAllCompanies().ToList();
            }
            catch
            {
                return new ArrayList();
            }
        }

        public bool DeleteCompanyById(Company entity)
        {
            return cManager.DeleteCompanyById(entity);
        }
    }
}
