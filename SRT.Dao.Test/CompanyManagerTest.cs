using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Core.Domains;

namespace SRT.Dao.Test
{
    [TestClass]
    public class CompanyManagerTest
    {
        //[TestMethod]
        public void SaveCompany()
        {
            ICompanyManager cManager = DaoFactory.GetCompanyManager();
            Company _company = new Company();
            _company.CompanyName = "Bhim and kalu company";
            _company.ContactPerson = "Bhim kunwar";
            _company.Email = "kunwar_7@yahoo.com";
            _company.IsActive = true;
            _company.JoinedDate = DateTime.Now;
            _company.ValidTillDate = DateTime.Now;
            cManager.SaveCompany(_company);         
        }

        //[TestMethod]
        public void UpdateCompany()
        {
            ICompanyManager cManager = DaoFactory.GetCompanyManager();
            Company _company = new Company();
            _company.Id = 2;
            _company.CompanyName = "Bhim and k company";
            _company.ContactPerson = "Bhim kunwar";
            _company.Email = "kunwar_7@yahoo.com";
            _company.IsActive = true;
            _company.JoinedDate = DateTime.Now;
            _company.ValidTillDate = DateTime.Now;
            cManager.SaveOrUpdate(_company);
        }

        //[TestMethod]
        public void DeleteCompany()
        {
            ICompanyManager cManager = DaoFactory.GetCompanyManager();
            Company _company = new Company();
            _company.Id = 1;
            cManager.DeleteCompanyById(_company);
        }
    }
}
