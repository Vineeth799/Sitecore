using Cts.project.Cts.Models;
using Sitecore.Data.Fields;
using Sitecore.Links;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class CtsProfileController : Controller
    {
        // GET: CtsProfile
        public ActionResult GetCtsProfileInfo()
        {
            var contextItem = Sitecore.Context.Item;

            DateField dateField = contextItem.Fields["DateOfJoining"];
            LinkField link = contextItem.Fields["ProfileLink"];
            var targetItem = link.TargetItem;
            CtsProfile ctsProfile = new CtsProfile();


            ctsProfile.FisrtName = new HtmlString(FieldRenderer.Render(contextItem, "First name"));
            ctsProfile.LastName = new HtmlString(FieldRenderer.Render(contextItem, "Last name"));
            ctsProfile.EmailId = new HtmlString(FieldRenderer.Render(contextItem, "emai id"));
            ctsProfile.DetailedPageUrl = LinkManager.GetItemUrl(targetItem);
            ctsProfile.DateOfJoining = new HtmlString(FieldRenderer.Render(contextItem, "DateOfJoining"));
            /*JoiningDate = dateField.DateTime*/

            
        
            //ctsProfile.DetailedPageUrl = LinkManager.GetItemUrl(targetItem);




            return View("/Views/Cts/LeadershipProfile/CtsProfile.cshtml", ctsProfile);
        }
        public ActionResult GetLeadershipArticle()
        {
            var contextItem = Sitecore.Context.Item;
            List<ArticleInfo> articleInfos = new List<ArticleInfo>();
              MultilistField multilistField = contextItem.Fields["Articles"];
            articleInfos = multilistField.GetItems()
                            .Select(x => new ArticleInfo
                            {
                                Articletitle = new HtmlString(FieldRenderer.Render(x, "Title")),
                                ArticleBreif = new HtmlString(FieldRenderer.Render(x, "Brief")),
                                ArticleUrl = LinkManager.GetItemUrl(x)
                            }).ToList();
            return View("/Views/Cts/LeadershipProfile/Article.cshtml", articleInfos);
        }
    }
}