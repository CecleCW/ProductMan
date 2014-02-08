using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace ProductMan.Components
{
    public enum GradientMode
    {
        Vertical,
        VerticalCenter,
        Horizontal,
        HorizontalCenter,
        Diagonal
    }

    public class XPStyledProgressBar : Control
    {
        #region Private Members

        private const string CategoryName = "XPStyled ProgressBar";

        private Color _borderColor = Color.FromArgb(170, 240, 170);
        private Color _centerColor = Color.FromArgb(10, 150, 10);
        private Color _backgroundColor = Color.White;
        private Color _textColor = Color.Black;
        private Image _img;
        private GradientMode _gradientMode = GradientMode.VerticalCenter;

        private int _max = 100;
        private int _min = 0;
        private int _pos = 50;
        private byte _steepDistance = 2;
        private byte _steepWidth = 6;
        private byte _textShadowAlpha = 150;
        private bool _textShadow = true;

        private Rectangle _innerRect;
        private LinearGradientBrush _brush1;
        private LinearGradientBrush _brush2;
        private Pen _penIn = new Pen(Color.FromArgb(239, 239, 239));

        private Pen _penOut = new Pen(Color.FromArgb(104, 104, 104));
        private Pen _penOut2 = new Pen(Color.FromArgb(190, 190, 190));

        private Rectangle _steepRect1;
        private Rectangle _steepRect2;
        private Rectangle _outnnerRect;
        private Rectangle _outnnerRect2;

        #endregion

        #region Constructor

        public XPStyledProgressBar() { }

        #endregion

        #region Override Functions

        protected override void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (_img != null)
                {
                    _img.Dispose();
                }
                if (_brush1 != null)
                {
                    _brush1.Dispose();
                }

                if (_brush2 != null)
                {
                    _brush2.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!this.IsDisposed)
            {
                int mSteepTotal = _steepWidth + _steepDistance;
                float mUtilWidth = this.Width - 6 + _steepDistance;

                if (_img == null)
                {
                    mUtilWidth = this.Width - 6 + _steepDistance;
                    int mMaxSteeps = (int)(mUtilWidth / mSteepTotal);
                    this.Width = 6 + mSteepTotal * mMaxSteeps;

                    _img = new Bitmap(this.Width, this.Height);

                    Graphics g2 = Graphics.FromImage(_img);

                    CreatePaintElements();

                    g2.Clear(_backgroundColor);

                    if (this.BackgroundImage != null)
                    {
                        TextureBrush textuBrush = new TextureBrush(this.BackgroundImage, WrapMode.Tile);
                        g2.FillRectangle(textuBrush, 0, 0, this.Width, this.Height);
                        textuBrush.Dispose();
                    }

                    g2.DrawRectangle(_penOut2, _outnnerRect2);
                    g2.DrawRectangle(_penOut, _outnnerRect);
                    g2.DrawRectangle(_penIn, _innerRect);
                    g2.Dispose();

                }

                Image ima = new Bitmap(_img);

                Graphics gtemp = Graphics.FromImage(ima);

                int mCantSteeps = (int)((((float)_pos - _min) / (_max - _min)) * mUtilWidth / mSteepTotal);

                for (int i = 0; i < mCantSteeps; i++)
                {
                    DrawSteep(gtemp, i);
                }

                if (this.Text != String.Empty)
                {
                    gtemp.TextRenderingHint = TextRenderingHint.AntiAlias;
                    DrawCenterString(gtemp, this.ClientRectangle);
                }

                e.Graphics.DrawImage(ima, e.ClipRectangle.X, e.ClipRectangle.Y, e.ClipRectangle, GraphicsUnit.Pixel);
                ima.Dispose();
                gtemp.Dispose();

            }

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!this.IsDisposed)
            {
                if (this.Height < 12)
                {
                    this.Height = 12;
                }

                base.OnSizeChanged(e);
                this.InvalidateBuffer(true);
            }

        }

        protected override Size DefaultSize
        {
            get { return new Size(100, 29); }
        }

        #endregion

        #region Colors

        [Category(CategoryName)]
        [Description("The Back Color of the Progress Bar")]
        public Color ColorBackGround
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category(CategoryName)]
        [Description("The Border Color of the gradient in the Progress Bar")]
        public Color ColorBarBorder
        {
            get { return _borderColor; }
            set
            {
                _borderColor = value;
                this.InvalidateBuffer(true);
            }
        }

        [Category(CategoryName)]
        [Description("The Center Color of the gradient in the Progress Bar")]
        public Color ColorBarCenter
        {
            get { return _centerColor; }
            set
            {
                _centerColor = value;
                this.InvalidateBuffer(true);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description("Set to True to reset all colors like the Windows XP Progress Bar")]
        [Category(CategoryName)]
        [DefaultValue(false)]
        public bool ColorsXP
        {
            get { return false; }
            set
            {
                ColorBarBorder = Color.FromArgb(170, 240, 170);
                ColorBarCenter = Color.FromArgb(10, 150, 10);
                ColorBackGround = Color.White;
            }
        }

        [Category(CategoryName)]
        [Description("The Color of the text displayed in the Progress Bar")]
        public Color ColorText
        {
            get { return _textColor; }
            set
            {
                _textColor = value;

                if (this.Text != String.Empty)
                {
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Position

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Current Position of the Progress Bar")]
        public int Position
        {
            get { return _pos; }
            set
            {
                if (value > _max)
                {
                    _pos = _max;
                }
                else if (value < _min)
                {
                    _pos = _min;
                }
                else
                {
                    _pos = value;
                }
                this.Invalidate();
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Max Position of the Progress Bar")]
        public int PositionMax
        {
            get { return _max; }
            set
            {
                if (value > _min)
                {
                    _max = value;

                    if (_pos > _max)
                    {
                        Position = _max;
                    }

                    this.InvalidateBuffer(true);
                }
            }
        }

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        [Description("The Min Position of the Progress Bar")]
        public int PositionMin
        {
            get { return _min; }
            set
            {
                if (value < _max)
                {
                    _min = value;

                    if (_pos < _min)
                    {
                        Position = _min;
                    }
                    this.InvalidateBuffer(true);
                }
            }
        }

        [Category(CategoryName)]
        [Description("The number of Pixels between two Steeps in Progress Bar")]
        [DefaultValue((byte)2)]
        public byte SteepDistance
        {
            get { return _steepDistance; }
            set
            {
                if (value >= 0)
                {
                    _steepDistance = value;
                    this.InvalidateBuffer(true);
                }
            }
        }

        #endregion

        #region Progress Style

        [Category(CategoryName)]
        [Description("The Style of the gradient bar in Progress Bar")]
        [DefaultValue(GradientMode.VerticalCenter)]
        public GradientMode GradientStyle
        {
            get { return _gradientMode; }
            set
            {
                if (_gradientMode != value)
                {
                    _gradientMode = value;
                    CreatePaintElements();
                    this.Invalidate();
                }
            }
        }

        [Category(CategoryName)]
        [Description("The number of Pixels of the Steeps in Progress Bar")]
        [DefaultValue((byte)6)]
        public byte SteepWidth
        {
            get { return _steepWidth; }
            set
            {
                if (value > 0)
                {
                    _steepWidth = value;
                    this.InvalidateBuffer(true);
                }
            }
        }

        #endregion

        #region Extra Properties

        [RefreshProperties(RefreshProperties.Repaint)]
        [Category(CategoryName)]
        public override Image BackgroundImage
        {
            get { return base.BackgroundImage; }
            set
            {
                base.BackgroundImage = value;
                InvalidateBuffer();
            }
        }

        [Category(CategoryName)]
        [Description("The Text displayed in the Progress Bar")]
        [DefaultValue("")]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Invalidate();
                }
            }
        }

        [Category(CategoryName)]
        [Description("Set the Text shadow in the Progress Bar")]
        [DefaultValue(true)]
        public bool TextShadow
        {
            get { return _textShadow; }
            set
            {
                _textShadow = value;
                this.Invalidate();
            }
        }

        [Category(CategoryName)]
        [Description("Set the Alpha Channel of the Text shadow in the Progress Bar")]
        [DefaultValue((byte)150)]
        public byte TextShadowAlpha
        {
            get { return _textShadowAlpha; }
            set
            {
                if (_textShadowAlpha != value)
                {
                    _textShadowAlpha = value;
                    this.TextShadow = true;
                }
            }
        }

        #endregion

        #region Private Functions

        private void DrawSteep(Graphics g, int number)
        {
            g.FillRectangle(_brush1, 4 + number * (_steepDistance + _steepWidth), _steepRect1.Y + 1, _steepWidth, _steepRect1.Height);
            g.FillRectangle(_brush2, 4 + number * (_steepDistance + _steepWidth), _steepRect2.Y + 1, _steepWidth, _steepRect2.Height - 1);
        }

        private void InvalidateBuffer()
        {
            InvalidateBuffer(false);
        }

        private void InvalidateBuffer(bool InvalidateControl)
        {
            if (_img != null)
            {
                _img.Dispose();
                _img = null;
            }

            if (InvalidateControl)
            {
                this.Invalidate();
            }
        }

        private void DisposeBrushes()
        {
            if (_brush1 != null)
            {
                _brush1.Dispose();
                _brush1 = null;
            }

            if (_brush2 != null)
            {
                _brush2.Dispose();
                _brush2 = null;
            }

        }

        private void DrawCenterString(Graphics gfx, Rectangle box)
        {
            SizeF ss = gfx.MeasureString(this.Text, this.Font);

            float left = box.X + (box.Width - ss.Width) / 2;
            float top = box.Y + (box.Height - ss.Height) / 2;

            if (_textShadow)
            {
                SolidBrush mShadowBrush = new SolidBrush(Color.FromArgb(_textShadowAlpha, Color.Black));
                gfx.DrawString(this.Text, this.Font, mShadowBrush, left + 1, top + 1);
                mShadowBrush.Dispose();
            }
            SolidBrush mTextBrush = new SolidBrush(_textColor);
            gfx.DrawString(this.Text, this.Font, mTextBrush, left, top);
            mTextBrush.Dispose();

        }

        private void CreatePaintElements()
        {
            DisposeBrushes();

            switch (_gradientMode)
            {
                case GradientMode.VerticalCenter:

                    _steepRect1 = new Rectangle(
                        0,
                        2,
                        _steepWidth,
                        this.Height / 2 + (int)(this.Height * 0.05));
                    _brush1 = new LinearGradientBrush(_steepRect1, _borderColor, _centerColor, LinearGradientMode.Vertical);

                    _steepRect2 = new Rectangle(
                        0,
                        _steepRect1.Bottom - 1,
                        _steepWidth,
                        this.Height - _steepRect1.Height - 4);
                    _brush2 = new LinearGradientBrush(_steepRect2, _centerColor, _borderColor, LinearGradientMode.Vertical);
                    break;

                case GradientMode.Vertical:
                    _steepRect1 = new Rectangle(
                        0,
                        3,
                        _steepWidth,
                        this.Height - 7);
                    _brush1 = new LinearGradientBrush(_steepRect1, _borderColor, _centerColor, LinearGradientMode.Vertical);
                    _steepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    _brush2 = new LinearGradientBrush(_steepRect2, _centerColor, _borderColor, LinearGradientMode.Horizontal);
                    break;


                case GradientMode.Horizontal:
                    _steepRect1 = new Rectangle(
                        0,
                        3,
                        _steepWidth,
                        this.Height - 7);

                    _brush1 = new LinearGradientBrush(this.ClientRectangle, _borderColor, _centerColor, LinearGradientMode.Horizontal);
                    _steepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    _brush2 = new LinearGradientBrush(_steepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;


                case GradientMode.HorizontalCenter:
                    _steepRect1 = new Rectangle(
                        0,
                        3,
                        _steepWidth,
                        this.Height - 7);

                    _brush1 = new LinearGradientBrush(this.ClientRectangle, _borderColor, _centerColor, LinearGradientMode.Horizontal);
                    _brush1.SetBlendTriangularShape(0.5f);

                    _steepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    _brush2 = new LinearGradientBrush(_steepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;


                case GradientMode.Diagonal:
                    _steepRect1 = new Rectangle(
                        0,
                        3,
                        _steepWidth,
                        this.Height - 7);

                    _brush1 = new LinearGradientBrush(this.ClientRectangle, _borderColor, _centerColor, LinearGradientMode.ForwardDiagonal);
                    _steepRect2 = new Rectangle(
                        -100,
                        -100,
                        1,
                        1);
                    _brush2 = new LinearGradientBrush(_steepRect2, Color.Red, Color.Red, LinearGradientMode.Horizontal);
                    break;

                default:
                    _brush1 = new LinearGradientBrush(_steepRect1, _borderColor, _centerColor, LinearGradientMode.Vertical);
                    _brush2 = new LinearGradientBrush(_steepRect2, _centerColor, _borderColor, LinearGradientMode.Vertical);
                    break;

            }

            _innerRect = new Rectangle(
                this.ClientRectangle.X + 2,
                this.ClientRectangle.Y + 2,
                this.ClientRectangle.Width - 4,
                this.ClientRectangle.Height - 4);
            _outnnerRect = new Rectangle(
                this.ClientRectangle.X,
                this.ClientRectangle.Y,
                this.ClientRectangle.Width - 1,
                this.ClientRectangle.Height - 1);
            _outnnerRect2 = new Rectangle(
                this.ClientRectangle.X + 1,
                this.ClientRectangle.Y + 1,
                this.ClientRectangle.Width,
                this.ClientRectangle.Height);

        }

        #endregion
    }
}
