using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class MenuDao
    {
        private OnlineShopDbContext db = null;

        public MenuDao()
        {
            db=new OnlineShopDbContext();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menu.Where(x => x.TypeID == groupId&&x.Status==true).OrderBy(x=>x.DisplayOrder).ToList();
        } 
    }
}
