using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using ProductMan.Helpers;

namespace ProductMan.Panes
{
    public partial class FilterPane : UserControl
    {
        public event EventHandler<EventArgs> OnFilter;

        public FilterPane()
        {
            InitializeComponent();

            //clb_Options.ItemCheck += new ItemCheckEventHandler(clb_Options_ItemCheck);
            clb_Options.SelectedIndexChanged += new EventHandler(clb_Options_SelectedIndexChanged);
        }

        public void ChangeLanguage(CultureInfo culture)
        {
            lbl_FilterTitle.Text = ResourceHelper.Instance.GetString("FilterPane.Filter", culture);
        }

        private void clb_Options_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OnFilter != null)
                OnFilter(this, EventArgs.Empty);
        }

        private void clb_Options_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (OnFilter != null)
                OnFilter(this, EventArgs.Empty);
        }

        [Browsable(false)]
        public CheckedListBox MyOwner
        {
            get { return clb_Options; }
        }
    }
}
