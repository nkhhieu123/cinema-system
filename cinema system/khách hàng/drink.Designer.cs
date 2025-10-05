namespace rạp_chiếu_phim.khách_hàng
{
    partial class drink
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
            this.flpMonAn = new System.Windows.Forms.FlowLayoutPanel();
            this.order_thức_uống1 = new rạp_chiếu_phim.khách_hàng.Order_thức_uống();
            this.flpMonAn.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMonAn
            // 
            this.flpMonAn.AutoScroll = true;
            this.flpMonAn.Controls.Add(this.order_thức_uống1);
            this.flpMonAn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpMonAn.Location = new System.Drawing.Point(0, 0);
            this.flpMonAn.Name = "flpMonAn";
            this.flpMonAn.Size = new System.Drawing.Size(1291, 698);
            this.flpMonAn.TabIndex = 0;
            // 
            // order_thức_uống1
            // 
            this.order_thức_uống1.BackColor = System.Drawing.Color.White;
            this.order_thức_uống1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.order_thức_uống1.Location = new System.Drawing.Point(3, 3);
            this.order_thức_uống1.Name = "order_thức_uống1";
            this.order_thức_uống1.Size = new System.Drawing.Size(697, 215);
            this.order_thức_uống1.TabIndex = 0;
            // 
            // drink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 698);
            this.Controls.Add(this.flpMonAn);
            this.Name = "drink";
            this.Text = "drink";
            this.flpMonAn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMonAn;
        private Order_thức_uống order_thức_uống1;
    }
}