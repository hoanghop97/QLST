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

namespace Quản_lý_bán_hàng
{
    public partial class formNhanvien : Form
    {
        public formNhanvien()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NL36GS2\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");

        private void fromNhanvien_Load(object sender, EventArgs e)
        {
            conn.Open();
            Hienthi();
        }

        private void fromNhanvien_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        public void Hienthi()   // phương thức hiển thị
        {
            string sqlselect = "select * from tblNhanVien";
            SqlCommand cmd = new SqlCommand(sqlselect, conn); // thực thi lệnh sql trên với kết nối conn
            SqlDataReader dr = cmd.ExecuteReader();// đọc csdl
            DataTable dt = new DataTable();
            dt.Load(dr);           // bảng đọc dữ liệu của sql datareader
            dataGridView1.DataSource = dt;       // cho vào data gridview

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {

                string sqlthem = "insert into tblNhanVien values ( @maNV, @tenNV,  @SDT,@Diachi,@Luong )";
                SqlCommand cmd = new SqlCommand(sqlthem, conn);  // đọc lệnh
                cmd.Parameters.AddWithValue("maNV", txtmaNV.Text);
                cmd.Parameters.AddWithValue("tenNV", txtTenNV.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("Diachi", txtDiachi.Text);
                
                cmd.Parameters.AddWithValue("Luong", txtLuong.Text);
                cmd.ExecuteNonQuery();
                Hienthi();
            }
            catch(Exception)
            {
                MessageBox.Show(" Mã đã tồn tại", "Lỗi");
            }
            
            

            if (txtmaNV.Text == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên ", "Chú ý");
                txtmaNV.Select();
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Hãy nhập tên nhân viên ", "Chú ý");
                txtTenNV.Select();
                return;
            }

            if (txtSDT.Text == "")
            {
                MessageBox.Show("Hãy nhập SDT của nhân viên ", "Chú ý");
                txtSDT.Select();
                return;
            }


           
            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ của nhân viên ", "Chú ý");
                txtDiachi.Select();
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmaNV.Text == "")
            {
                MessageBox.Show("Hãy nhập mã nhân viên ", "Chú ý");
                txtmaNV.Select();
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Hãy nhập tên nhân viên ", "Chú ý");
                txtTenNV.Select();
                return;
            }

            if (txtSDT.Text == "")
            {
                MessageBox.Show("Hãy nhập SDT của nhân viên ", "Chú ý");
                txtSDT.Select();
                return;
            }



            if (txtDiachi.Text == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ của nhân viên ", "Chú ý");
                txtDiachi.Select();
                return;
            }
            string sqlsua = "Update tblNhanVien Set maNV= @maNV, tenNV= @tenNV,  SDT= @SDT,Diachi=@Diachi , Luong= @Luong  where maNV= @maNV";
            SqlCommand cmd = new SqlCommand(sqlsua, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maNV", txtmaNV.Text);
            cmd.Parameters.AddWithValue("tenNV", txtTenNV.Text);
            cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("Diachi", txtDiachi.Text);
           
            cmd.Parameters.AddWithValue("Luong", txtLuong.Text);
            cmd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Bạn đã sửa thành công", "Thông báo");
            Hienthi();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sqlxoa = "Delete from tblNhanVien where maNV= @maNV";
            SqlCommand cmd = new SqlCommand(sqlxoa, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maNV", txtmaNV.Text);
            cmd.ExecuteNonQuery();
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Hienthi();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fnv = new frmMain();
            fnv.ShowDialog();
            this.Close();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaNV.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();//chạy từ 0 nha..
            txtTenNV.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            txtDiachi.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            txtLuong.Text = dataGridView1.Rows[dong].Cells[4].Value.ToString();
        }
    }
}