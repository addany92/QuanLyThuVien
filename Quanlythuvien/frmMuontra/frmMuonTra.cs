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
    public partial class frmMuonTra : DevExpress.XtraEditors.XtraForm
    {
        public static SqlConnection con; // Đối tượng cho việc kết nối với SQL 
        public frmMuonTra()
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
            String sqlSELECT = "SELECT * FROM Muontra";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView6.DataSource = dt; ;
        }
        private void frmMuonTra_Load(object sender, EventArgs e)
        {
            connect();
            getdata();
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {

            int index = dataGridView6.CurrentRow.Index;
            txtMadocgia.Text = dataGridView6.Rows[index].Cells[0].Value.ToString();
            txtMasach.Text = dataGridView6.Rows[index].Cells[1].Value.ToString();
            txtNgaymuon.Text = dataGridView6.Rows[index].Cells[2].Value.ToString();
            txtThangmuon.Text = dataGridView6.Rows[index].Cells[3].Value.ToString();
            txtNammuon.Text = dataGridView6.Rows[index].Cells[4].Value.ToString();
            txtThoigianmuon.Text = dataGridView6.Rows[index].Cells[5].Value.ToString();
            txtNgaytra.Text = dataGridView6.Rows[index].Cells[6].Value.ToString();
            txtThangtra.Text = dataGridView6.Rows[index].Cells[7].Value.ToString();
            txtNamtra.Text = dataGridView6.Rows[index].Cells[8].Value.ToString();
            txtSoluong.Text = dataGridView6.Rows[index].Cells[9].Value.ToString();
            txtTienphat.Text = dataGridView6.Rows[index].Cells[10].Value.ToString();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string them = "insert into Muontra values ('" + txtMadocgia.Text + "','" + txtMasach.Text + "','" + txtNgaymuon.Text + "','" + txtThangmuon.Text + "','" + txtNammuon.Text + "','" + txtNgaytra.Text + "','" + txtThangtra.Text + "','" + txtNamtra.Text + "','"+txtThoigianmuon.Text+"','" + txtSoluong.Text + "','" + txtTienphat.Text + "')";
            SqlCommand comThem = new SqlCommand(them, con);
            comThem.ExecuteNonQuery();
            getdata();
            MessageBox.Show("Thêm mới thành công ");

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string sua = "update Muontra set Ngaymuon = '" + txtNgaymuon.Text + "', Thangmuon ='" + txtThangmuon.Text + "' ,Nammuon='" + txtNammuon.Text + "',Ngaytra='" + txtNgaytra.Text + "',Thangtra='" + txtThangtra.Text + "',Namtra='" + txtNamtra.Text + "', Thoigianmuon='" + txtThoigianmuon.Text + "',Soluongmuon='" + txtSoluong.Text + "',Tienphat='" + txtTienphat.Text + "' where Madocgia = '" + txtMadocgia.Text + "'";
            SqlCommand comSua = new SqlCommand(sua, con);
            comSua.ExecuteNonQuery();
            getdata();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa k?", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string xoa = "delete from Muontra where Madocgia = '" + txtMadocgia.Text + "'";
                SqlCommand comXoa = new SqlCommand(xoa, con);
                comXoa.ExecuteNonQuery();
                getdata();
            }
            else if (dialogResult == DialogResult.No)
            {
                getdata();
            }
        }



        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {      
            //lãi suất 2000đ / 1ngay
            double tienphat = double.Parse(txtTienphat.Text);
            double tongtien = double.Parse(txtSongaytre.Text);
            double value_tt = (tongtien * 2000) + tienphat;
            txtTongTienPhaiTra.Text = value_tt.ToString();
            txtaa.Text = txtTongTienPhaiTra.Text;
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView6_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            double a = double.Parse(txtaa.Text);
            double b = double.Parse(txtdatt.Text);
            double conlai = a - b;
            txtTienphat.Text = conlai.ToString();

            String sqlSELECT = "update Muontra set Tienphat = '" + txtTienphat.Text + "' where Madocgia = '" + txtMadocgia.Text + "'";
            SqlCommand com = new SqlCommand(sqlSELECT, con);//thực thi câu lệnh trong SQL
            SqlDataAdapter da = new SqlDataAdapter(com); //vận chuyển dữ liệu
            DataTable dt = new DataTable();//tạo 1 bảng ảo
            da.Fill(dt); //đổ dữ liệu vào bảng ảo
            dataGridView6.DataSource = dt; ;
            getdata();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            this.Close();
            Dispose();
        }
    }
}
