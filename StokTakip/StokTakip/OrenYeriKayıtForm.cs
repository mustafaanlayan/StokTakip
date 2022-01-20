using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StokTakip.Clasess;

namespace StokTakip
{
    public partial class OrenYeriKayıtForm : GlobKayitForm
    {
        public OrenYeriKayıtForm()
        {
            InitializeComponent();
        }

        private void OrenYeriKayıtForm_Load(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtAdi.Text=="")
            {
               Helpers.Uyar("Adı Alanı Zorunlurdur Boş Geçmeyiniz"); 
            }

            try
            {
                Musteri m = new Musteri();
                m.Ad = txtAdi.Text;
                m.Adres = txtAdres.Text;
                m.Telefon = txtTelefon.Text;

                if (m.Kayit())
                {
                    Close();
                }
                else
                {
                    throw new Exception("Kayıt Sırasında Hata Oluştu");
                }
            }
            catch (Exception ex)
            {
                Helpers.Hata(ex.Message);
            }
        }
    }
}
