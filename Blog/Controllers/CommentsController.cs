using Blog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class CommentsController : Controller
    {
        public ActionResult Create(int articleID)
        {
            var newComment = new Article();
            newComment.CategoryId = articleID; // this will be sent from the ArticleDetails View, hold on :).

            return RedirectToRoute("Details", newComment);
        }

        [HttpPost]
        public ActionResult Create(Comment commentEntity)
        {
            using (var database = new BlogDbContext())
            {
                Article model = new Article();
                database.Comments.Add(commentEntity);
                database.SaveChanges();
                return RedirectToAction("Create", "Comment", new { id = commentEntity.Id });
            }
           
        }
    }
}