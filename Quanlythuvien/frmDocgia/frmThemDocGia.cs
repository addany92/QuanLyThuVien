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
using System.Configuration;

namespace Quanlythuvien
{
    public partial class frmThemDocGia : DevExpress.XtraEditors.XtraForm
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL
        public frmThemDocGia()
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
            String sqlSELECT = "SELECT * FROM Docgia";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
        }

        private void frmThemDocGia_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmDocgia dg = new frmDocgia();
            dg.ShowDialog();
            this.Close();
            Dispose();
        }
        public bool kiemtratontai()
        {
            bool KT = false;
            string maso = txtMaDG.Text;          
            SqlDataAdapter da_kiemtra = new SqlDataAdapter("Select * from Docgia where Madocgia='" + maso + "'", con);
            DataTable dt_kiemtra = new DataTable();
            da_kiemtra.Fill(dt_kiemtra);

            if (dt_kiemtra.Rows.Count > 0)
            {
                KT = true;
            }
            da_kiemtra.Dispose();
            return KT;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string chuoi;
            chuoi = txtMaDG.Text;
            if (kiemtratontai())
            {
                MessageBox.Show("Mã độc giả đã tồn tại. Vui lòng nhập lại !");
            }
            else
            {
                if(txtMaDG.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập mã độc giả");
                }
                else if (chuoi.Length !=4)
                {
                    MessageBox.Show("Bạn phải nhập đúng 4 ký tự");
                }
                else
                {
                    string them = "insert into Docgia values ('" + txtMaDG.Text + "',N'" + txtTenDG.Text + "',N'" + txtDiachi.Text + "')";
                    SqlCommand comThem = new SqlCommand(them, con);
                    comThem.ExecuteNonQuery();
                    getdata();
                    MessageBox.Show("Thêm mới thành công ");
                    this.Close();
                    frmDocgia Docgia = new frmDocgia();
                    Docgia.ShowDialog();
                }
            }

        }

    }
}
