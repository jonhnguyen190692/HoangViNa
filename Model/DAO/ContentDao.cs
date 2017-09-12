using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Common;
using Model.EF;
using PagedList;


namespace Model.DAO
{
    public class ContentDao
    {
        private OnlineShopDbContext db = null;

        public ContentDao()
        {
            db = new OnlineShopDbContext();
        }
        /// <summary>
        /// List all content client
        /// </summary>List All content for client
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Content> ListAllPaging(int page, int pageSize)
        {
            IQueryable<Content> model = db.Content;
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Content> ListAllByTag(string tag, int page, int pageSize)
        {
            var model = (from a in db.Content
                         join b in db.ContentTag on a.ID equals b.contentID
                         where b.TagID == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTile = a.MetaTitle,
                             Image = a.Image,
                             Description = a.Description,
                             CreateDate = a.CreateDate,
                             CreateBy = a.CreateBy,
                             ID = a.ID
                         }).AsEnumerable().Select(x => new Content()
                         {
                             Name = x.Name,
                             MetaTitle = x.MetaTile,
                             Image = x.Image,
                             Description = x.Description,
                             CreateDate = x.CreateDate,
                             CreateBy = x.CreateBy,
                             ID = x.ID
                         });

            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<Content> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Content> model = db.Content;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize);
        }
        public Content GetByID(long id)
        {
            return db.Content.Find(id);
        }

        public Tag GetTag(string id)
        {
            return db.Tag.Find(id);
        }
        public long Edit(Content content)
        {
            //Xu ly alias
            if (string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.toUnsignString(content.Name);
            }
            content.CreateDate = DateTime.Now;
            db.Content.Add(content);
            db.SaveChanges();
            //xu ly Tag
            if (!string.IsNullOrEmpty(content.Tags))
            {
                RemoveAllContentTag(content.ID);
                string[] tags = content.Tags.Trim().Split(',');
                foreach (var tag in tags)
                {
                    var tagId = StringHelper.toUnsignString(tag);
                    var existedTag = this.CheckTag(tagId);
                    //Insert to Tag Table
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }
                    //Insert to content tag
                    this.InsertContentTag(content.ID, tagId);
                }
            }
            return content.ID;
        }

        public void RemoveAllContentTag(long contentId)
        {
            db.ContentTag.RemoveRange(db.ContentTag.Where(x => x.contentID == contentId));
            db.SaveChanges();
        }
        public long Create(Content content)
        {
            //Xu ly alias
            if (string.IsNullOrEmpty(content.MetaTitle))
            {
                content.MetaTitle = StringHelper.toUnsignString(content.Name);
            }
            content.CreateDate = DateTime.Now;
            content.ViewCount = 0;
            db.Content.Add(content);
            db.SaveChanges();
            //xu ly Tag

            if (!string.IsNullOrEmpty(content.Tags))
            {
                string[] tags = content.Tags.Trim().Split(',');
                foreach (var tag in tags)
                {
                    var tagId = StringHelper.toUnsignString(tag);
                    var existedTag = this.CheckTag(tagId);
                    //Insert to Tag Table
                    if (!existedTag)
                    {
                        this.InsertTag(tagId, tag);
                    }
                    //Insert to content tag
                    this.InsertContentTag(content.ID, tagId);
                }
            }
            return content.ID;
        }

        public void InsertTag(string id, string name)
        {
            var tag = new Tag
            {
                ID = id,
                Name = name
            };
            db.Tag.Add(tag);
            db.SaveChanges();

        }

        public void InsertContentTag(long contentId, string tagId)
        {
            var contentTag = new ContentTag();
            contentTag.contentID = contentId;
            contentTag.TagID = tagId;
            db.ContentTag.Add(contentTag);

        }
        public bool CheckTag(string id)
        {
            return db.Tag.Count(x => x.ID == id) > 0;
        }

        public List<Tag> ListTag(long contentId)
        {
            var model = (from a in db.Tag
                         join b in db.ContentTag on a.ID equals b.TagID
                         where b.contentID == contentId
                         select new 
                         {
                             ID = b.TagID,
                             Name = a.Name
                         }).AsEnumerable().Select(x => new Tag()
                         {
                             ID = x.ID,
                             Name = x.Name
                         });
            return model.ToList();


        }

    }
}
