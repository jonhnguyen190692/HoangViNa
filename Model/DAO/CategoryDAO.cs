﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class CategoryDAO
    {
        private OnlineShopDbContext db = null;

        public CategoryDAO()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Category category)
        {
            db.Category.Add(category);
            db.SaveChanges();
            return category.ID;
        }

        public List<Category> ListAll()
        {
            return db.Category.Where(x => x.Status == true).ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategory.Find(id);
        }
    }
}
