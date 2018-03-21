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
    public partial class frmTacGia : DevExpress.XtraEditors.XtraForm
    {
        public frmTacGia()
        {
            InitializeComponent();
        }
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        private void connect()
        {
            String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlythuvienMTA' ;Integrated Security = true";//;Integrated Security = false
            con = new SqlConnection(cn);
            con.Open();
        }

        public void getdata()
        {
            String sqlSELECT = "SELECT * FROM Tacgia";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView2.DataSource = dt; // đổ dữ liệu vào dG
        }

        private void frmTacGia_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            txtMatacgia.Text = dataGridView2.Rows[index].Cells[0].Value.ToString();
            txtTentacgia.Text = dataGridView2.Rows[index].Cells[1].Value.ToString();
            txtNgaysinh.Text = dataGridView2.Rows[index].Cells[2].Value.ToString();
            txtQueQuan.Text = dataGridView2.Rows[index].Cells[3].Value.ToString();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete from Tacgia where Matacgia = '"+txtMatacgia.Text+"'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string theDate = txtNgaysinh.Value.ToString("MM/dd/yyyy");
            string sua = "update Tacgia set Tentacgia = N'"+txtTentacgia.Text+"', Ngaysinh = '"+theDate+"', QueQuan = N'"+txtQueQuan.Text+"' where Matacgia = '"+txtMatacgia.Text+"'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string theDate = txtNgaysinh.Value.ToString("MM/dd/yyyy");
            string them = "insert into Tacgia values ('" + txtMatacgia.Text + "',N'" + txtTentacgia.Text + "','" + theDate + "',N'" + txtQueQuan.Text + "')";
            SqlCommand comThem = new SqlCommand(them, con);
            comThem.ExecuteNonQuery();
            getdata();
            MessageBox.Show("Thêm mới thành công ");
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }
}
