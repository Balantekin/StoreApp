﻿using StoreApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAccess.Abtract
{
    public interface IOrderDal:IGenericDal<Order>
    {
        //Ekstra Method varsa buraya ekleniyor
    }
}
