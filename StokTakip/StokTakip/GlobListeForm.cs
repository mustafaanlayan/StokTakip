using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Data.Utils;
using DevExpress.XtraEditors;
using Helpers = StokTakip.Clasess.Helpers;

namespace StokTakip
{
    public partial class GlobListeForm : XtraForm
    {
        public GlobListeForm()
        {
            InitializeComponent();
        }
        #region Fonk

        public virtual void DoldurListe()
        {

        }
        #endregion

        #region olay

        
        private void btnYenile_Click(object sender, EventArgs e)
        {
            DoldurListe();
        }
        #endregion

        private void btnExcell_Click(object sender, EventArgs e)
        {
            Helpers.ExcelAktar(this.Name,gridControl1);
        }

        private void GlobListeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
