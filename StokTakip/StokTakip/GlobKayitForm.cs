using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace StokTakip
{
    public partial class GlobKayitForm : XtraForm
    {
        public GlobKayitForm()
        {
            InitializeComponent();
        }

        #region Olay
         private void btnVazgeç_Click(object sender, EventArgs e)
                {
                    Close();
                }

        private void GlobKayitForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                Close();
            }
        }
    }
        #endregion
       
}
