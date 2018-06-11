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
    public partial class formMatHang : Form
    {
        
        public formMatHang()
        {
            InitializeComponent();
            
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NL36GS2\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");

        private void formMatHang_Load(object sender, EventArgs e)
        {
            conn.Open();
            Hienthi();
        }

        private void formMatHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        public void Hienthi()   // phương thức hiển thị
        {
            string sqlselect = "select * from tblMatHang";
            SqlCommand cmd = new SqlCommand(sqlselect, conn); // thực thi lệnh sql trên với kết nối conn
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);           // bảng đọc dữ liệu của sql datareader
            DataGridView.DataSource = dt;       // cho vào data gridview

        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlthem = "insert into tblMatHang values ( @maMH, @tenMH, @maNCC, @NSX, @Soluong, @Giaban)";
                SqlCommand cmd = new SqlCommand(sqlthem, conn);  // đọc lệnh
                cmd.Parameters.AddWithValue("maMH", txtmaMH.Text);
                cmd.Parameters.AddWithValue("tenMH", txttenMH.Text);
                cmd.Parameters.AddWithValue("maNCC", txtmaNCC.Text);
                cmd.Parameters.AddWithValue("NSX", txtNSX.Text);
                cmd.Parameters.AddWithValue("Soluong", txtSL.Text);
                cmd.Parameters.AddWithValue("Giaban", txtGiaban.Text);
                cmd.ExecuteNonQuery();
                Hienthi();
            }
            catch (Exception)
            {
                MessageBox.Show(" Mã đã tồn tại", "Lỗi");
            }

            if (txtmaMH.Text == "")
            {
                MessageBox.Show("Hãy nhập mã mặt hàng ", "Chú ý");
                txtmaMH.Select();
                return;
            }
            if (txttenMH.Text == "")
            {
                MessageBox.Show("Hãy nhập tên mặt hàng ", "Chú ý");
                txttenMH.Select();
                return;
            }

            if (txtmaNCC.Text == "")
            {
                MessageBox.Show("Hãy nhập mã của nhà cung cấp ", "Chú ý");
                txtmaNCC.Select();
                return;
            }
            if (txtNSX.Text == "")
            {
                MessageBox.Show("Hãy nhập tên nước sản xuất ", "Chú ý");
                txtNSX.Select();
                return;
            }
            if (txtSL.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng mặt hàng  ", "Chú ý");
                txtSL.Select();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Hãy nhập giá bán của mặt hàng ", "Chú ý");
                txtGiaban.Select();
                return;
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (txtmaMH.Text == "")
            {
                MessageBox.Show("Hãy nhập mã mặt hàng ", "Chú ý");
                txtmaMH.Select();
                return;
            }
            if (txttenMH.Text == "")
            {
                MessageBox.Show("Hãy nhập tên mặt hàng ", "Chú ý");
                txttenMH.Select();
                return;
            }

            if (txtmaNCC.Text == "")
            {
                MessageBox.Show("Hãy nhập mã của nhà cung cấp ", "Chú ý");
                txtmaNCC.Select();
                return;
            }
            if (txtNSX.Text == "")
            {
                MessageBox.Show("Hãy nhập tên nước sản xuất ", "Chú ý");
                txtNSX.Select();
                return;
            }
            if (txtSL.Text == "")
            {
                MessageBox.Show("Hãy nhập số lượng mặt hàng  ", "Chú ý");
                txtSL.Select();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Hãy nhập giá bán của mặt hàng ", "Chú ý");
                txtGiaban.Select();
                return;
            }

            string sqlsua = "Update tblMatHang Set maMH= @maMH, tenMH= @tenMH, maNCC= @maNCC, NSX= @NSX, Soluong=@Soluong, Giaban= @Giaban where maMH= @maMH";
            SqlCommand cmd = new SqlCommand(sqlsua, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maMH", txtmaMH.Text);
            cmd.Parameters.AddWithValue("tenMH", txttenMH.Text);
            cmd.Parameters.AddWithValue("maNCC", txtmaNCC.Text);
            cmd.Parameters.AddWithValue("NSX", txtNSX.Text);
            cmd.Parameters.AddWithValue("Soluong", txtSL.Text);
            cmd.Parameters.AddWithValue("Giaban", txtGiaban.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show(" Bạn đã sửa thành công", "Thông báo");
            Hienthi();
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            string sqlxoa = "Delete from tblMatHang where maMH= @maMH";
            SqlCommand cmd = new SqlCommand(sqlxoa, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("maMH", txtmaMH.Text);
            cmd.ExecuteNonQuery();
            if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Hienthi();

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fmh = new frmMain();
            fmh.ShowDialog();
            this.Close();
           
        }

        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaMH.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();//chạy từ 0 nha..
            txttenMH.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtmaNCC.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            txtNSX.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            txtSL.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            txtGiaban.Text = DataGridView.Rows[dong].Cells[5].Value.ToString();
        }
    }
    
}
