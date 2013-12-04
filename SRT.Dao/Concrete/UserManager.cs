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
    public class UserManager : BaseDao<User, long>, IUserManager
    {

        User IUserManager.GetUSerinfoByUsername(User entity)
        {
            User _user = new User();
            try
            {
                ITransaction transaction = null;
                ISession session = null;
                session = NhibernateHelper.OpenSession();
                transaction = session.BeginTransaction();

                _user = session.Get<User>(entity.UserName);
                return _user;               
            }
            catch
            {
                return _user;
            }
        }
        bool IUserManager.IsPasswordChanged(User entity)
        {

            bool isPasswordchanged = false;
            ITransaction transaction = null;
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();

                var usr = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("UserName", entity.UserName))
                    .List<User>().FirstOrDefault();
                if (usr != null)
                {
                    if (usr.OldPassword ==  entity.OldPassword)
                    {
                        usr.NewPassword = entity.NewPassword;
                        usr.OldPassword = entity.NewPassword;
                        isPasswordchanged = true;
                    }
                    transaction = session.BeginTransaction();
                    session.SaveOrUpdate(usr);
                    transaction.Commit();
                    session.Flush();
                }
                return isPasswordchanged;
            }
            catch
            {
                transaction.Rollback();
                return isPasswordchanged;
            }
        }
        public bool IsUserCreated(User entity)
        {
            bool isUserCreated = false;
            ITransaction transaction = null;
            User usr = new User();
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();

                var comp = session.CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("UserName", entity.UserName))
                    .List<User>().FirstOrDefault();
                if (comp != null)
                {
                    isUserCreated = false;
                }
                else
                {
                    transaction = session.BeginTransaction();
                    isUserCreated = true;

                    session.Save(entity);
                    transaction.Commit();
                    session.Flush();

                }
                return isUserCreated;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
        bool IBaseDao<User, long>.Delete(User entity)
        {
            ITransaction transaction = null;
            try
            {
                ISession session = null;
                session = NhibernateHelper.OpenSession();
                transaction = session.BeginTransaction();

                var obj = session.Get<User>(entity.Id);
                if (obj != null)
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


        #region Unimplimented

        User IBaseDao<User, long>.Save(User entity)
        {
            throw new NotImplementedException();
        }
        User IBaseDao<User, long>.SaveOrUpdate(User entity)
        {
            throw new NotImplementedException();
        }
        User IBaseDao<User, long>.FindById(long id)
        {
            throw new NotImplementedException();
        }
        //System.Collections.IList IBaseDao<User, long>.FindAll()
        //{
        //    throw new NotImplementedException();
        //}
        System.Collections.IList IBaseDao<User, long>.Find(string query, object[] values)
        {
            throw new NotImplementedException();
        }        

        #endregion
    }
}
