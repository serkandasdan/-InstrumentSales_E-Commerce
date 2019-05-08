using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Enstruman_Satis
{
    public partial class Akordiyon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            Session["Data"] = lbtn.Text;


        }
    }
}