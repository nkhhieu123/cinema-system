using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace rạp_chiếu_phim
{
    public partial class CarouselControl : UserControl
    {
        List<Image> slides = new List<Image>();
        PictureBox pbCurrent, pbNext;
        Timer animTimer, autoplay;
        int currentIndex = 0;
        int animSpeed = 20; // pixels/tick
        bool isAnimating = false;

        public CarouselControl()
        {
            InitializeComponent();
            this.Width = 800;
            this.Height = 420;
            InitCarousel();
        }

        public void LoadSlides(params string[] paths)
        {
            foreach (var p in paths)
            {
                if (System.IO.File.Exists(p))
                    slides.Add(Image.FromFile(p));
            }

            if (slides.Count > 0)
                pbCurrent.Image = slides[currentIndex];
        }

        void InitCarousel()
        {
            // PictureBox hiện tại
            pbCurrent = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage, // full control
                Dock = DockStyle.Fill
            };
            this.Controls.Add(pbCurrent);

            // PictureBox kế tiếp
            pbNext = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill,
                Visible = false
            };
            this.Controls.Add(pbNext);

            // Timer animation
            animTimer = new Timer { Interval = 15 };
            animTimer.Tick += AnimTimer_Tick;

            // Timer autoplay
            autoplay = new Timer { Interval = 4000 }; // 4 giây tự chuyển
            autoplay.Tick += (s, e) => { if (!isAnimating) ShowNext(); };
            autoplay.Start();

            // ==== Nút Next ====
            Button btnNext = new Button
            {
                Text = ">",
                Width = 40,
                Height = 40,
                BackColor = Color.FromArgb(180, 0, 0, 0), // nền mờ
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.Anchor = AnchorStyles.Right;
            btnNext.Left = this.ClientSize.Width - btnNext.Width - 10;
            btnNext.Top = this.Height / 2 - btnNext.Height / 2;
            btnNext.Click += (s, e) => { if (!isAnimating) ShowNext(); };
            this.Controls.Add(btnNext);

            // ==== Nút Prev ====
            Button btnPrev = new Button
            {
                Text = "<",
                Width = 40,
                Height = 40,
                BackColor = Color.FromArgb(180, 0, 0, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnPrev.FlatAppearance.BorderSize = 0;
            btnPrev.Anchor = AnchorStyles.Left;
            btnPrev.Left = 10;
            btnPrev.Top = this.Height / 2 - btnPrev.Height / 2;
            btnPrev.Click += (s, e) => { if (!isAnimating) ShowPrev(); };
            this.Controls.Add(btnPrev);

            // Đảm bảo nút nằm trên cùng (không bị PictureBox che)
            btnNext.BringToFront();
            btnPrev.BringToFront();

            this.Resize += (s, e) =>
            {
                btnNext.Left = this.ClientSize.Width - btnNext.Width - 10;
                btnNext.Top = this.ClientSize.Height / 2 - btnNext.Height / 2;

                btnPrev.Top = this.ClientSize.Height / 2 - btnPrev.Height / 2;
            };
        }


        public void ShowNext()
        {
            if (slides.Count == 0) return;
            isAnimating = true;
            int next = (currentIndex + 1) % slides.Count;
            pbNext.Image = slides[next];
            pbNext.Left = this.Width;
            pbNext.Visible = true;
            animTimer.Tag = +1;
            animTimer.Start();
        }

        public void ShowPrev()
        {
            if (slides.Count == 0) return;
            isAnimating = true;
            int prev = (currentIndex - 1 + slides.Count) % slides.Count;
            pbNext.Image = slides[prev];
            pbNext.Left = -this.Width;
            pbNext.Visible = true;
            animTimer.Tag = -1;
            animTimer.Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            int dir = (int)animTimer.Tag;
            pbCurrent.Left -= dir * animSpeed;
            pbNext.Left -= dir * animSpeed;

            if ((dir > 0 && pbNext.Left <= 0) || (dir < 0 && pbNext.Left >= 0))
            {
                animTimer.Stop();
                pbNext.Left = 0;
                pbCurrent.Image = pbNext.Image;
                pbCurrent.Left = 0;
                pbNext.Visible = false;
                currentIndex = (dir > 0) ?
                    (currentIndex + 1) % slides.Count :
                    (currentIndex - 1 + slides.Count) % slides.Count;
                isAnimating = false;
            }
        }
    }
}
