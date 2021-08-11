using AnimationKamlaV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimationKamlaV1.Controllers
{
    public class UserController : Controller
    {
    // GET: User
    animationkamlaEntities db = new animationkamlaEntities();
    public ActionResult Home()
        {
          HomeViewModel vm = new HomeViewModel();
          var homepost = db.tbl_home.ToList();
          var catpost = db.tbl_category_sub.Where(x=>x.categoryid == 1).ToList();
          vm.post = homepost;
          vm.allcategory = catpost;
          return View(vm);
    }
    }
}
