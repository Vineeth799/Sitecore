using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cts.project.Cts.Models
{
    public class ProfileView
    {
        public HtmlString FirstName { get; set; }
        public HtmlString LastName { get; set; }
        public HtmlString EmailId { get; set; }
    }
}