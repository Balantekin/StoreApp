using StoreApp.Business.Abstract;
using StoreApp.DataAccess.Abtract;
using StoreApp.DataAccess.Concrete.EntityFramework;
using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Business.Manager
{
    public class CategoryManager : ICategoryManager
    {
        ICategoryDal _categoryDal;
        public CategoryManager()
        {
            //DEPENDENCY INJECTION
            _categoryDal = new EFCategoryDal();
        }

        public ResultMessage Add(Category entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            if (entity.Name.Length == 0)
            {
                result.Message = "Kategori Adı Belirtmelisiniz";
                return result;
            }

            if (entity.Name.Length > 50)
            {
                result.Message = "Kategori Adı daha kısa olmalıdır";
                return result;
            }

            try
            {
                _categoryDal.Add(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }

        public ResultMessage Delete(Category entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            //VALIDATION KONTROLLER

            try
            {
                _categoryDal.Remove(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }

        public Category get(int id)
        {
            return _categoryDal.Get(id);
        }

        public IQueryable<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public ResultMessage Update(Category entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            if (entity.Name.Length == 0)
            {
                result.Message = "Kategori Adı Belirtmelisiniz";
                return result;
            }

            if (entity.Name.Length > 50)
            {
                result.Message = "Kategori Adı daha kısa olmalıdır";
                return result;
            }

            try
            {
                _categoryDal.Update(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }
    }
}
