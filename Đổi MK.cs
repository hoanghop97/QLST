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
    public partial class formdoipass : Form
    {
        public formdoipass()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");
     
        private void btnĐổi_Click_1(object sender, EventArgs e)
        {    
            SqlConnection conn = new SqlConnection(@"Data Source=HP\SQLEXPRESS;Initial Catalog=Quanlybanhang;Integrated Security=True");
            string query2 = "Select * from tblDangNhap ";
            SqlDataAdapter sda = new SqlDataAdapter(query2, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            string update = "UPDATE tblDangNhap SET MatKhau='" + txtnewpass.Text + "' WHERE TenDangNhap='" + txtTenDN.Text + "'";
            Boolean kt = false;
           
            for (int i = 0; i < ds.Tables[0].Rows.Count; ++i)
            {
                if ((txtTenDN.Text == ds.Tables[0].Rows[i][0].ToString()) && (txtMK.Text == ds.Tables[0].Rows[i][1].ToString()))
                {
                    kt = true;
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đổi mật khẩu thành công!");
                    //this.Close();//tất cả form đã đóng..đóng thêm cái này là đóng chương trình luôn
                }
            }

            if (kt == false)
                MessageBox.Show("Bạn nhập sai tên đăng nhập hoặc mật khẩu!");
        
            
            if (txtMK.TextLength == 0) MessageBox.Show("Mật khẩu không để trống");
            else if (txtnewpass.TextLength == 0) MessageBox.Show("Nhập lại Pass Mới.");
           
         

            
        }

        private void btnthoát_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmMain fhdmk = new frmMain();
            fhdmk.ShowDialog();
            this.Close();
        }
       
        private void txtDN_TextChanged(object sender, EventArgs e)
        {

        }

        private void formdoipass_Load(object sender, EventArgs e)
        {
            conn.Open();
            Formdangnhap dn = new Formdangnhap();
           
        }
        

    }
} 