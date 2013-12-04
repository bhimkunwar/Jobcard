using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SRT.Dao
{
    public interface IBaseDao<T, Pk>
    {
        T Save(T entity);

        T SaveOrUpdate(T entity);

        T FindById(Pk id);

        //ICollection<T> FindAll();
        IList<T> FindAll();

        IList Find(string query, object[] values);

        bool Delete(T entity);
    }
}
