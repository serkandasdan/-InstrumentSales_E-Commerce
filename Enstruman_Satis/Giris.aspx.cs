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
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOturumAc_Click(object sender, EventArgs e)
        {
            string provider = "Data Source=SQRT; Initial Catalog=EnstrumanSatis;Integrated Security=True";
            SqlConnection baglanti = new SqlConnection(provider);
            baglanti.Open();


            SqlCommand komut = new SqlCommand("select * from Tbl_Uyeler where Eposta =@Eposta and Sifre = @Sifre", baglanti);

            komut.Parameters.AddWithValue("Eposta", txtEposta.Text);
            komut.Parameters.AddWithValue("Sifre", txtSifre.Text);


            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                Session["Eposta"] = dr["Eposta"];
                Session["Sifre"] = dr["Sifre"];
                Session["Adi"] = dr["Adi"];
                Session["Soyadi"] = dr["Soyadi"];


                Response.Redirect("Anasayfa2.aspx");
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Hata", "<script>alert('Girdiğin e-posta adresi veya şifre hiçbir hesapla eşleşmiyor.'); </script>");
                txtEposta.Text = ("");
                txtSifre.Text = ("");
            }
        }
    }
}