using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrightenCommunities.Models;


namespace BrightenCommunities.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult _BlogPartial()
        {
            return PartialView(db.Blogs.ToList());
        }

        public ActionResult _BlogCreatePartial()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _BlogCreatePartial([Bind(Include = "Id,UserName,Post")] Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                db.Blogs.Add(blogs);
                db.SaveChanges();
                return View();
            }

            return View(blogs);           
        }

        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }       
    }
}