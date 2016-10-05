using Microsoft.AspNet.Identity;
using PostProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PostProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

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
        public ActionResult Post()
        {
            var temp = db.PostModel.ToList();
            return View("Post",temp);
        }
        [HttpPost]
        public ActionResult SentPost(PostModel model)
        {

            string id = User.Identity.GetUserId();
            model.User = db.Users.Find(id);
            model.Id = Guid.NewGuid().ToString();
            model.DateOfCreate = DateTime.Now;
            db.PostModel.Add(model);
            db.SaveChanges();
            return ShowUserPosts();
        }
        [HttpPost]
        public void DeletePost(string id)
        {
            PostModel model = db.PostModel.Find(id);
            db.PostModel.Remove(model);
            db.SaveChanges();
        }
        //Enable-Migrations
        //add-migration init
        //update-database
        [HttpPost]
        public ActionResult EditPost(string id)
        {
            PostModel model = db.PostModel.Find(id);
            return PartialView("PopUpPartial",model);
        }
        
        [HttpPost]
        public void SavePost(PostModel model)
        {
            PostModel lastModel = db.PostModel.Find(model.Id);
            lastModel.Title = model.Title;
            lastModel.Description = model.Description;
            db.SaveChanges();
        }
        [HttpPost]
        public ActionResult ShowUserPosts()
        {
            string userId =  User.Identity.GetUserId();
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var list = from PostModel in db.PostModel
                           where PostModel.User.Id == userId
                           select PostModel;
                list = list.Include(x => x.User).OrderByDescending(x => x.DateOfCreate);
                return PartialView("PostPartial", list.ToList());
            }
            else
            {

                var list = db.PostModel.Include(x=>x.User).ToList().OrderByDescending(x => x.DateOfCreate);
                return PartialView("PostPartial", list.ToList());
            }
        }
        [HttpPost]
        public ActionResult ShowAllPosts()
        {
            var list = db.PostModel.ToList().OrderByDescending(x => x.DateOfCreate);
            
            return PartialView("PostPartial", list);
        }

        public ActionResult GetUserInfo()
        {
            string id = User.Identity.GetUserId();
            var user = db.Users.Find(id);

            return PartialView("_LoginPartial",user);
        }
    }
}