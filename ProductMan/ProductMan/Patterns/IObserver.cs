using System;
using System.Collections.Generic;

namespace ProductMan.Patterns
{
    public interface IObserver
    {
        ISubject Subject
        {
            set;
        }
    }

    public interface ISubject
    {
        event EventHandler<EventArgs> OnDataChanged;
        event EventHandler<NewDataEventArgs> OnNewData;

        int GetOpenCount();
        int GetCloseCount();
        int GetPendingCount();
        void Fire();
    }

    public class NewDataEventArgs : EventArgs
    {
        protected List<ProductInfo> newData;

        public NewDataEventArgs(List<ProductInfo> newData)
        {
            this.newData = newData;
        }

        public List<ProductInfo> NewData
        {
            get { return newData; }
        }
    }
}
