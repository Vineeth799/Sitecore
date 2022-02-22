using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cts.project.Cts.Models
{
    public class CtsProfile
    {
        public HtmlString FisrtName { get; set; }
        public HtmlString LastName { get; set; }
        public HtmlString EmailId { get; set; }
        public string DetailedPageUrl { get; set; }
        public HtmlString DateOfJoining { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}