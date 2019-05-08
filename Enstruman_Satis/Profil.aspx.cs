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
    public partial class Profil : System.Web.UI.Page
        
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

                    txtAdi.Text = drOku["Adi"].ToString().Trim();
                    txtSoyadi.Text = drOku["Soyadi"].ToString().Trim();
                    ddl_Cinsiyet.Text = drOku["Cinsiyet"].ToString().Trim();
                    txtDogumTarihi.Text = drOku["DogumTarihi"].ToString().Trim();
                    txtCepNo.Text = drOku["CepNo"].ToString().Trim();
                    txtAdres.Text = drOku["Adres"].ToString().Trim();
                    txtSifre.Text = drOku["Sifre"].ToString().Trim();
                    txtSifreTekrar.Text = txtSifre.Text;
                }
            }

            con.Dispose();
            con.Close();

        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (txtAdi.Text.Equals("") || txtSoyadi.Text.Equals("") || ddl_Cinsiyet.Text.Equals("") || txtDogumTarihi.Text.Equals("") || txtCepNo.Text.Equals("") || txtAdres.Text.Equals("") || txtSifre.Text.Equals("") || txtSifreTekrar.Text.Equals(""))
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
                    SqlConnection con = new SqlConnection("Data Source=SQRT; Initial Catalog=EnstrumanSatis;Integrated Security=True");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("Update Tbl_Uyeler set Adi=@Adi,Soyadi=@Soyadi,Cinsiyet=@Cinsiyet,DogumTarihi=@DogumTarihi,CepNo=@CepNo,Adres=@Adres,Sifre=@Sifre where Eposta = '" + Session["Eposta"] + "'", con);

                    cmd.Parameters.AddWithValue("@Adi", txtAdi.Text.ToString());
                    cmd.Parameters.AddWithValue("@Soyadi", txtSoyadi.Text.ToString());
                    cmd.Parameters.AddWithValue("@Cinsiyet", ddl_Cinsiyet.Text.ToString());
                    cmd.Parameters.AddWithValue("@DogumTarihi", txtDogumTarihi.Text.ToString());
                    cmd.Parameters.AddWithValue("@CepNo", txtCepNo.Text.ToString());
                    cmd.Parameters.AddWithValue("@Adres", txtAdres.Text.ToString());
                    cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text.ToString());

                    cmd.ExecuteNonQuery();

                    con.Dispose();
                    con.Close();

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Başarılı", "<script>alert('Bilgileriniz Başarı ile Güncellenmiştir . Anasayfaya Yönlendiriliyorsunuz...'); window.location.href='Anasayfa2.aspx'; </script>");


                }
            }
                   
        }
    }
 }
