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
    public partial class UC_Đăng_ký : UserControl
    {
        string conn = @"Data Source=shanley\sqlexpress;Initial Catalog=""quan ly rap chieu phim"";Integrated Security=True;Encrypt=False";
        private string captchaText;

        public UC_Đăng_ký()
        {
            InitializeComponent();
            GenerateCaptcha();

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

        // Nút reload captcha
        private void btnReload_Click(object sender, EventArgs e)
        {
            GenerateCaptcha();
        }

        // Kiểm tra captcha khi người dùng nhập
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Hãy điền thông tin vào tên đăng nhập và mật khẩu");
                return;
            }
            else
            {
                using (SqlConnection connect = new SqlConnection(conn))
                {
                    connect.Open();
                    string checkUsername = "SELECT COUNT(*) FROM [dbo].[Tài khoản] WHERE TenDangNhap = @username";
                    using (SqlCommand CheckUser = new SqlCommand(checkUsername, connect))
                    {
                        CheckUser.Parameters.AddWithValue("@username", txtName.Text.Trim());
                        int count = (int)CheckUser.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Đăng ký thất bại, tài khoản đã tồn tại!");
                            return;
                        }
                        else
                        {
                            string insertData = "INSERT INTO [dbo].[Tài khoản] (TenDangNhap, Pass, Email, SDT) " + "VALUES (@username, @pass, @email, @phone)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                cmd.Parameters.AddWithValue("@username", txtName.Text.Trim());
                                cmd.Parameters.AddWithValue("@pass", txtPassword.Text.Trim());
                                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                                cmd.Parameters.AddWithValue("@phone", txtPhone.Text.Trim());


                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Đăng ký thành công!");


                            }
                        }
                    }
                }
            }


        }

        private bool ValidateInput()
        {
            if (cbYear.SelectedItem == null || cbMonth.SelectedItem == null || cbDay.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn đầy đủ Ngày / Tháng / Năm sinh!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại!");
                txtPhone.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email!");
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!");
                txtPassword.Focus();
                return false;
            }

            if (cbDay.SelectedIndex == -1 || cbMonth.SelectedIndex == -1 || cbYear.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh!");
                return false;
            }

            if (!rbMale.Checked && !rbFemale.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCaptcha.Text))
            {
                MessageBox.Show("Vui lòng nhập captcha!");
                txtCaptcha.Focus();
                return false;
            }

            if (txtCaptcha.Text.Trim() != captchaText)
            {
                MessageBox.Show("Sai captcha, vui lòng thử lại!");
                GenerateCaptcha();
                txtCaptcha.Clear();
                txtCaptcha.Focus();
                return false;
            }

            if (!chkAgree4.Checked || !chkAgree2.Checked || !chkAgree3.Checked)
            {
                MessageBox.Show("Bạn phải đồng ý với các điều khoản trước khi đăng ký!");
                return false;
            }

            return true;
        }

        private void reg_showPass_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = reg_showPass.Checked ? '\0' : '*';
        }
    }
}