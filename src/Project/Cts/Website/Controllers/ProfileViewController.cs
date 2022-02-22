using Cts.project.Cts.Models;
using Sitecore.Web.UI.WebControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class ProfileViewController : Controller
    {
        // GET: ProfileView
        public ActionResult GetProfileView()
        {
            var contextItem = Sitecore.Context.Item;
            ProfileView profileView = new ProfileView();
            profileView.FirstName = new HtmlString(FieldRenderer.Render(contextItem, "First name"));
            profileView.LastName = new HtmlString(FieldRenderer.Render(contextItem, "Last name"));
            profileView.EmailId = new HtmlString(FieldRenderer.Render(contextItem, "emai id"));
            return View("/Views/Cts/LeadershipProfile/ProfileView.cshtml", profileView);
        }
    }
}