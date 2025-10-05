namespace rạp_chiếu_phim.khách_hàng
{
    partial class Order_thức_uống
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

        #region #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBoxMon = new System.Windows.Forms.PictureBox();
            this.lblTenMon = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblGia = new System.Windows.Forms.Label();
            this.btnGiam = new System.Windows.Forms.Button();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.btnTang = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMon)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxMon
            // 
            this.pictureBoxMon.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxMon.Name = "pictureBoxMon";
            this.pictureBoxMon.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxMon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMon.TabIndex = 0;
            this.pictureBoxMon.TabStop = false;
            // 
            // lblTenMon
            // 
            this.lblTenMon.AutoSize = true;
            this.lblTenMon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTenMon.Location = new System.Drawing.Point(170, 10);
            this.lblTenMon.Name = "lblTenMon";
            this.lblTenMon.Size = new System.Drawing.Size(116, 25);
            this.lblTenMon.TabIndex = 1;
            this.lblTenMon.Text = "Tên món ăn";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMoTa.Location = new System.Drawing.Point(170, 40);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(400, 80);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả món ăn hiển thị ở đây...";
            // 
            // lblGia
            // 
            this.lblGia.AutoSize = true;
            this.lblGia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblGia.ForeColor = System.Drawing.Color.DarkRed;
            this.lblGia.Location = new System.Drawing.Point(170, 130);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(72, 23);
            this.lblGia.TabIndex = 3;
            this.lblGia.Text = "Giá: 0 đ";
            // 
            // btnGiam
            // 
            this.btnGiam.Location = new System.Drawing.Point(400, 130);
            this.btnGiam.Name = "btnGiam";
            this.btnGiam.Size = new System.Drawing.Size(25, 25);
            this.btnGiam.TabIndex = 4;
            this.btnGiam.Text = "-";
            this.btnGiam.UseVisualStyleBackColor = true;
            this.btnGiam.Click += new System.EventHandler(this.btnGiam_Click);
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(430, 130);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(40, 22);
            this.txtSoLuong.TabIndex = 5;
            this.txtSoLuong.Text = "0";
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTang
            // 
            this.btnTang.Location = new System.Drawing.Point(475, 130);
            this.btnTang.Name = "btnTang";
            this.btnTang.Size = new System.Drawing.Size(25, 25);
            this.btnTang.TabIndex = 6;
            this.btnTang.Text = "+";
            this.btnTang.UseVisualStyleBackColor = true;
            this.btnTang.Click += new System.EventHandler(this.btnTang_Click);
            // 
            // Order_thức_uống
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBoxMon);
            this.Controls.Add(this.lblTenMon);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.lblGia);
            this.Controls.Add(this.btnGiam);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.btnTang);
            this.Name = "Order_thức_uống";
            this.Size = new System.Drawing.Size(572, 174);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxMon;
        private System.Windows.Forms.Label lblTenMon;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblGia;
        private System.Windows.Forms.Button btnGiam;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Button btnTang;
    }
}