﻿using rạp_chiếu_phim.đăng_nhập;
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
    public partial class UserDesign : Form
    {
        private DateTime startDate = DateTime.Today;
        private Button selectedButton = null;
        public UserDesign()
        {
            InitializeComponent();
            GenerateDateButtons(startDate);
        }
        private void GenerateDateButtons(DateTime start)
        {
            flowLayoutPanelDates.Controls.Clear();
            int numDays = 10; // số ngày hiển thị

            for (int i = 0; i < numDays; i++)
            {
                DateTime d = start.AddDays(i);
                Button btn = new Button();
                btn.Width = 80;
                btn.Height = 80;
                btn.Margin = new Padding(5);
                btn.BackColor = Color.WhiteSmoke;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.Tag = d;
                btn.Click += Btn_Click;
                btn.Text = $"{d:MM}\n{d:ddd}\n{d:dd}";
                btn.TextAlign = ContentAlignment.MiddleCenter;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Regular);

                flowLayoutPanelDates.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (selectedButton != null)
                selectedButton.BackColor = Color.WhiteSmoke; // reset màu

            selectedButton = sender as Button;
            selectedButton.BackColor = Color.LightBlue; // chọn ngày
            DateTime selectedDate = (DateTime)selectedButton.Tag;
        }

        private void dndk_Click(object sender, EventArgs e)
        {
            Đăng_nhập dn = new Đăng_nhập();
            dn.Show();
            this.Hide();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            phòng_chiếu pc = new phòng_chiếu();
            pc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            phòng_chiếu pc = new phòng_chiếu();
            pc.Show();
            this.Hide();
        }
    }
}
