using Cts.project.Cts.Models;
using Sitecore.Data;
using Sitecore.Publishing;
using Sitecore.SecurityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class CommentsController : Controller
    {
        // GET: Comments
        [HttpGet]
        public ActionResult CommentsFormAction()
        {
            Comment comment = new Comment();
            return View("/Views/Cts/LeadershipProfile/CommentsForm.cshtml", comment);
        }
        [HttpPost]
       public ActionResult CommentsFormAction(Comment comment)
        {
            //Create a new comment item as child item for the article item
            //template
            TemplateID templateID = new TemplateID(new ID("{A464795A-54DE-48B4-BC57-A7C0F78D65CF}"));
            //parent item
            var parentItem = Sitecore.Context.Item;
            var masterDB = Sitecore.Configuration.Factory.GetDatabase("master");
            var webDb = Sitecore.Configuration.Factory.GetDatabase("web");
            var parentItemFromMasterDb = masterDB.GetItem(parentItem.ID);
            //create item
            //var commentsItem = parentItem.Add(comment.Name, templateID);
            using (new SecurityDisabler())
            {
                var commentsItem = parentItemFromMasterDb.Add(comment.Name, templateID);
                //update the fields 
                commentsItem.Editing.BeginEdit();
                commentsItem["Comments"] = comment.Comments;
                commentsItem["Name"] = comment.Name;
                commentsItem["EmailId"] = comment.EmailId;
                commentsItem.Editing.EndEdit();

                PublishOptions publishOptions = new PublishOptions(masterDB, webDb, PublishMode.SingleItem, Sitecore.Context.Language, DateTime.Now);
                Publisher publisher = new Publisher(publishOptions);
                publisher.Options.RootItem = commentsItem;
                publisher.Options.Deep = true;
                publisher.Options.Mode = PublishMode.SingleItem;
                publisher.Publish();
                return View("/Views/Cts/LeadershipProfile/ThankYou.cshtml");
            }
        }

    }
}