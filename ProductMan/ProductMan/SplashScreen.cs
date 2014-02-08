using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace ProductMan
{
    public class SplashScreen : Form
    {
        protected const int SHADOWOFFSET = 3;
        private Bitmap bitmap;
        private Label lbl_Info;
        private bool splashMode;
        private static SplashScreen instance;

        public SplashScreen()
        {
            this.splashMode = true;
            this.lbl_Info = new Label();
            this.lbl_Info.Text = "";
            this.lbl_Info.AutoSize = true;
            this.lbl_Info.Location = new Point(6, 0xe1);
            this.lbl_Info.BackColor = Color.Black;
            this.lbl_Info.ForeColor = Color.White;
            base.Controls.Add(this.lbl_Info);
            base.FormBorderStyle = FormBorderStyle.None;
            base.StartPosition = FormStartPosition.CenterScreen;
            base.ShowInTaskbar = false;
            this.BackColor = Color.Black;
            this.bitmap = new Bitmap(typeof(SplashScreen).Assembly.GetManifestResourceStream("ProductMan.Images.SplashScreen.jpg"));
            if (bitmap != null)
            {
                base.ClientSize = this.bitmap.Size;
                this.BackgroundImage = this.bitmap;
            }
        }

        public SplashScreen(bool splashMode)
            : this()
        {
            this.splashMode = splashMode;
            base.Click += new EventHandler(this.SplashScreen_Click);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.bitmap != null))
            {
                this.bitmap.Dispose();
                this.bitmap = null;
            }
            base.Dispose(disposing);
        }

        private void SplashScreen_Click(object sender, EventArgs e)
        {
            if (!this.splashMode)
            {
                base.Close();
            }
        }

        public static SplashScreen Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SplashScreen();
                }
                return instance;
            }
            set
            {
                instance = value;
            }
        }

        public void SetBackground(string productName)
        {
            SetBackground(productName, new Font("Arial", 36f, FontStyle.Regular));
        }

        public void SetBackground(string productName, Font font)
        {
            SetBackground(productName, font, new PointF(60f, 70f));
        }

        public void SetBackground(string productName, Font font, PointF location)
        {
            SetBackground(productName, font, location, Color.FromArgb(215, 195, 96));
        }

        public void SetBackground(string productName, Font font, PointF location, Color color)
        {
            SetBackground(productName, font, location, color, bitmap);
        }

        public void SetBackground(string productName, Font font, PointF location, Color color, Bitmap bitmap)
        {
            if (bitmap == null) return;

            try
            {
                this.bitmap = bitmap;
                if (productName != null && productName.Trim() != "")
                {
                    Brush brush = new SolidBrush(color);
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                        PointF shadowLocation = new PointF(location.X + SHADOWOFFSET, location.Y + SHADOWOFFSET);
                        g.DrawString(productName, font, Brushes.Black, shadowLocation, StringFormat.GenericTypographic);
                        g.DrawString(productName, font, brush, location, StringFormat.GenericTypographic);
                    }
                }
                ClientSize = bitmap.Size;
                BackgroundImage = bitmap;
            }
            catch { }
        }

        public string Status
        {
            set
            {
                this.lbl_Info.Text = value;
                this.Refresh();
            }
        }
    }
}
