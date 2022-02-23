using Cts.project.Cts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class DisplayCommentsController : Controller
    {
        // GET: DisplayComments
        public ActionResult GetDisplayComments()

        {
            List<Comment> comments = new List<Comment>();
            var contextItem = Sitecore.Context.Item;



            comments = contextItem.GetChildren()
            .Where(x => x.TemplateName == "Comment")
            .Select(x => new Comment
            {
                Comments = x.Fields["Comments"].Value,
                EmailId = x.Fields["EmailId"].Value,
                Name = x.DisplayName
            }).ToList();
            return View("/Views/Cts/LeadershipProfile/DisplayComments.cshtml", comments);
        }
    }
}