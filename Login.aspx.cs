using AracTakipSistemi.DB;
using System;
using System.Web;

namespace AracTakipSistemi
{
    public partial class _default : System.Web.UI.Page
    {



        #region Page_Load
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Dil seçimini varsayılan dil ile doldur
                ddlLanguage.SelectedValue = System.Threading.Thread.CurrentThread.CurrentUICulture.Name;

                if (Request.Cookies["KullaniciBilgisi"] != null)
                {
                    HttpCookie cookie = Request.Cookies["KullaniciBilgisi"];
                    txtUsername.Text = cookie["Isim"];
                    txtPassword.Text = cookie["Sifre"];
                    //string sonZiyaretTarihi = cookie["SonZiyaretTarihi"];
                    // Çerezdeki bilgileri kullanma
                }
            }

          

        }
        #endregion

        #region ddlLanguage_SelectedIndexChanged
        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Dil değişikliğinde sayfayı yeniden yükle
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(ddlLanguage.SelectedValue);
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture;
            Server.Transfer(Request.FilePath);
        }
        #endregion

        #region btnLogin_Click
        protected void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            try
            {
                MSSQLHelper mSSQLHelper = new MSSQLHelper();
                Kullanici kullanici = DB.MSSQLHelper.Kullanıci_Getir(username, password);

                if (kullanici.id != 0)
                {
                    Session["User"] = kullanici;

                    Label_mesaj.Text = "";

                    // Kullanıcı oturumunu yönetme
                    if (chkRememberMe.Checked)
                    {
                        // Oturum bilgilerini sakla
                        HttpCookie cookie = new HttpCookie("KullaniciBilgisi");
                        cookie["Isim"] = kullanici.isim;
                        cookie["Sifre"] = kullanici.sifre;
                        cookie["SonZiyaretTarihi"] = DateTime.Now.ToString();

                        // Çerezin ömrünü belirleme
                        cookie.Expires = DateTime.Now.AddDays(10); // 10 gün boyunca geçerli olacak

                        // Çerezi tarayıcıya ekleme
                        Response.Cookies.Add(cookie);

                    }
                    else
                    {
                        // Oturum bilgilerini temizle //cokkie temizlenecek
                        HttpCookie cookie = new HttpCookie("KullaniciBilgisi");
                        cookie.Expires = DateTime.Now.AddDays(-1); // Geçmiş bir tarih
                        Response.Cookies.Add(cookie);
                    }
                    Server.Transfer("Menu.aspx");
                }
                else
                {
                    Label_mesaj.Text = "Kullanıcı Bulunamadı.... Şifre Yada Kullanıcı adınız hatalı";

                }
            }
            catch (Exception ex) { }

        }
        #endregion
    }
}