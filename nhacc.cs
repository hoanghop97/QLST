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
    public partial class formnhacc : Form
    {
       
        public formnhacc()
        {
            InitializeComponent();
           
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NL36GS2\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");
        private void nhacc_Load(object sender, EventArgs e)// form load
        {
            
            conn.Open();
            Hienthi();
        }

        private void nhacc_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            conn.Close();
        }

        public void Hienthi()   // phương thức hiển thị
        {
            string sqlselect = "select * from tblNhaCungCap";
            SqlCommand cmd = new SqlCommand(sqlselect, conn); // thực thi lệnh sql trên với kết nối conn
            SqlDataReader dr = cmd.ExecuteReader();// đọc csdl
            DataTable dt = new DataTable();
            dt.Load(dr);           // bảng đọc dữ liệu của sql datareader
            DataGridView.DataSource = dt;       // cho vào data gridview

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlthem = "insert into tblNhaCungCap values ( @maNCC, @tenNCC, @Email, @SDT, @Diachi)";
                SqlCommand cmd = new SqlCommand(sqlthem, conn);  // đọc lệnh
                cmd.Parameters.AddWithValue("maNCC", txtMa.Text);
                cmd.Parameters.AddWithValue("tenNCC", txtTen.Text);
                cmd.Parameters.AddWithValue("Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("Diachi", txtDC.Text);
                cmd.ExecuteNonQuery(); 
                Hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show(" Mã đã tồn tại","Lỗi");
            }

            if (txtMa.Text == "")
            {
                MessageBox.Show("Hãy nhập mã nhà cung cấp ", "Chú ý");
                txtMa.Select();
                return;
            }
            if (txtTen.Text == "")
            {
                MessageBox.Show("Hãy nhập tên nhà cung cấp ", "Chú ý");
                txtTen.Select();
                return;
            }

            if (txtEmail.Text == "")
            {
                MessageBox.Show("Hãy nhập Emial của nhà cung cấp ", "Chú ý");
                txtEmail.Select();
                return;
            }
            
            
            if (txtSDT.Text == "")
            {
                MessageBox.Show("Hãy nhập Emial của nhà cung cấp ", "Chú ý");
                txtSDT.Select();
                return;
            }
            if (txtDC.Text == "")
            {
                MessageBox.Show("Hãy nhập Emial của nhà cung cấp ", "Chú ý");
                txtDC.Select();
                return;
            }
        }

            private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")
            {
                MessageBox.Show("Hãy nhập mã nhà cung cấp ", "Chú ý");
                txtMa.Select();
                return;
            }

                string sqlsua = "Update tblNhaCungCap Set maNCC= @maNCC, tenNCC= @tenNCC, Email= @Email, SDT= @SDT, Diachi=@Diachi where maNCC= @maNCC";
            SqlCommand cmd = new SqlCommand(sqlsua, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maNCC", txtMa.Text);
            cmd.Parameters.AddWithValue("tenNCC", txtTen.Text);
            cmd.Parameters.AddWithValue("Email", txtEmail.Text);
            cmd.Parameters.AddWithValue("SDT", txtSDT.Text);
            cmd.Parameters.AddWithValue("Diachi", txtDC.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Bạn đã sửa thành công", "Thông báo");
            Hienthi();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {

            string sqlxoa = "Delete from tblNhaCungCap where maNCC= @maNCC";
            SqlCommand cmd = new SqlCommand(sqlxoa, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maNCC", txtMa.Text);
            cmd.ExecuteNonQuery();
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Hienthi();

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fNCC = new frmMain();
            fNCC.ShowDialog();
            this.Close();
        }

        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtMa.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();//chạy từ 0 nha..
            txtTen.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtEmail.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            txtSDT.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtDC.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
        }

       
    }
}
