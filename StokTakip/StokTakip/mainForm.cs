﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakip
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void bbOrenYeriListesi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OrenYeriListesiForm f = new OrenYeriListesiForm();
            f.IsMdiContainer = true;
            f.ShowDialog();
        }
    }
}
