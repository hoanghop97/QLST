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
    public partial class formHDB : Form
    {
        public formHDB()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-NL36GS2\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");
        private void formHDB_Load(object sender, EventArgs e)
        {
            conn.Open();
            Hienthi();
            comboboxNV();
            comboboxMH();

            comboboxKH();



        }

        private void formHDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            conn.Close();
        }

        public void Hienthi()   // phương thức hiển thị
        {     // vận chuyển dữ liệu lên datatable  daHDN
            string sql = " SELECT * from tblHoaDonBan";
            SqlDataAdapter ad = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
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
        private void comboboxKH()
        {

            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from tblKhachHang ";
            command.Connection = conn;
            SqlDataReader reader = command.ExecuteReader();
            cbmaKH.Items.Clear();
            while (reader.Read())
            {
                string maKH = reader.GetString(0);
                cbmaKH.Items.Add(maKH);
            }
            reader.Close();
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
            if (cbmaMH.Text == "")
            {
                MessageBox.Show("Hãy chọn mã mặt hàng", "Chú ý!");
                cbmaMH.Select();
                return;
            }

            if (dtpNB.Text == "") MessageBox.Show("Ngày bán không được để trống", "Chú ý");
            if (txtSL.TextLength == 0) MessageBox.Show("Số lượng không được để trống", "Chú ý");
            if (cbmaKH.Text == "")
            {
                MessageBox.Show("Mã khách hàng không được để trống", "Chú ý");
                cbmaMH.Select();
                return;
            }
            if (double.Parse(txtSL.Text) <= 0)
            {
                MessageBox.Show("Số lượng không được nhỏ hơn 0!");
                txtSL.Select();
                return;
            }
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                txtGiaban.Select();
                return;
            }

            try
            {

                int SoLuong = Int32.Parse(txtSL.Text);
                int GiaBan = Int32.Parse(txtGiaban.Text);
                int TongTien = Int32.Parse(txtSL.Text) * Int32.Parse(txtGiaban.Text);
                txtTongtien.Text = TongTien.ToString();
                string NgayBan = dtpNB.Value.ToString("yyyy-MM-dd");
                string insert = "insert  tblHoaDonBan values(N'" + txtmaHD.Text + "',N'" + cbmaNV.Text + "',N'" + cbmaKH.Text + "' ,N'" + cbmaMH.Text + "',N'" + NgayBan + "',N'" + txtSL.Text + "',N'" + txtGiaban.Text + "',N'" + txtTongtien.Text + "' )";
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.ExecuteNonQuery();
                String select = "update tblMatHang set SoLuong= SoLuong-" + txtSL.Text + " where MaMH=N'" + cbmaMH.Text + "'";// cập nhật lại số lượng bảng mặt hàng
                SqlCommand cmd2 = new SqlCommand(select, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Thêm thành công.");
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối");
            }




        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            if (cbmaNV.Text == "")
            {
                MessageBox.Show("Hãy chọn mã nhân viên", "Chú ý!");
                cbmaNV.Select();
                return;
            }
            if (cbmaKH.Text == "")
            {
                MessageBox.Show("Hãy chọn mã khách hàng", "Chú ý!");
                cbmaKH.Select();
                return;
            }

            if (dtpNB.Text == "") MessageBox.Show("Ngày bán không được để trống", "Chú ý");
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
            if (txtGiaban.Text == "")
            {
                MessageBox.Show("Hãy nhập đơn giá!", "Chú ý!");
                txtGiaban.Select();
                return;
            }
            try
            {
                int SoLuong = Int32.Parse(txtSL.Text);
                int GiaBan = Int32.Parse(txtGiaban.Text);
                int TongTien = Int32.Parse(txtSL.Text) * Int32.Parse(txtGiaban.Text);
                txtTongtien.Text = TongTien.ToString();
                string sql = "update  [tblHoaDonBan] set MaNV= @MaNV, MaKH= @MaKH,MaMH= @MaMH, NgayBan= @NgayBan, SoLuong= @SoLuong, GiaBan= @GiaBan, TongTien= @TongTien where MaHDB= @MaHDB";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("MaHDB", txtmaHD.Text);
                cmd.Parameters.AddWithValue("MaNV", cbmaNV.Text);
                cmd.Parameters.AddWithValue("MaKH", cbmaKH.Text);
                cmd.Parameters.AddWithValue("MaMH", cbmaMH.Text);
                string NgayBan = dtpNB.Value.ToString("yyyy-MM-dd");
                cmd.Parameters.AddWithValue("NgayBan", NgayBan);
                cmd.Parameters.AddWithValue("SoLuong", txtSL.Text);
                cmd.Parameters.AddWithValue("GiaBan", txtGiaban.Text);
                cmd.Parameters.AddWithValue("TongTien", txtTongtien.Text);
                cmd.ExecuteNonQuery();
                String select = "update tblMatHang set SoLuong= SoLuong-" + txtSL.Text + " where MaMH=N'" + cbmaMH.Text + "'";// cập nhật lại số lượng bảng mặt hàng
                SqlCommand cmd2 = new SqlCommand(select, conn);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Sửa thành công", " Thông báo");
                Hienthi();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin ", " Chú ý");
            }

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            if (txtmaHD.TextLength == 0)
                MessageBox.Show("Bạn cần nhập mã để xóa", "Chú ý");
            else
            {
                string sqlxoa = "Delete from tblHoaDonBan where maHDB= @maHDB";
                SqlCommand cmd = new SqlCommand(sqlxoa, conn);  // đọc lệnh
                cmd.Parameters.AddWithValue("maHDB", txtmaHD.Text);
                cmd.ExecuteNonQuery();
                if (MessageBox.Show("Bạn chắc chắn muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    Hienthi();
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fHDB = new frmMain();
            fHDB.ShowDialog();
            this.Close();
        }
        /*
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        { //do cái này sinh lỗi..
            int dong = e.RowIndex;
            txtmaHD.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            cbmaNV.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            cbmaKH.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            cbmaMH.Text = dataGridView1.Rows[dong].Cells[4].Value.ToString();
            dtpNB.Text = dataGridView1.Rows[dong].Cells[5].Value.ToString();//dtpNB.Text cái này kiểu datetime nên 
            txtSL.Text = dataGridView1.Rows[dong].Cells[6].Value.ToString();
            txtGiaban.Text = dataGridView1.Rows[dong].Cells[7].Value.ToString();
            txtTongtien.Text = dataGridView1.Rows[dong].Cells[8].Value.ToString();
        }*/

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
                txtGiaban.Text = dr["GiaBan"].ToString();
            }


        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int dong = e.RowIndex;
            txtmaHD.Text = dataGridView1.Rows[dong].Cells[0].Value.ToString();
            cbmaNV.Text = dataGridView1.Rows[dong].Cells[1].Value.ToString();
            cbmaKH.Text = dataGridView1.Rows[dong].Cells[2].Value.ToString();
            cbmaMH.Text = dataGridView1.Rows[dong].Cells[3].Value.ToString();
            dtpNB.Text = dataGridView1.Rows[dong].Cells[4].Value.ToString();
            txtSL.Text = dataGridView1.Rows[dong].Cells[5].Value.ToString();
            txtGiaban.Text = dataGridView1.Rows[dong].Cells[6].Value.ToString();
            txtTongtien.Text = dataGridView1.Rows[dong].Cells[7].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0) MessageBox.Show("Hãy nhập mã hóa đơn để tìm kiếm", "Chú ý");
            string sqlTimkiem = " Select* from tblHoaDonBan where MaHDB= @MaHDB ";
            SqlCommand cmd = new SqlCommand(sqlTimkiem, conn);  // đọc lệnh
            cmd.Parameters.AddWithValue("MaHDB", textBox1.Text);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);           // bảng đọc dữ liệu của sql datareader
            dataGridView1.DataSource = dt;
        }
    }
}
