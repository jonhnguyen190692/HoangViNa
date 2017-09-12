using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;
using MVC_v5.Common;

namespace MVC_v5.Areas.Admin.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category model)
        {
            if (ModelState.IsValid)
            {
                var currentCulture = Session[CommonConstants.CurrentCulture];
                model.Language = currentCulture.ToString();
                var id=new CategoryDAO().Insert(model);
                if (id>0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("",StaticResources.Resource.InsertCategoryFailed);
                }
            }
            return View(model);
        }
    }
}