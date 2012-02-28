using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var ipageName = (Page.AppRelativeVirtualPath).Replace("~/", "").ToLower();

            liHome.Attributes["class"] = liAdd.Attributes["class"] = "";

            switch (ipageName)
            {
                case "default.aspx":
                    liHome.Attributes["class"] = "active";
                    break;

                case "add.aspx":
                    liAdd.Attributes["class"] = "active";
                    break;

                default:
                    break;
            }
        }
    }
}
