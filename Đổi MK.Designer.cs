namespace Quản_lý_bán_hàng
{
    partial class formdoipass
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnĐổi = new System.Windows.Forms.Button();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.txtnewpass = new System.Windows.Forms.TextBox();
            this.btnthoát = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.Location = new System.Drawing.Point(39, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mật khẩu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.Location = new System.Drawing.Point(39, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu mới";
            // 
            // btnĐổi
            // 
            this.btnĐổi.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnĐổi.Location = new System.Drawing.Point(154, 174);
            this.btnĐổi.Name = "btnĐổi";
            this.btnĐổi.Size = new System.Drawing.Size(75, 23);
            this.btnĐổi.TabIndex = 3;
            this.btnĐổi.Text = "Đổi";
            this.btnĐổi.UseVisualStyleBackColor = true;
            this.btnĐổi.Click += new System.EventHandler(this.btnĐổi_Click_1);
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(154, 34);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(187, 20);
            this.txtTenDN.TabIndex = 4;
            this.txtTenDN.TextChanged += new System.EventHandler(this.txtDN_TextChanged);
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(154, 68);
            this.txtMK.Name = "txtMK";
            this.txtMK.Size = new System.Drawing.Size(187, 20);
            this.txtMK.TabIndex = 5;
            this.txtMK.UseSystemPasswordChar = true;
            // 
            // txtnewpass
            // 
            this.txtnewpass.Location = new System.Drawing.Point(154, 104);
            this.txtnewpass.Name = "txtnewpass";
            this.txtnewpass.Size = new System.Drawing.Size(187, 20);
            this.txtnewpass.TabIndex = 6;
            this.txtnewpass.UseSystemPasswordChar = true;
            // 
            // btnthoát
            // 
            this.btnthoát.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnthoát.Location = new System.Drawing.Point(275, 174);
            this.btnthoát.Name = "btnthoát";
            this.btnthoát.Size = new System.Drawing.Size(75, 23);
            this.btnthoát.TabIndex = 7;
            this.btnthoát.Text = "Thoát";
            this.btnthoát.UseVisualStyleBackColor = true;
            this.btnthoát.Click += new System.EventHandler(this.btnthoát_Click);
            // 
            // formdoipass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 220);
            this.Controls.Add(this.btnthoát);
            this.Controls.Add(this.txtnewpass);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.btnĐổi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "formdoipass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi mật khẩu";
            this.Load += new System.EventHandler(this.formdoipass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnĐổi;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.TextBox txtnewpass;
        private System.Windows.Forms.Button btnthoát;
    }
}