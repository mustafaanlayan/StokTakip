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
    public partial class girisForm : Form
    {
        public girisForm()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();

            if (k.KayitAc(txtKullaniciAdi.Text,txtParola.Text))
            {
                mainForm f = new mainForm();
                this.Hide();
                f.ShowDialog();
                this.Close();
            }
            else Helpers.Uyar("Kullanıcı Bulunamadı");
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
