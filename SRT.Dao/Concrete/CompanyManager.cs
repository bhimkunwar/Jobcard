using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Core.Domains;
using SRT.Dao.Abstract;
using NHibernate;
using Iesi.Collections;
using NHibernate.Criterion;
namespace SRT.Dao.Concrete
{
    public class CompanyManager : BaseDao<Company, long>, ICompanyManager
    {
        public bool IfVendorExists(Company entity)
        {
            throw new NotImplementedException();
        }

        Company ICompanyManager.SaveCompany(Company entity)
        {
            ITransaction transaction = null;

            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();
                transaction = session.BeginTransaction();

                session.Save(entity);
                transaction.Commit();

                return entity;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return entity;
            }
        }        
        IList<Company> ICompanyManager.FindAllCompanies()
        {
            ISession session = null;
            var company = session.CreateCriteria<Company>().List<Company>();
            return company;
        }
        bool ICompanyManager.DeleteCompanyById(Company entity)
        {
            ITransaction transaction = null;
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();
                transaction = session.BeginTransaction();

                var obj = session.Get<Company>(entity.Id);
                session.Delete(obj);

                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
        }
        Company IBaseDao<Company, long>.SaveOrUpdate(Company entity)
        {
            ITransaction transaction = null;
            Company _company = new Company();
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();

                var comp = session.CreateCriteria(typeof(Company))
                    .Add(Restrictions.Eq("Id", entity.Id))
                    .List<Company>().FirstOrDefault();

                if (comp != null)
                {
                    comp.CompanyName = entity.CompanyName;
                    comp.ContactPerson = entity.ContactPerson;
                    comp.Email = entity.Email;
                    comp.FaxNo = entity.FaxNo;
                    comp.IsActive = entity.IsActive;
                    comp.JoinedDate = entity.JoinedDate;
                    comp.ValidTillDate = entity.ValidTillDate;
                    comp.Address = entity.Address;

                    transaction = session.BeginTransaction();
                    session.SaveOrUpdate(comp);
                    transaction.Commit();
                }

                session.Flush();

                return entity;
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return entity;
            }
        }
        Company ICompanyManager.FindCompanyById(long companyId)
        {
            ISession session = null;
            session = NhibernateHelper.OpenSession();

            var obj = session.Get<Company>((Int32)companyId);
            return obj;
        }

        #region UnImplimented Methods        
        bool ICompanyManager.IfVendorExists(Company entity)
        {
            throw new NotImplementedException();
        }
        Company IBaseDao<Company, long>.Save(Company entity)
        {
            throw new NotImplementedException();
        }
        Company IBaseDao<Company, long>.FindById(long id)
        {
            throw new NotImplementedException();
        }
        System.Collections.IList IBaseDao<Company, long>.Find(string query, object[] values)
        {
            throw new NotImplementedException();
        }
        bool IBaseDao<Company, long>.Delete(Company entity)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
