using Cts.project.Cts.Models;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cts.project.Cts.Controllers
{
    public class StatrtUpJoinerController : Controller
    {
        // GET: StatrtUpJoiner
        public ActionResult GetListOfStartUpJoiners()
        {
            var contextItem = Sitecore.Context.Item;
            var startUpJoinersSettingItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{F85E40E6-7621-4C6D-90F7-1AE336F72F56}"));
           
            var startUpJoinersList = contextItem.GetChildren()
                                        .Where(x => x.TemplateName == "PersonProfile")
                                        .Where(x => CheckJoinerForStartUp(x))
                                        .Select(x => new LeaderShipCard
                                        {
                                            LeaderName = x.Fields["Name"].Value,
                                            LeaderProfile = x.Fields["EmailId"].Value,
                                            LeaderProfileUrl = LinkManager.GetItemUrl(x),
                                        }).ToList();
            return View("/Views/Cts/Listing/StartUpJoiners.cshtml", startUpJoinersList);
        }
        private bool CheckJoinerForStartUp(Item joinerItem)
        {
            LinkField profileField = joinerItem.Fields["ProfileLink"];
            var startUpJoinersSettingItem = Sitecore.Context.Database.GetItem(new Sitecore.Data.ID("{F85E40E6-7621-4C6D-90F7-1AE336F72F56}"));
            DateField startDate = startUpJoinersSettingItem.Fields["StartDate"];
            DateField endDate = startUpJoinersSettingItem.Fields["EndDate"];
            if (profileField.IsInternal)
            {
                var profileItem = profileField.TargetItem;
                if (profileItem.TemplateName == "CTSProfile")
                {
                    DateField profileJoiningDate = profileItem.Fields["DateOfJoining"];
                    if ((profileJoiningDate.DateTime > startDate.DateTime)
                        && (profileJoiningDate.DateTime < endDate.DateTime))
                        return true;
                    else
                        return false;
                }
                else
                    return false;
            }
            else
                return false;
            //return true;
        }
    }
}