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
    public partial class formHDN : Form
    {

        public formHDN()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NL36GS2\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");

        private void formHDN_Load(object sender, EventArgs e)
        {
            conn.Open();
            Hienthi();
            comboboxNV();
            
            comboboxMH();
            

        }

        private void formHDN_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }
        public void Hienthi()   // phương thức hiển thị
        {     // vận chuyển dữ liệu lên datatable  daHDN
            string sql = " SELECT * from tblHoaDonNhap";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            DataGridView.DataSource = dt;
        }
        private void comboboxNV()
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from tblNhanVien ";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            cbmaNV.Items.Clear();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                cbmaNV.Items.Add(maNV);
            }
            reader.Close();

        }

       
        private void comboboxMH()
        {

            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from tblMatHang  ";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cbmaMH.Items.Add(dr["MaMH"].ToString());
            }
        }



        private void btnthem_Click(object sender, EventArgs e)
        {
            if (txtmaHD.TextLength == 0) MessageBox.Show("Mã Hóa Đơn không để trống");

            if (cbmaNV.Text == "")
            {
                MessageBox.Show("Hãy chọn mã nhân viên", "Chú ý!");
                cbmaNV.Select();
                return;
            }
            

            if (pckNN.Text == "") MessageBox.Show("Ngày nhập không được để trống", "Chú ý");
            if (txtSL.TextLength == 0) MessageBox.Show("Số lượng không được để trống", "Chú ý");
            if (cbmaMH.Text == "")
            {
                MessageBox.Show("Mã mặt hàng không được để trống", "Chú ý");
                cbmaMH.Select();
                return;
            }
            if (double.Parse(txtSL.Text) <= 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                txtSL.Select();
                return;
            }
            if (txtgianhap.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                txtgianhap.Select();
                return;
            }

            try
            {
                
                int SoLuong = Int32.Parse(txtSL.Text);
                int Gianhap = Int32.Parse(txtgianhap.Text);
                int TongTien = Int32.Parse(txtSL.Text) * Int32.Parse(txtgianhap.Text);
                txtTongtien.Text = TongTien.ToString();
                string NgayNhap = pckNN.Value.ToString("yyyy-MM-dd");
                string insert = "insert  tblHoaDonNhap values(N'" + txtmaHD.Text + "',N'" + cbmaNV.Text + "',N'" + txtmaNCC.Text + "' ,N'" + cbmaMH.Text + "',N'" + NgayNhap + "',N'" + txtSL.Text + "',N'" + txtgianhap.Text + "',N'" + txtTongtien.Text + "' )";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();

                String select = "update tblMatHang set SoLuong= SoLuong+" + txtSL.Text + " where MaMH=N'" + cbmaMH.Text + "'";// cập nhật lại số lượng bảng mặt hàng
                SqlCommand cmd2 = new SqlCommand(select, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công.");
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối!!");
            }

        }
      
        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtmaHD.TextLength == 0)
                MessageBox.Show("Bạn cần nhập mã để xóa","Chú ý");
            else
            {
                string sqlxoa = "Delete from tblHoaDonNhap where maHDN= @maHDN";
                SqlCommand cmd = new SqlCommand(sqlxoa, conn);  // đọc lệnh
                cmd.Parameters.AddWithValue("maHDN", txtmaHD.Text);
                cmd.ExecuteNonQuery();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Hienthi();
            }
            
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fhdn = new frmMain();
            fhdn.ShowDialog();
            this.Close();
        }
        /*
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaHD.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            cbmaNV.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            txtmaNCC.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            cbmaMH.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            pckNN.Text = DataGridView.Rows[dong].Cells[5].Value.ToString();
            txtSL.Text = DataGridView.Rows[dong].Cells[6].Value.ToString();
            txtgianhap.Text = DataGridView.Rows[dong].Cells[7].Value.ToString();
            txtTongtien.Text= DataGridView.Rows[dong].Cells[8].Value.ToString();
            //thay đổi sự kiện là ok đổi thành row enter..ukm

        }
        */
        private void btnsua_Click(object sender, EventArgs e)
        {
            if (cbmaNV.Text == "")
            {
                MessageBox.Show("Hãy chọn mã nhân viên", "Chú ý!");
                cbmaNV.Select();
                return;
            }
           

            if (pckNN.Text == "") MessageBox.Show("Ngày nhập không được để trống", "Chú ý");
            if (txtSL.TextLength == 0) MessageBox.Show("Số lượng không được để trống", "Chú ý");
            if (cbmaMH.Text == "")
            {
                MessageBox.Show("Mã mặt hàng không được để trống", "Chú ý");
                cbmaMH.Select();
                return;
            }
            if (double.Parse(txtSL.Text) <= 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                txtSL.Select();
                return;
            }
            if (txtgianhap.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                txtgianhap.Select();
                return;
            }
            try
            {
                int SoLuong = Int32.Parse(txtSL.Text);
                int Gianhap = Int32.Parse(txtgianhap.Text);
                int TongTien = Int32.Parse(txtSL.Text) * Int32.Parse(txtgianhap.Text);
                txtTongtien.Text = TongTien.ToString();
                string sql = "update  [tblHoaDonNhap] set MaNV= @MaNV, MaNCC= @MaNCC,MaMH= @MaMH, Ngaynhap= @Ngaynhap, SoLuong= @SoLuong, GiaNhap= @GiaNhap, TongTien= @TongTien where MaHDN= @MaHDN";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("MaHDN", txtmaHD.Text);
                cmd.Parameters.AddWithValue("MaNV", cbmaNV.Text);
                cmd.Parameters.AddWithValue("MaNCC", txtmaNCC.Text);
                cmd.Parameters.AddWithValue("MaMH", cbmaMH.Text);
                string NgayNhap = pckNN.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("Ngaynhap", NgayNhap);
                cmd.Parameters.AddWithValue("SoLuong", txtSL.Text);
                cmd.Parameters.AddWithValue("GiaNhap", txtgianhap.Text);
                cmd.Parameters.AddWithValue("TongTien", txtTongtien.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công", " Thông báo");
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin ", " Chú ý");
            }

            
                
        }

        private void cbmaMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlCommand command = conn.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from tblMatHang where MaMH = '" + cbmaMH.SelectedItem.ToString() + "'  ";
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(command);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                txtmaNCC.Text = dr["MaNCC"].ToString();
            }

        }

        private void DataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaHD.Text = DataGridView.Rows[dong].Cells[0].Value.ToString();//chạy từ 0 nha..
            cbmaNV.Text = DataGridView.Rows[dong].Cells[1].Value.ToString();
            txtmaNCC.Text = DataGridView.Rows[dong].Cells[2].Value.ToString();
            cbmaMH.Text = DataGridView.Rows[dong].Cells[3].Value.ToString();
            pckNN.Text = DataGridView.Rows[dong].Cells[4].Value.ToString();
            txtSL.Text = DataGridView.Rows[dong].Cells[5].Value.ToString();
            txtgianhap.Text = DataGridView.Rows[dong].Cells[6].Value.ToString();
            txtTongtien.Text = DataGridView.Rows[dong].Cells[7].Value.ToString();

        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) MessageBox.Show("Mã mặt hàng không để trống", "Chú ý");
            string sqlTimkiem = " Select* from tblHoaDonNhap where MaHDN= @MaHDN ";
            SqlCommand cmd = new SqlCommand(sqlTimkiem, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("MaHDN", textBox1.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);           // bảng đọc dữ liệu của sql datareader
            DataGridView.DataSource = dt;

        }
    }
    

}   
    
