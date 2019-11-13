using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Abtract
{
    public interface IGenericDal<T> where T:class
    {
        //Temel crud methodlar buraya ekleniyor.

        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);


    }
}
