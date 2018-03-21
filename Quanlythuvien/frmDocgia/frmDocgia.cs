using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quanlythuvien
{
    public partial class frmDocgia : DevExpress.XtraEditors.XtraForm
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL

        public frmDocgia()
        {
            InitializeComponent();
        }
        private void connect()
        {
            String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlythuvienMTA' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }

        public void getdata()
        {
            String sqlSELECT = "SELECT * FROM Docgia";
            SqlCommand com = new SqlCommand(sqlSELECT,con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView1.DataSource = dt; // đổ dữ liệu vào dG
            txtMadocgia.Enabled = false;
        }

        private void frmDocgia_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmThemDocGia ThemDocGia = new frmThemDocGia();
            ThemDocGia.ShowDialog();
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sua = "UPDATE Docgia SET Tendocgia = N'"+txtTendocgia.Text+"', Diachi = N'"+txtDiachi.Text+"' WHERE Madocgia = '"+txtMadocgia.Text+"'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {          
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "DELETE from Docgia where Madocgia = '" + txtMadocgia.Text + "'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentRow.Index;
            txtMadocgia.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
            txtTendocgia.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[index].Cells[2].Value.ToString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtTenDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaDG_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }
}
