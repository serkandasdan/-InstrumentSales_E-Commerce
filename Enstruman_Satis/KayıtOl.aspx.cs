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
    public partial class KayıtOl : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=SQRT; Initial Catalog=EnstrumanSatis;Integrated Security=True");

        protected void btnKayit_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text.Equals("") || txtSoyadi.Text.Equals("") || ddl_Cinsiyet.Text.Equals("") || txtDogumTarihi.Text.Equals("") || txtCepNo.Text.Equals("") || txtAdres.Text.Equals("") || txtEposta.Text.Equals("") || txtSifre.Text.Equals("") || txtSifreTekrar.Text.Equals(""))
            {
                lblMesaj.Text = ("Lütfen Tüm Gerekli Alanları Doldurunuz.");
                lblMesaj.Visible = true;
            }
            else
            {
                if (txtSifre.Text != txtSifreTekrar.Text)
                {
                    lblMesaj.Text = ("Şifreler Uyuşmuyor. Lütfen Kontrol Ediniz.");
                    lblMesaj.Visible = true;
                }
                else
                {
                    SqlCommand cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Select * from Tbl_Uyeler where Eposta = '" + txtEposta.Text + "'";
                    cmd.ExecuteNonQuery();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblMesaj.Text = ("Sistem aynı E-posta vardır. Lütfen farklı E-posta deneyiniz.");
                        lblMesaj.Visible = true;
                    }
                    else
                    {
                        //con.Open();
                        dr.Close();
                        SqlCommand cmd1 = new SqlCommand("Insert into Tbl_Uyeler(Adi,Soyadi,Cinsiyet,DogumTarihi,CepNo,Adres,Eposta,Sifre) values ('" + txtAdi.Text + "','" + txtSoyadi.Text + "','" + ddl_Cinsiyet.Text + "','" + txtDogumTarihi.Text + "','" + txtCepNo.Text + "','" + txtAdres.Text + "','" + txtEposta.Text + "','" + txtSifre.Text + "') ", con);
                        cmd1.ExecuteNonQuery();
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Kaydınız Başarı ile Gerçekleştirilmiştir. Anasayfaya Yönlendiriliyorsunuz...'); window.location.href='Anasayfa.aspx'; </script>");
                    }
                    con.Dispose();
                    con.Close();
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}