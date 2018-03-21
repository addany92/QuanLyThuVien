using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace Quanlythuvien
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDocgia frmdocgia = new frmDocgia();
            frmdocgia.ShowDialog();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDauSach ds = new frmDauSach();
            ds.ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmMuonTra MuonTra = new frmMuonTra();
            MuonTra.ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmTacGia tg = new frmTacGia();
            tg.ShowDialog();
        }

        private void T_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Phần mềm thuộc về nhóm 4");
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmLogin lg = new frmLogin();
            lg.ShowDialog();
            this.Hide();
        }
    }
}