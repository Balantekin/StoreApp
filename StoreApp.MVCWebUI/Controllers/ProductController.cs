using StoreApp.Business.Abstract;
using StoreApp.Business.Manager;
using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreApp.MVCWebUI.Controllers
{
    public class ProductController : Controller
    {
        IProductManager _productManager;
        ICategoryManager _categoryManager;
        public ProductController()
        {
            _productManager = new ProductManager();
            _categoryManager = new CategoryManager();
        }

        // GET: Product
        public ActionResult Index()
        {
            var products = _productManager.GetAll().ToList();
            return View(products);
        }

        public ActionResult List(int? id, string q)
        {
            var products = _productManager.GetAll().Where(x => x.IsApproved == true);
            if (id!=null)
            {
                products = products.Where(x => x.CategoryID == id);
            }

            if (!string.IsNullOrEmpty(q))
            {
                products = products.Where(x => x.Name.Contains(q)||x.Description.Contains(q));
            }
                
            return View(products.OrderByDescending(x => x.Date).ToList());
        }

        public PartialViewResult FeaturedProductList()
        {
            var products = _productManager.GetAll().Where(x => x.IsApproved == true&&x.IsFeatured==true).OrderByDescending(x => x.Date).Take(5).ToList();
            return PartialView(products);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = _productManager.get(id);
            return View(product);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.categories = _categoryManager.GetAll().ToList();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(Product entity)
        {
            try
            {
                _productManager.Add(entity);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productManager.get(id);
            ViewBag.categories = _categoryManager.GetAll().ToList();
            return View(product);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product entity)
        {
            try
            {
                _productManager.Update(entity);
                TempData["Updated"] = entity.Name;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
