using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Quanlythuvien
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public bool isThanhCong { get; private set; }
        private void button1_Click(object sender, EventArgs e)
        {
            string tenDN = txtUserName.Text;
            string pass = txtPassword.Text;
            if (tenDN == "admin" && pass == "admin")
            {
                isThanhCong = true;
                frmMain frmMain = new frmMain();
                frmMain.Show();
                this.Hide();
                

            }
            else
            {
                isThanhCong = false;
                MessageBox.Show("Sai id hoặc mật khẩu");
                this.Close();
                Dispose(); //giải phóng bộ nhớ
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }
}