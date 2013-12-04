using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Core.Domains;

namespace SRT.Dao.Test
{
    [TestClass]
    public class UserManagerTest
    {
            
        //[TestMethod]
        public void SaveUserTest()
        {
            bool isCreated = false;
            IUserManager uManager = DaoFactory.GetUserManager();
            User user = new User();
            var company = new Company();
            company.Id = 1;

            user.UserName = "bhim";
            user.Designation = "ceo";
            user.IsActive = true;
            user.Name = "bhim";
            user.OldPassword = "bhimkunwar";
            user.UserType = "admin";
            user.company = company;
            isCreated = uManager.IsUserCreated(user);
            Assert.IsTrue(isCreated);
        }                       

        //[TestMethod]
        public void GetUSerinfoByUsernameTest()
        {
            IUserManager uManager = DaoFactory.GetUserManager();
            User user = new User();
            user.UserName = "bhim";
            user.Id = 1;
            int id =  uManager.GetUSerinfoByUsername(user).Id;
            Assert.AreEqual(id, 1);
        }

        //[TestMethod]
        public void ChangeUserPassword()
        {
            IUserManager uManager = DaoFactory.GetUserManager();
            User _user = new User();
            _user.UserName = "bhim";
            _user.OldPassword = "bhim";
            _user.NewPassword = "bhimkunwar";
            uManager.IsPasswordChanged(_user);
        }
    }
}
