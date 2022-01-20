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
    public partial class OrenYeriListesiForm : GlobListeForm
    {
        public OrenYeriListesiForm()
        {
            InitializeComponent();
            DoldurListe();
        }

        #region Olay

        public override void DoldurListe()
        {
            DbConnection con = new DbConnection();
            gridControl1.DataSource = con.GetQuery("SELECT * FROM TblOrenyeri WHERE IsSilindi=0");
            con.Close();
        }
        #endregion

        private void btnEkle_Click(object sender, EventArgs e)
        {
            OrenYeriKayıtForm f = new OrenYeriKayıtForm();
            f.ShowDialog();
        }


    }
}
