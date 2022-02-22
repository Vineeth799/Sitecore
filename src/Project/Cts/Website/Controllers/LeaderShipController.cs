using Cts.project.Cts.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class LeaderShipController : Controller
    {
        // GET: LeaderShip
        public ActionResult GetLeadershipProfileInfo()
        {
           
            var contextItem = Sitecore.Context.Item;
            LeadershipProfile leadershipProfile = new LeadershipProfile();
            leadershipProfile.LeaderName = new HtmlString(FieldRenderer.Render(contextItem, "LeaderName"));
            leadershipProfile.Designation = new HtmlString(FieldRenderer.Render(contextItem, "Designation"));
            leadershipProfile.Brief = new HtmlString(FieldRenderer.Render(contextItem, "ProfileBrief"));
            leadershipProfile.LeaderImage = new HtmlString(FieldRenderer.Render(contextItem, "Image"));
            return View("/Views/Cts/LeadershipProfile/ProfileInfo.cshtml", leadershipProfile);
        }
    }
}