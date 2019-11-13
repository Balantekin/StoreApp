using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Abstract
{
    public interface IGenericManager<T> where T: class
    {
        T get(int id);
        IQueryable<T> GetAll();
        ResultMessage Add(T entity);
        ResultMessage Update(T entity);
        ResultMessage Delete(T entity);


    }
}
