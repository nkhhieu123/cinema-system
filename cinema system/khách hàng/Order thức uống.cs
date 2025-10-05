using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rạp_chiếu_phim.khách_hàng
{
    public partial class Order_thức_uống : UserControl
    {
        private int soLuong = 0;
        private int gia = 0;
        public Order_thức_uống()
        {
            InitializeComponent();
        }
        public void SetThongTin(string ten, string moTa, int gia, Image anh)
        {
            lblTenMon.Text = ten;
            lblMoTa.Text = moTa;
            lblGia.Text = $"Giá: {gia:N0} đ";
            pictureBoxMon.Image = anh;
            this.gia = gia;
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            soLuong++;
            txtSoLuong.Text = soLuong.ToString();
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {
            if (soLuong > 0)
                soLuong--;
            txtSoLuong.Text = soLuong.ToString();
        }

        public int LaySoLuong()
        {
            return soLuong;
        }

    }
}
