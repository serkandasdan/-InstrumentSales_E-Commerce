using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;
namespace Enstruman_Satis
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=.; Database=EnstrumanSatis; trusted_connection=true");
            SqlDataAdapter adp = new SqlDataAdapter("Select * From Tbl_Kategoriler", con);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();


        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            Session["Data"] = lbtn.Text;

            if (lbtn.Text.Equals("Akordiyon"))
            {
                Response.Redirect("Akordiyon.aspx");

            }
        }
}
}