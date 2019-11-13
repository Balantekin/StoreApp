using StoreApp.DataAccess.Abtract;
using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Concrete.EntityFramework
{
    public class EFCategoryDal:EFGenericDal<Category>, ICategoryDal
    {
    }
}
