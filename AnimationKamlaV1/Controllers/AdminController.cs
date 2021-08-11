using AnimationKamlaV1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AnimationKamlaV1.Controllers
{
  public class AdminController : Controller
  {
    animationkamlaEntities db = new animationkamlaEntities();
    // GET: Admin
    public ActionResult DashBoard()
    {
      return View();
    }
    public ActionResult AddPost()
    {
      return View();
    }
    [HttpPost]
    public ActionResult AddPost(tbl_home home)
    {
      home.Short_headline = home.Short_headline;
      home.CreateByWhom = home.CreateByWhom;
      string fileName = Path.GetFileNameWithoutExtension(home.ImageFile.FileName);
      string extension = Path.GetExtension(home.ImageFile.FileName);
      fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
      home.ImagePath = "~/Image/" + fileName;
      fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
      home.ImageFile.SaveAs(fileName);
      db.tbl_home.Add(home);
      db.SaveChanges();
      return View();
    }
    public ActionResult CategoryPost()
    {
      tbl_category_sub drp = new tbl_category_sub();
      drp.PostCategory = db.tbl_category.Select(o => new SelectListItem { Value = o.categoryid.ToString(), Text = o.categoryname }).ToList();
      return View(drp);
    }
    [HttpPost]
    public ActionResult CategoryPost(tbl_category_sub cat)
    {

      cat.title = cat.title;
      cat.rating = cat.rating;
      string fileName = Path.GetFileNameWithoutExtension(cat.ImageFile.FileName);
      string extension = Path.GetExtension(cat.ImageFile.FileName);
      fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
      cat.ImagePath = "~/Image/" + fileName;
      fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
      cat.ImageFile.SaveAs(fileName);
      db.tbl_category_sub.Add(cat);
      db.SaveChanges();
      ModelState.Clear();
      return RedirectToAction("CategoryPost");
      
    }
    public ActionResult PostList()
    {
      List<tbl_category> cat = db.tbl_category.ToList();
      List<tbl_category_sub> sub_cat = db.tbl_category_sub.ToList();
      var x = from c in cat
              join s in sub_cat on c.categoryid equals s.categoryid into table1
              from s in table1.ToList()
              select new ViewModel
              {
                category = c,
                sub = s

              };
      return View(x);
    }
  }
}
