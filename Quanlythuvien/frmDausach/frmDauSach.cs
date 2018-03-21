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
    public partial class frmDauSach : DevExpress.XtraEditors.XtraForm
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        public frmDauSach()
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
            String sqlSELECT = "SELECT * FROM Dausach";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
            txtMasach.Enabled = false;
            txtMatacgia.Enabled = false;
            txtTKtensach.Enabled = false;
            txtTKtenTG.Enabled = false;
            txtTKtenNXB.Enabled = false;
            txtTKnamXB.Enabled = false;
            btnTKtensach.Enabled = false;
            btnTKtentacgia.Enabled = false;
            btnTKtenNXB.Enabled = false;
            btnTKnamXB.Enabled = false;
        }
        private void frmDauSach_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int index = dataGridView3.CurrentRow.Index;
            txtMasach.Text = dataGridView3.Rows[index].Cells[0].Value.ToString();
            txtTensach.Text = dataGridView3.Rows[index].Cells[2].Value.ToString();
            txtTenNXB.Text = dataGridView3.Rows[index].Cells[3].Value.ToString();
            txtNamXB.Text = dataGridView3.Rows[index].Cells[4].Value.ToString();
            txtMatacgia.Text = dataGridView3.Rows[index].Cells[1].Value.ToString();
            txtSoluong.Text = dataGridView3.Rows[index].Cells[5].Value.ToString();
            txtGia.Text = dataGridView3.Rows[index].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%GT%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button7_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%BDT%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemDauSach tds = new frmThemDauSach();
            tds.ShowDialog();
          
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sua = "UPDATE Dausach set Tensach = N'"+txtTensach.Text+"',TenNXB = N'"+txtTenNXB.Text+"',NamXB = N'"+txtNamXB.Text+"',Soluong = '"+txtSoluong.Text+"',Gia = '"+txtGia.Text+"'  where Masach = '"+txtMasach.Text+"' ";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "DELETE from Dausach where Masach = '" + txtMasach.Text + "'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button6_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%TH%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%TC%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button8_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%TR%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button9_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%KT%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "SELECT * FROM Dausach where Masach like N'%TL%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void tìmKiếmToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void tênSáchToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getdata();
            txtTKtensach.Enabled = true;
            btnTKtensach.Enabled = true;
        }

        private void tácGiảToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getdata();
            txtTKtenTG.Enabled = true;
            btnTKtentacgia.Enabled = true;
        }

        private void nhàXuấtBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getdata();
            txtTKtenNXB.Enabled = true;
            btnTKtenNXB.Enabled = true;
        }

        private void nămXuấtBảnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            getdata();
            txtTKnamXB.Enabled = true;
            btnTKnamXB.Enabled = true;
        }

        private void btnTKtensach_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from Dausach where Tensach like N'%"+txtTKtensach.Text+"%' ";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void btnTKtentacgia_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select ds.Matacgia, tg.Tentacgia ,ds.Tensach, ds.NamXB, ds.Soluong from Dausach ds join Tacgia tg on ds.Matacgia = tg.Matacgia where tg.Tentacgia like N'%"+txtTKtenTG.Text+"%'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void btnTKtenNXB_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from Dausach where TenNXB like N'%" + txtTKtenNXB.Text + "%' ";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void btnTKgia_Click(object sender, EventArgs e)
        {
            String sqlSELECT = "select * from Dausach where NamXB like N'%" + txtTKnamXB.Text + "%' ";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView3.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
