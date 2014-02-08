using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Threading;
using System.Configuration;
using ProductMan.Utilities;

namespace ProductMan.Patterns
{
    public enum SyncThread
    {
        MainThread = 0,
        BackgroundThread = 1
    }

    public enum BackgroundThreadState
    {
        None = 0,
        Running,
        Stop
    }

    public class PMSubject : Component, ISubject
    {
        public event EventHandler<EventArgs> OnSyncStart;
        public event EventHandler<EventArgs> OnSyncCompleted;

        protected IContainer components = null;
        protected Timer backgroundThreadTimer;
        protected ThreadHelper.BackgroundWorker worker;
        protected ISynchronizeInvoke syncInvoker;
        protected BackgroundThreadState bgThreadState;
        protected int timerInterval;

        public PMSubject(ISynchronizeInvoke syncInvoker)
        {
            InitializeComponent();
            this.syncInvoker = syncInvoker;
            bgThreadState = BackgroundThreadState.None;
        }

        [DebuggerStepThroughAttribute()]
        private void InitializeComponent()
        {
            components = new Container();
            bool valid = int.TryParse(ConfigurationManager.AppSettings.Get("SyncInterval"), out timerInterval);
            if (!valid || timerInterval < 1000)
            {
                timerInterval = 600000;
            }
            worker = new ThreadHelper.BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new ThreadHelper.DoWorkEventHandler(worker_DoWork);
            worker.RunWorkerCompleted += new ThreadHelper.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);

            backgroundThreadTimer = new Timer(ThreadTimerCallback, null, timerInterval, timerInterval);
        }

        private void worker_RunWorkerCompleted(object sender, ThreadHelper.RunWorkerCompletedEventArgs e)
        {
            List<ProductInfo> products = e.Result as List<ProductInfo>;
            if (syncInvoker != null)
            {
                System.Windows.Forms.MethodInvoker mi = delegate
                {
                    MergeNewData(products);
                };
                syncInvoker.Invoke(mi, null);
            }
        }

        private void MergeNewData(List<ProductInfo> products)
        {
            if (products != null && products.Count > 0)
            {
                if (OnNewData != null)
                    OnNewData(this, new NewDataEventArgs(products));
            }
            bgThreadState = BackgroundThreadState.Stop;
            if (OnSyncCompleted != null)
                OnSyncCompleted(this, EventArgs.Empty);
        }

        private void worker_DoWork(object sender, ThreadHelper.DoWorkEventArgs e)
        {
            e.Result = GetNewData();
        }

        private List<ProductInfo> GetNewData()
        {
            List<ProductInfo> products = new List<ProductInfo>();
            try
            {
                //TODO
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return products;
        }

        private void ThreadTimerCallback(object state)
        {
            if (bgThreadState != BackgroundThreadState.Running)
            {
                BeginSync(SyncThread.BackgroundThread);
            }
        }

        public void BeginSync(SyncThread behavior)
        {
            if (OnSyncStart != null)
                OnSyncStart(this, EventArgs.Empty);
            if (behavior == SyncThread.BackgroundThread)
            {
                bgThreadState = BackgroundThreadState.Running;
                worker.RunWorkerAsync();
            }
            else
            {
                List<ProductInfo> products = GetNewData();
                MergeNewData(products);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region ISubject Members

        public event EventHandler<EventArgs> OnDataChanged;
        public event EventHandler<NewDataEventArgs> OnNewData;

        public int GetOpenCount()
        {
            try
            {
                //TODO
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return 0;
        }

        public int GetCloseCount()
        {
            try
            {
                //TODO
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return 0;
        }

        public int GetPendingCount()
        {
            try
            {
                //TODO
            }
            catch (Exception ex)
            {
                LoggerBase.Instance.Error(ex.ToString());
            }
            return 0;
        }

        public void Fire()
        {
            if (OnDataChanged != null)
                OnDataChanged(this, EventArgs.Empty);
        }

        #endregion
    }
}
