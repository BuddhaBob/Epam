using LayersDAL.EF;
using LayersDAL.Entity;
using LayersDLL.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Layers.Controllers
{
    public class NotesController : Controller
    {

        public ActionResult MainPage()
        {
            SiteContext db = new SiteContext();

            var Id = Session["UserId"];
            if (Id == null)
            {
                return RedirectToAction("Login", "Account");
            }

            


            return View("MainPage");
        } 

        public ActionResult MainContent()
        {
            SiteContext db = new SiteContext();

            db.SaveChanges();
            var model = db.Posts.ToList();
            return PartialView("MainContent", model);
        }
        [HttpPost]
        public ActionResult PostSearch(string searchText)
        {
            SiteContext db = new SiteContext();
            var foundPosts = db.Posts.Where(p => p.Title.Contains(searchText)).ToList();

            if (foundPosts.Any())
            {
                return PartialView(foundPosts);
            }

            return RedirectToAction("MainContent");
        }

        public ActionResult Add()
        {
           

            return null;
        }
        [HttpPost]
        public ActionResult Add(AddPostModel models)
        {
            /*var email = Membership.GetUser(User.Identity.Name)?.Email;
            int id = db.Users.Where(x => x.Email == email).SingleOrDefault().UserId;*/
            

                Post post = null;

                SiteContext db = new SiteContext();

                post = db.Posts.FirstOrDefault(u => u.Title == models.Title);

                if (post == null)
                {
                    var Id = Session["UserId"];

                    db.Posts.Add(new Post { Title = models.Title, Content = models.Text, UserId = Convert.ToInt32(Id) });

                    db.SaveChanges();
                    

                    if(post != null)
                    {
                        return RedirectToAction("MainContent");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Post with same title is already exist");
                }
                // Int32 userId = Int32.Parse(db.Users.Where(u => u.Email == User.Identity.Name).Select(u => u.UserId).ToString());



            
            return RedirectToAction("MainContent");
        }

        public ActionResult CurrentPost(int? PostId)
        {
            
            SiteContext db = new SiteContext();
            if(PostId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Post post = db.Posts.Find(PostId);

            if(post == null)
            {
                return HttpNotFound();
            }

            return PartialView(post);
        }
       

        [HttpPost]
        public ActionResult RatingCalculation(int? postId, string submitButton)
        {
            SiteContext db = new SiteContext();
            Post post;

            switch (submitButton)
            {
                case "up":
                    if (postId != null)
                    {
                        ViewBag.UpFlag = false;
                        ViewBag.DownFlag = true;
                        post = db.Posts.Where(p => p.PostId == postId).FirstOrDefault();
                        post.Rating = post.Rating + 1;
                        db.SaveChanges();

                        return PartialView(post);
                    }
                    break;
                case "down":
                    if (postId != null)
                    {
                        ViewBag.UpFlag = true;
                        ViewBag.DownFlag = false;
                        post = db.Posts.Where(p => p.PostId == postId).FirstOrDefault();
                        post.Rating = post.Rating - 1;
                        db.SaveChanges();

                        return PartialView(post);
                    }
                    break;
            }

            return PartialView();
        }
    }
}
