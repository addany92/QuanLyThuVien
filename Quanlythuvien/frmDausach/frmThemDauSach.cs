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
    public partial class frmThemDauSach : DevExpress.XtraEditors.XtraForm
    {

        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        public frmThemDauSach()
        {
            InitializeComponent();
        }
        private void connect()
        {
            //String cn = @"server ='DESKTOP-J51JA3J\SQLEXPRESS' ;database ='Project_QuanlythuvienMTA' ;Integrated Security = true";//;Integrated Security = false
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
            txtMasach.Enabled = false;

            comboBox1.Items.Add("GT");
            comboBox1.Items.Add("BDT");
            comboBox1.Items.Add("TH");
            comboBox1.Items.Add("TC");
            comboBox1.Items.Add("TR");
            comboBox1.Items.Add("KT");
            comboBox1.Items.Add("TL");
        }
        public bool kiemtratontai_masach()
        {
            bool KT = false;
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from Dausach where Masach='" + txtMasach.Text + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }
        

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDauSach dg = new frmDauSach();
            dg.ShowDialog();
            //this.Close();
            //Dispose();
        }

        private void frmThemDauSach_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtMasach.Enabled = true;
            txtMasach.Text = comboBox1.Text;
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            if (kiemtratontai_masach())
            {
                MessageBox.Show("Mã sách đã tồn tại. Vui lòng nhập lại !");
            }
            else
            if (txtMasach.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã sách");
            }
            else
            if(txtMatacgia.Text == "")
            {
                MessageBox.Show("Bạn phải nhập mã tác giả");
            }
                    
            else
            {
                string them = "insert into Dausach values ('" + txtMasach.Text + "','" + txtMatacgia.Text + "',N'" + txtTensach.Text + "',N'" + txtTenNXB.Text + "','" + textBox1.Text + "','" + txtSoluong.Text + "','" + txtGia.Text + "')";
                SqlCommand comThem = new SqlCommand(them, con);
                comThem.ExecuteNonQuery();
                getdata();
                MessageBox.Show("Thêm mới thành công ");
                this.Close();
                frmDauSach Docgia = new frmDauSach();
                Docgia.ShowDialog();
            }

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }

}
