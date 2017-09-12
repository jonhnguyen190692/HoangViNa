using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
   public class FooterDao
   {
       private OnlineShopDbContext db = null;

       public FooterDao()
       {
           db=new OnlineShopDbContext();
       }

       public Footer GetFooter()
       {
           return db.Footer.SingleOrDefault(x => x.Status == true);
       }
    }
}
