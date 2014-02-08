using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductMan.Panes
{
    public partial class SearchPane : UserControl
    {
        public event EventHandler<InputTextChangedEventArgs> OnInput;
        public event EventHandler<EventArgs> OnCancel;

        public SearchPane()
        {
            InitializeComponent();
            wtbx_Input.KeyPress += new KeyPressEventHandler(wtbx_Input_KeyPress);
            btn_Cancel.Click += new EventHandler(btn_Cancel_Click);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            wtbx_Input.Clear();
            if (OnCancel != null)
                OnCancel(this, EventArgs.Empty);
        }

        private void wtbx_Input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (OnInput != null)
                    OnInput(this, new InputTextChangedEventArgs(wtbx_Input.Text.Trim()));
            }
        }

        public string Caption
        {
            get { return lbl_Caption.Text; }
            set
            {
                lbl_Caption.Text = value;
                Invalidate();
            }
        }

        public string Hints
        {
            get { return wtbx_Input.WaterMark; }
            set
            {
                wtbx_Input.WaterMark = value;
                Invalidate();
            }
        }

        public string Keywords { get { return wtbx_Input.Text.Trim(); } }

        [Browsable(false)]
        public object[] Conditions
        {
            set { cbx_Type.Items.AddRange(value); }
        }

        [Browsable(false)]
        public int ConditionIndex
        {
            get { return cbx_Type.SelectedIndex; }
            set { cbx_Type.SelectedIndex = value; }
        }

        [Browsable(false)]
        public string Option
        {
            get
            {
                if (cbx_Type.SelectedItem != null)
                    return cbx_Type.SelectedItem.ToString();
                return "";
            }
        }

        [Browsable(false)]
        public bool AllowCustomTypes
        {
            get { return cbx_Type.Visible; }
            set { cbx_Type.Visible = value; }
        }
    }

    public class InputTextChangedEventArgs : EventArgs
    {
        protected string text;

        public InputTextChangedEventArgs(string txt)
        {
            this.text = txt;
        }

        public string Text
        {
            get { return text; }
        }
    }
}
