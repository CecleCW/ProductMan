using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProductMan.Panes
{
    public partial class Chart : UserControl
    {
        // const values
        private const int Border = 10;
        private const int BottomBorder = 50;
        private const int LabelBorder = 1;
        private const int MessageBorder = 5;
        private const int MinBarWidth = 15;
        private const int LeftPos = 60;

        // bounding areas for chart and bars
        private Rectangle m_boundsChart;
        private RectangleF[] m_bounds = new RectangleF[3];

        private int m_barHeight;

        private int[] m_values = new int[3];

        private Color m_barColor = Color.FromArgb(250, 230, 165);
        private Color m_gridLineColor = Color.Gainsboro;
        private Color m_gridLineBaseColor = Color.SteelBlue;
        private Color m_labelColor = Color.DimGray;
        private Color m_valueColor = Color.Black;

        // text alignment
        private StringFormat m_formatRight;
        private StringFormat m_formatTop;
        private StringFormat m_formatLeft;
        private StringFormat m_formatCenter;

        // gdi objects
        private Brush m_brushLabel;
        private Brush m_brushValue;
        private Brush m_brushBar;
        private Pen m_penBaseGridLine;
        private Pen m_penGridLine;

        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Number of open tasks.")]
        [DefaultValueAttribute(0)]
        public int Open
        {
            get
            {
                return m_values[2];
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                m_values[2] = value;
                Invalidate();
            }
        }

        [DefaultValueAttribute(0)]
        [DescriptionAttribute("Number of closed tasks.")]
        [CategoryAttribute("Chart")]
        public int Closed
        {
            get
            {
                return m_values[0];
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                m_values[0] = value;
                Invalidate();
            }
        }

        [DefaultValueAttribute(0)]
        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Number of pending tasks.")]
        public int Pending
        {
            get
            {
                return m_values[1];
            }

            set
            {
                if (value < 0)
                {
                    value = 0;
                }
                m_values[1] = value;
                Invalidate();
            }
        }

        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Color of the chart bars.")]
        [DefaultValueAttribute(typeof(Color), "250, 230, 165")]
        public Color BarColor
        {
            get
            {
                return m_barColor;
            }

            set
            {
                if (value == Color.Empty)
                {
                    value = Color.FromArgb(250, 230, 165);
                }
                m_barColor = value;
                m_brushBar = new SolidBrush(m_barColor);
                Invalidate();
            }
        }

        [DescriptionAttribute("Color of the gridlines.")]
        [DefaultValueAttribute(typeof(Color), "Gainsboro")]
        [CategoryAttribute("Chart")]
        public Color GridLineColor
        {
            get
            {
                return m_gridLineColor;
            }

            set
            {
                if (value == Color.Empty)
                {
                    value = Color.Gainsboro;
                }
                m_gridLineColor = value;
                m_penGridLine = new Pen(m_gridLineColor);
                Invalidate();
            }
        }

        [DescriptionAttribute("Color of the base gridline.")]
        [CategoryAttribute("Chart")]
        [DefaultValueAttribute(typeof(Color), "SteelBlue")]
        public Color BaseGridLineColor
        {
            get
            {
                return m_gridLineBaseColor;
            }

            set
            {
                if (value == Color.Empty)
                {
                    value = Color.SteelBlue;
                }
                m_gridLineBaseColor = value;
                m_penBaseGridLine = new Pen(m_gridLineBaseColor);
                Invalidate();
            }
        }

        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Color of the labels and message.")]
        [DefaultValueAttribute(typeof(Color), "DimGray")]
        public Color LabelColor
        {
            get
            {
                return m_labelColor;
            }

            set
            {
                if (value == Color.Empty)
                {
                    value = Color.DimGray;
                }
                m_labelColor = value;
                m_brushLabel = new SolidBrush(m_labelColor);
                Invalidate();
            }
        }

        [DefaultValueAttribute(typeof(Color), "Black")]
        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Color of the bar values.")]
        public Color ValueColor
        {
            get
            {
                return m_valueColor;
            }

            set
            {
                if (value == Color.Empty)
                {
                    value = Color.Black;
                }
                m_valueColor = value;
                m_brushValue = new SolidBrush(m_valueColor);
                Invalidate();
            }
        }

        [DefaultValueAttribute("")]
        [CategoryAttribute("Chart")]
        [DescriptionAttribute("Chart message at the bottom.")]
        public string Message
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        public Chart()
        {
            // init the gdi objects, do this by setting the
            // color properties (creates the associated gdi object)
            BarColor = m_barColor;
            GridLineColor = m_gridLineColor;
            BaseGridLineColor = m_gridLineBaseColor;
            LabelColor = m_labelColor;
            ValueColor = m_valueColor;

            // init the font
            Font = new Font("arial", 7.0F, FontStyle.Regular);

            // setup text alignments, used later when draw strings
            m_formatRight = new StringFormat();
            m_formatRight.Alignment = StringAlignment.Far;
            m_formatRight.LineAlignment = StringAlignment.Center;

            m_formatTop = new StringFormat();
            m_formatTop.Alignment = StringAlignment.Center;
            m_formatTop.LineAlignment = StringAlignment.Near;

            m_formatLeft = new StringFormat();
            m_formatLeft.LineAlignment = StringAlignment.Center;

            m_formatCenter = new StringFormat();
            m_formatCenter.Alignment = StringAlignment.Center;
            m_formatCenter.LineAlignment = StringAlignment.Center;

            // turn on double buffering
            SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);

            InitializeComponent();
        }

        // recalculate the position of the bars and labels
        protected override void OnSizeChanged(EventArgs e)
        {
            CalculateBounds();
            base.OnSizeChanged(e);
        }

        // recalculate the position of the bars and labels
        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            CalculateBounds();
        }

        // update right away
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            CalculateBounds();
            Invalidate();
        }

        // draw the chart
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // clear and init the drawing surface
            e.Graphics.Clear(Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // only draw if sized large enough to display the data
            if (Width > LeftPos && m_barHeight > 1)
            {
                DrawLabels(e.Graphics);
                DrawChart(e.Graphics);
            }

            // always draw the message
            DrawMessage(e.Graphics);
        }

        // calculate the bounding area, used later when drawing the chart
        private void CalculateBounds()
        {
            // chart area
            m_boundsChart = new Rectangle(LeftPos, Border, Width - Border - LeftPos, Height - Font.Height - (Border * 2));

            // see if need to leave room for the message
            if (Text != null && Text.Length > 0)
            {
                m_boundsChart.Height -= (Font.Height + MessageBorder);
            }

            // bar height
            m_barHeight = m_boundsChart.Height / 6;

            // resolved area
            m_bounds[0] = new RectangleF(0.0F, (m_boundsChart.Top + m_barHeight), (LeftPos - LabelBorder), m_barHeight);

            // escalated area
            m_bounds[1] = new RectangleF(0.0F, (m_boundsChart.Top + (m_boundsChart.Height / 2) - (m_barHeight / 2)), (LeftPos - LabelBorder), m_barHeight);

            // open area
            m_bounds[2] = new RectangleF(0.0F, (m_boundsChart.Bottom - (m_barHeight * 2)), (LeftPos - LabelBorder), m_barHeight);
        }

        // labels on the left side
        private void DrawLabels(Graphics g)
        {
            g.DrawString("Closed", Font, m_brushLabel, m_bounds[0], m_formatRight);
            g.DrawString("Pending", Font, m_brushLabel, m_bounds[1], m_formatRight);
            g.DrawString("Open", Font, m_brushLabel, m_bounds[2], m_formatRight);
        }

        // message at the bottom left
        private void DrawMessage(Graphics g)
        {
            if (Text != null && Text.Length != 0)
            {
                // draw the message
                g.DrawString(Text, Font, m_brushLabel, MessageBorder, (Bottom - MessageBorder - Font.Height));
            }
        }

        // draw the chart, gridlines, bars and values
        private void DrawChart(Graphics g)
        {
            // calcualte the distance between the gridlines
            int space = m_boundsChart.Width / 5;

            // draw the gridlines
            for (int i = 1; i <= 5; i++)
            {
                g.DrawLine(m_penGridLine, m_boundsChart.Left + (space * i), m_boundsChart.Top, m_boundsChart.Left + (space * i), m_boundsChart.Bottom);
            }

            // draw the gridline labels
            int tick = (int)Math.Round(Math.Ceiling(Math.Max(Math.Max(m_values[0], m_values[1]), m_values[2]) / 5.0));
            for (int i = 0; i <= 5; i++)
            {
                g.DrawString((tick * i).ToString(), Font, m_brushLabel, (m_boundsChart.Left + space * i), m_boundsChart.Bottom, m_formatTop);
            }

            // calculate the real chart width (might be less then the control width)
            int chartWidth = space * 5;

            // ending tick mark
            int totalTicks = tick * 5;

            // loop through and draw each bar
            int barWidth = 0;

            for (int i = 0; i <= 2; i++)
            {
                // bar
                if (totalTicks > 0)
                {
                    barWidth = (chartWidth * m_values[i]) / totalTicks;
                }

                g.FillRectangle(m_brushBar, m_boundsChart.Left, m_bounds[i].Top, barWidth, m_barHeight);

                // label
                if (barWidth > MinBarWidth)
                {
                    // center label
                    g.DrawString(m_values[i].ToString(),
                                    Font,
                                    m_brushValue,
                                    (m_boundsChart.Left + (barWidth / 2)),
                                    m_bounds[i].Top + (int)Math.Round((double)(m_bounds[i].Height / 2.0F)) + 1.0F,
                                    m_formatCenter);
                }
                else
                {
                    // label outside of the bar
                    g.DrawString(m_values[i].ToString(),
                                    Font,
                                    m_brushValue,
                                    (m_boundsChart.Left + barWidth + 2),
                                    m_bounds[i].Top + (int)Math.Round((double)(m_bounds[i].Height / 2.0F)) + 1.0F,
                                    m_formatLeft);
                }
            }

            // draw the baseline last
            g.DrawLine(m_penBaseGridLine, m_boundsChart.Left, m_boundsChart.Top, m_boundsChart.Left, m_boundsChart.Bottom);
        }
    }
}
