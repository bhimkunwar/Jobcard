using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRT.Dao.Concrete
{
    public class BaseDao<T,Pk> : IBaseDao<T, Pk>
    {

        public T Save(T entity)
        {
            throw new NotImplementedException();
        }

        public T SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public T FindById(Pk id)
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList FindAll()
        {
            throw new NotImplementedException();
        }

        public System.Collections.IList Find(string query, object[] values)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T entity)
        {
            throw new NotImplementedException();
        }


        //ICollection<T> IBaseDao<T, Pk>.FindAll()
        //{
        //    throw new NotImplementedException();
        //}


        IList<T> IBaseDao<T, Pk>.FindAll()
        {
            throw new NotImplementedException();
        }
    }
}
