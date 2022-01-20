using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace StokTakip.Clasess
{
    class Helpers
    {
        public static void Uyar(string prmUyar)
        {
            XtraMessageBox.Show(prmUyar, "Uyar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ExcelAktar(string prmIsim, GridControl prmGc)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = prmIsim;

            if (sfd.ShowDialog()==DialogResult.OK)
            {
                prmGc.ExportToXlsx(sfd.FileName);

                Process p = new Process();
                p.StartInfo.FileName = sfd.FileName;
                p.Start();
                p.Dispose();
                p = null;
            }
            sfd.Dispose();
        }
    }
}
