using rạp_chiếu_phim.khách_hàng;
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

namespace rạp_chiếu_phim.đăng_nhập
{
    public partial class Đăng_nhập : Form
    {
        private string captchaText;
        public Đăng_nhập()
        {
            InitializeComponent();
            GenerateCaptcha();

            UC_Đăng_ký ucDangKy = new UC_Đăng_ký();
            ucDangKy.Dock = DockStyle.Fill;

            tabRegister.Controls.Add(ucDangKy);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=shanley\\sqlexpress;Initial Catalog=\"quan ly rap chieu phim\";Integrated Security=True;Encrypt=False");
            string query = "SELECT * FROM KhachHang WHERE TaiKhoan = @username AND MatKhau = @password";
            if (txtCaptcha.Text != captchaText)
            {
                MessageBox.Show("Captcha sai, vui lòng thử lại!", "Thông báo");
                GenerateCaptcha();
                return;
            }

            MessageBox.Show("Đang xử lý đăng nhập...", "Thông báo");
        }

        private void GenerateCaptcha()
        {
            Bitmap bmp = new Bitmap(picCaptcha.Width, picCaptcha.Height);
            Graphics g = Graphics.FromImage(bmp);

            g.Clear(Color.White);

            Random rnd = new Random();
            captchaText = "";
            string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ0123456789";
            for (int i = 0; i < 5; i++)
            {
                captchaText += chars[rnd.Next(chars.Length)];
            }

            using (Font font = new Font("Arial", 20, FontStyle.Bold))
            {
                g.DrawString(captchaText, font, Brushes.Black, new PointF(10, 10));
            }

            // vẽ thêm vài đường loằng ngoằng
            for (int i = 0; i < 5; i++)
            {
                g.DrawLine(Pens.Gray, rnd.Next(0, bmp.Width), rnd.Next(0, bmp.Height),
                                      rnd.Next(0, bmp.Width), rnd.Next(0, bmp.Height));
            }

            picCaptcha.Image = bmp;
        }
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage tabPage = tabControl.TabPages[e.Index];
            Rectangle rect = e.Bounds;

            // nếu tab đang được chọn -> nền đỏ, chữ trắng
            if (e.Index == tabControl.SelectedIndex)
            {
                e.Graphics.FillRectangle(Brushes.Red, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                // tab chưa chọn -> nền trắng, chữ đỏ
                e.Graphics.FillRectangle(Brushes.White, rect);
                TextRenderer.DrawText(e.Graphics, tabPage.Text, this.Font,
                                      rect, Color.Red, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            UserDesign ud = new UserDesign();
            ud.Show();
            this.Hide();
        }
    }
}
