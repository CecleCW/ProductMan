using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace ProductMan.Components
{
    public class AddressMeta : Label
    {
        protected const string PATTERN = @"^(?<name>.*)@.*$";
        protected string name;
        protected string email;
        protected bool isValid;
        protected int id;
        protected TextFormatFlags textFormatFlags = (TextFormatFlags.NoPadding | TextFormatFlags.NoPrefix | TextFormatFlags.SingleLine | TextFormatFlags.HorizontalCenter);

        public AddressMeta(string name)
        {
            this.name = name;
            InternalConstruct(name, name);
        }

        public AddressMeta(string name, string email)
        {
            InternalConstruct(name, email);
        }

        private void InternalConstruct(string name, string email)
        {
            isValid = true;
            this.name = name;
            this.email = email;

            Font = new Font("Arial", 8.0f, FontStyle.Underline | FontStyle.Italic | FontStyle.Bold);
            Text = name;
            Size = MinimumSize;
            TabStop = false;
            BackColor = SystemColors.Window;
            ForeColor = SystemColors.WindowText;
        }

        public string eMail { get { return email; } }

        public string DisplayName { get { return name; } }

        public bool IsValid { get { return isValid; } }

        public int ID { get { return id; } set { id = value; } }

        public override Size MinimumSize
        {
            get
            {
                return TextRenderer.MeasureText(Text, Font, Size, textFormatFlags);
            }
        }
    }
}
