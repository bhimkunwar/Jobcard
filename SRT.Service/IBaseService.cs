using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace SRT.Service
{
    public interface IBaseService<T, Pk>
    {
        T Save(T entity);

        T SaveOrUpdate(T entity);

        T FindById(Pk id);

        IList FindAll();
    }
}
