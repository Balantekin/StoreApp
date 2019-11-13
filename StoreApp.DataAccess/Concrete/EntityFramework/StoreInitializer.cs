using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Concrete.EntityFramework
{
    class StoreInitializer:DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){ Name="Category1"},
                new Category(){ Name="Category2"},
                new Category(){ Name="Category3"},
                new Category(){ Name="Category4"},
                new Category(){ Name="Category5"},

            };

            foreach (var item in categories)
            {
                context.Categories.Add(item);
            }

            context.SaveChanges();

            List<Product> products = new List<Product>()
            {
                new Product(){Name="Elma", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=200, Stock=100, CategoryID=1, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Armut", Description="Description1", Image="2.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=1, Date=DateTime.Now.AddDays(-15) },
                new Product(){Name="Mandalina", Description="Description1", Image="3.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=0, CategoryID=1, Date=DateTime.Now.AddDays(-14) },
                new Product(){Name="Portakal", Description="Description1", Image="4.jpg", IsApproved=true,IsFeatured=true,IsHome=false, Price=100, Stock=100, CategoryID=1, Date=DateTime.Now.AddDays(-23) },
                new Product(){Name="Kavun", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=500, Stock=100, CategoryID=1, Date=DateTime.Now.AddDays(-67) },

                new Product(){Name="Kavun", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=2, Date=DateTime.Now.AddDays(-1) },
                new Product(){Name="Karpuz", Description="Description1", Image="2.jpg", IsApproved=true,IsFeatured=false,IsHome=true, Price=300, Stock=100, CategoryID=2, Date=DateTime.Now.AddDays(-16) },
                new Product(){Name="Avokado", Description="Description1", Image="3.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=0, CategoryID=2, Date=DateTime.Now.AddDays(-18) },
                new Product(){Name="Biber", Description="Description1", Image="4.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=2, Date=DateTime.Now.AddDays(-19) },
                new Product(){Name="Domates", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=false, Price=400, Stock=100, CategoryID=2, Date=DateTime.Now.AddDays(-14) },

                new Product(){Name="Patates", Description="Description1", Image="1.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=600, Stock=100, CategoryID=3, Date=DateTime.Now.AddDays(-45) },
                new Product(){Name="Ginger", Description="Description1", Image="2.jpg", IsApproved=true,IsFeatured=true,IsHome=false, Price=100, Stock=0, CategoryID=3, Date=DateTime.Now.AddDays(-345) },
                new Product(){Name="Latte", Description="Description1", Image="3.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=300, Stock=100, CategoryID=3, Date=DateTime.Now.AddDays(-7) },
                new Product(){Name="Espresso", Description="Description1", Image="4.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=3, Date=DateTime.Now.AddDays(-12) },
                new Product(){Name="Product15", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=200, Stock=100, CategoryID=3, Date=DateTime.Now.AddDays(-10) },

                new Product(){Name="Product16", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=false, Price=700, Stock=100, CategoryID=4, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product17", Description="Description1", Image="2.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=4, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product18", Description="Description1", Image="3.jpg", IsApproved=true,IsFeatured=false,IsHome=true, Price=200, Stock=100, CategoryID=4, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product19", Description="Description1", Image="4.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=4, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product20", Description="Description1", Image="1.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=500, Stock=0, CategoryID=4, Date=DateTime.Now.AddDays(-10) },

                new Product(){Name="Product21", Description="Description1", Image="1.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=600, Stock=0, CategoryID=5, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product22", Description="Description1", Image="2.jpg", IsApproved=true,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=5, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product23", Description="Description1", Image="3.jpg", IsApproved=true,IsFeatured=false,IsHome=true, Price=400, Stock=100, CategoryID=5, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product24", Description="Description1", Image="4.jpg", IsApproved=false,IsFeatured=true,IsHome=true, Price=100, Stock=100, CategoryID=5, Date=DateTime.Now.AddDays(-10) },
                new Product(){Name="Product25", Description="Description1", Image="1.jpg", IsApproved=true,IsFeatured=true,IsHome=false, Price=200, Stock=100, CategoryID=5, Date=DateTime.Now.AddDays(-10) },
            };

            foreach (var item in products)
            {
                context.Products.Add(item);

            }

            context.SaveChanges();


            
            base.Seed(context);
        }
    }
}
