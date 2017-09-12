﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
  public  class OrderDetailDao
  {
      private OnlineShopDbContext db = null;

      public OrderDetailDao()
      {
          db=new OnlineShopDbContext();
      }

      public bool Insert(OrderDetail detail)
      {
          try
          {
              db.OrderDetail.Add(detail);
              db.SaveChanges();
              return true;
          }
          catch
          {
              return false;
          }
      }
  }
}
