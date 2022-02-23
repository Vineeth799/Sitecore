using Cts.project.Cts.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Cts.project.Cts.Controllers
{
    public class FilePathControllerController : Controller
    {
        // GET: FilePathController
        public ActionResult GetBreadCumb()
        {
            var contextItem = Sitecore.Context.Item;
            var homeItem = Sitecore.Context.Database.GetItem(Sitecore.Context.Site.StartPath);
            NavigationItem currentItemNav = new NavigationItem
            {
                NavTitle = contextItem.DisplayName,
                NavUrl = LinkManager.GetItemUrl(contextItem)
            };
            var navItemList = contextItem.Axes.GetAncestors()
                .Where(x => x.Fields["IsNavigable"] != null && x.Fields["IsNavigable"].Value == "1")
                //.Where(x => x.CheckForNavigable())
                .Where(x => x.Axes.IsDescendantOf(homeItem))
                                .Select(x => new NavigationItem
                                {
                                    NavTitle = x.DisplayName,
                                    NavUrl = LinkManager.GetItemUrl(x)

                                })
                                .ToList()
                                .Concat(new List<NavigationItem> { currentItemNav });
                

            


            return View("/Views/Cts/Common/BreadCumb.cshtml", navItemList);
        }
        //private bool CheckForNavigable(Item item)
        //{
        //    CheckboxField checkBox = item.Fields["IsNavigable"];
        //    return checkBox.Checked;
        //}
        
    }
}