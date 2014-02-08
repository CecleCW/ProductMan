using System;
using System.Windows.Forms;
using System.Data;
using ProductMan.Patterns;

namespace ProductMan.Panes
{
    public partial class ChartPane : UserControl, IObserver
    {
        protected ISubject subject;

        public ChartPane()
        {
            InitializeComponent();
        }

        private void subject_OnDataChanged(object sender, EventArgs e)
        {
            chart1.Open = subject.GetOpenCount();
            chart1.Pending = subject.GetPendingCount();
            chart1.Closed = subject.GetCloseCount();
        }

        #region IObserver Members

        public ISubject Subject
        {
            set
            {
                subject = value;
                if (subject != null)
                    subject.OnDataChanged += new EventHandler<EventArgs>(subject_OnDataChanged);
            }
        }

        #endregion
    }
}
