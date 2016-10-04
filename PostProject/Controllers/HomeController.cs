using PostProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            if (model == null)
                return View("Post");
            model.Id = Guid.NewGuid().ToString();
            model.DateOfCreate = DateTime.Now;
            db.PostModel.Add(model);
            db.SaveChanges();
            //Доробити форму виведення постів
            return ShowUserPosts(model.UserId);
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
        public ActionResult ShowUserPosts(int UserId)
        {
            var list = from PostModel in db.PostModel
                       where PostModel.UserId == UserId
                       select PostModel;
            list = list.OrderByDescending(x=>x.DateOfCreate);
            ViewBag.Name = db.Users.Find(UserId).Name;
            return PartialView("PostPartial",list.ToList());
        }
        [HttpPost]
        public ActionResult ShowAllPosts()
        {
            var list = db.PostModel.ToList().OrderByDescending(x => x.DateOfCreate);
            
            return PartialView("PostPartial", list);
        }
        public int LogInUser(string Login, string Password)
        {
            var User = db.Users.FirstOrDefault(x=>x.Login==Login&&x.Password==Password);
            if (User != null)
                return User.Id;
            return -1;
        }

    }
}