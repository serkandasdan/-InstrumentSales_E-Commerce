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
    public partial class İletisim : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=SQRT; Initial Catalog=EnstrumanSatis;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from Tbl_Uyeler  where Eposta = '" + Session["Eposta"] + "'", con);
            SqlDataReader drOku = cmd.ExecuteReader();

            while (drOku.Read())
            {
                if (!IsPostBack)
                {

                    txtAdSoyad.Text = (drOku["Adi"].ToString().Trim() + " " + drOku["Soyadi"].ToString().Trim());
                    txtMail.Text = drOku["Eposta"].ToString().Trim();
             
                    

                }
            }
            con.Dispose();
            con.Close();
        }
       

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=SQRT; Initial Catalog=EnstrumanSatis;Integrated Security=True");
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Insert into Tbl_Message(Gonderen,GonderenMail,Mesaj) values ('"+ txtAdSoyad.Text +"','" + txtMail.Text + "','" + txtMesaj.Text + "') ", con);
            cmd2.ExecuteNonQuery();
            con.Dispose();
            con.Close();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Mesajınız başarı ile gönderilmiştir. Anasayfaya Yönlendiriliyorsunuz...'); window.location.href='Anasayfa2.aspx'; </script>");
        }
        }
    }