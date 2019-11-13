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
    public class ProductManager : IProductManager
    {
        IProductDal _productDal;
        public ProductManager()
        {
            //DEPENDENCY INJECTION KULLANIRSAN BAĞIMLILIK KALKAR!!!

            _productDal = new EFProductDal();
        }
        public ResultMessage Add(Product entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            //BÜTÜN KONTROLLER BURADA YAPILABİLİR
            //FİYAT, AÇIKLAMA VS.

            if (entity.Name.Length == 0)
            {
                result.Message = "Ürün Adı Belirtmelisiniz";
                return result;
            }

            if (entity.Name.Length > 50)
            {
                result.Message = "Ürün Adı daha kısa olmalıdır";
                return result;
            }

            //GetALL - IQuerable = veritabanından bilgiler çekilmemiş oluyor. bunun üzerinden filtreleme yapma imkanı sağlıyor.
            //FirstOrDefault bulduğun ilk kaydı al demek

            var _existingProduct = GetAll().Where(x => x.Name == entity.Name).FirstOrDefault();

            if(_existingProduct!=null)
            {
                result.Message = "Bu ürün adı sistemde mevcut. Lüften farklı bir isim seçiniz";
                return result;
            }

            try
            {
                _productDal.Add(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }

        public ResultMessage Delete(Product entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            //VALIDATION KONTROLLER BURADA YAPILDIKTAN SONRA AŞAĞI DÜŞER

            try
            {
                _productDal.Add(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }

        public Product get(int id)
        {
            return _productDal.Get(id);

        }

        public IQueryable<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        public ResultMessage Update(Product entity)
        {
            ResultMessage result = new ResultMessage();
            result.IsSuccess = false;

            if (entity.Name.Length == 0)
            {
                result.Message = "Ürün Adı Belirtmelisiniz";
                return result;
            }

            if (entity.Name.Length > 50)
            {
                result.Message = "Ürün Adı daha kısa olmalıdır";
                return result;
            }

            try
            {
                _productDal.Update(entity);
                result.IsSuccess = true;
            }
            catch (Exception e)
            {
                //LOGLAMA

                result.Message = string.Format("Bir hata oluştu: {0}", e.Message);
                return result;
            }

            return result;
        }
    }
}
