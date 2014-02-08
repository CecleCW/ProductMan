using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace ProductMan.Components
{
    public class WaterMarkTextBox : TextBox
    {
        private bool _drawWaterMark = true;
        private bool _focusSelect = true;
        private string _waterMark = string.Empty;
        private Color _waterMarkBackColor = Color.White;
        private Color _waterMarkColor = SystemColors.GrayText;
        private Font _waterMarkFont;
        public const int WM_ERASEBKGND = 14;
        public const int WM_KILLFOCUS = 8;
        public const int WM_PAINT = 15;
        public const int WM_SETFOCUS = 7;

        public WaterMarkTextBox()
        {
            this.WaterMarkFont = this.Font;
        }

        protected virtual void DrawWaterMark()
        {
            using (Graphics graphics = base.CreateGraphics())
            {
                this.DrawWaterMark(graphics);
            }
        }

        protected virtual void DrawWaterMark(Graphics g)
        {
            TextFormatFlags flags = TextFormatFlags.NoPadding | TextFormatFlags.EndEllipsis;
            Rectangle clientRectangle = base.ClientRectangle;
            switch (base.TextAlign)
            {
                case HorizontalAlignment.Left:
                    //flags = flags;
                    clientRectangle.Offset(1, 1);
                    break;

                case HorizontalAlignment.Right:
                    flags |= TextFormatFlags.Right;
                    clientRectangle.Offset(0, 1);
                    break;

                case HorizontalAlignment.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    clientRectangle.Offset(0, 1);
                    break;
            }
            if (base.Enabled)
            {
                this._waterMarkBackColor = Color.White;
            }
            else
            {
                this._waterMarkBackColor = SystemColors.Control;
            }
            TextRenderer.DrawText(g, this._waterMark, this._waterMarkFont, clientRectangle, this._waterMarkColor, this._waterMarkBackColor, flags);
        }

        protected override void OnEnter(EventArgs e)
        {
            if ((this.Text.Length > 0) && this._focusSelect)
            {
                base.SelectAll();
            }
            base.OnEnter(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (this._drawWaterMark && (this.Text.Length == 0))
            {
                this.DrawWaterMark(e.Graphics);
            }
        }

        protected override void OnTextAlignChanged(EventArgs e)
        {
            base.OnTextAlignChanged(e);
            base.Invalidate();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 7:
                    this._drawWaterMark = false;
                    break;

                case 8:
                    this._drawWaterMark = true;
                    break;
            }
            base.WndProc(ref m);
            if (((m.Msg == 15) && this._drawWaterMark) && ((this.Text.Length == 0) && !base.GetStyle(ControlStyles.UserPaint)))
            {
                this.DrawWaterMark();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Description("Automatically select the text when control receives the focus."), Browsable(true), Category("Behavior")]
        public bool FocusSelect
        {
            get
            {
                return this._focusSelect;
            }
            set
            {
                this._focusSelect = value;
            }
        }

        [Browsable(true), Category("Appearance"), Description("The water mark to display when there is nothing in the Text property."), EditorBrowsable(EditorBrowsableState.Always)]
        public string WaterMark
        {
            get
            {
                return this._waterMark;
            }
            set
            {
                this._waterMark = value.Trim();
                base.Invalidate();
            }
        }

        [Description("The Font to use when displaying the WaterMark."), Category("Appearance"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public Font WaterMarkFont
        {
            get
            {
                return this._waterMarkFont;
            }
            set
            {
                this._waterMarkFont = value;
                base.Invalidate();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always), Browsable(true), Category("Appearance"), Description("The ForeColor to use when displaying the WaterMark.")]
        public Color WaterMarkForeColor
        {
            get
            {
                return this._waterMarkColor;
            }
            set
            {
                this._waterMarkColor = value;
                base.Invalidate();
            }
        }
    }
}
