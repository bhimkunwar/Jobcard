using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SRT.Service.Abstract;
using SRT.Dao.Abstract;
using SRT.Dao.Concrete;
using SRT.Core.Domains; 
using SRT.Dao;
using SRT.Common;
namespace SRT.Service.Concrete
{
    public class UserService : IUserService     
    {
        IUserManager uManager = DaoFactory.GetUserManager();
        public bool IsPasswordValid(User entity)
        {
            throw new NotImplementedException();
        }
        public bool IsUserCreated(User entity)
        {
            bool IsCreated = false;
            try
            {
                if (uManager.IsUserCreated(entity) == true)
                    IsCreated = true;
                return IsCreated;
            }
            catch
            {
                return IsCreated;
            }
        }

        public User GetUSerinfoByUsername(User entity)
        {
            User _user = null;
            try
            {
                _user = uManager.GetUSerinfoByUsername(entity);
                return _user;
            }
            catch
            {
                throw new Exception("");
            };
        }

        public bool IsPasswordChanged(User entity)
        {
            bool isPasswordchanged = false;

            try
            {
                IUserManager uManager = DaoFactory.GetUserManager();
                if( uManager.IsPasswordChanged(entity) == true)
                isPasswordchanged = true;
                return isPasswordchanged;
            }
            catch
            {
                return isPasswordchanged;
            }
        }

        #region UnImplemented Methods
        public Core.Domains.User Save(Core.Domains.User entity)
        {
            throw new NotImplementedException();
        }

        public Core.Domains.User SaveOrUpdate(Core.Domains.User entity)
        {
            throw new NotImplementedException();
        }

        public Core.Domains.User FindById(long id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList FindAll()
        {
            throw new NotImplementedException();
        }
        #endregion                
    }
}
