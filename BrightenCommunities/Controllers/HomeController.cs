using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using BrightenCommunities.Models;
using System.Threading.Tasks;

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
                ModelState.Clear(); //clears model state in form.
                Response.Redirect(Request.Url.AbsolutePath); //redirects page to index page, prevents double submissions on page refresh.

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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Contact(EmailFormModel model)
        {            
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0}</p> <p>{1}</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("goodrow.chris4@gmail.com"));  // replace with valid value 
                message.From = new MailAddress("goodrow.chris4@gmail.com");  // replace with valid value
                message.Subject = "Brightening Communities Contact";
                message.Body = string.Format(body, model.FromName, model.FromEmail, model.Message);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    ViewBag.Message = "Message Sent";
                    ModelState.Clear();
                    return View();
                }
            }
            return View(model);
        }       
      

        public ActionResult Volunteers()
        {
            return View();
        }

        public ActionResult _VolunteersPartial()
        {
            return PartialView(db.Volunteers.ToList());
        }

        public ActionResult _VolunteersCreatePartial()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult _VolunteersCreatePartial([Bind(Include = "Id,Name,Email,Phone")] Volunteers volunteers)
        {
            if (ModelState.IsValid)
            {
                db.Volunteers.Add(volunteers);
                db.SaveChanges();
                ModelState.Clear();

                Response.Redirect(Request.Url.AbsolutePath); //redirects page to index page, prevents double submissions on page refresh.

                return View();
            }

            return View(volunteers);
        }
    }
}