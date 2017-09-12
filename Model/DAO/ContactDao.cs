using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
   public class ContactDao
   {
       private OnlineShopDbContext db = null;

       public ContactDao()
       {
           db=new OnlineShopDbContext();
       }

       public Contact GetActiveContact()
       {
           return db.Contact.Single(x => x.Status == true);
       }

       public int InsertFeedBack(Feedback fb)
       {
           db.Feedback.Add(fb);
           db.SaveChanges();
           return fb.ID;
       }
   }
}
