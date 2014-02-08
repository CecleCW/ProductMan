namespace ProductMan
{
    partial class StockForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockForm));
            this.lbl_Warning = new System.Windows.Forms.Label();
            this.lbl_ProductInfo = new System.Windows.Forms.Label();
            this.tbx_Stock = new System.Windows.Forms.TextBox();
            this.btn_Yes = new System.Windows.Forms.Button();
            this.btn_No = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_Stock = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Warning
            // 
            this.lbl_Warning.AccessibleDescription = null;
            this.lbl_Warning.AccessibleName = null;
            resources.ApplyResources(this.lbl_Warning, "lbl_Warning");
            this.lbl_Warning.Font = null;
            this.lbl_Warning.Name = "lbl_Warning";
            // 
            // lbl_ProductInfo
            // 
            this.lbl_ProductInfo.AccessibleDescription = null;
            this.lbl_ProductInfo.AccessibleName = null;
            resources.ApplyResources(this.lbl_ProductInfo, "lbl_ProductInfo");
            this.lbl_ProductInfo.Name = "lbl_ProductInfo";
            // 
            // tbx_Stock
            // 
            this.tbx_Stock.AccessibleDescription = null;
            this.tbx_Stock.AccessibleName = null;
            resources.ApplyResources(this.tbx_Stock, "tbx_Stock");
            this.tbx_Stock.BackgroundImage = null;
            this.tbx_Stock.Font = null;
            this.tbx_Stock.Name = "tbx_Stock";
            // 
            // btn_Yes
            // 
            this.btn_Yes.AccessibleDescription = null;
            this.btn_Yes.AccessibleName = null;
            resources.ApplyResources(this.btn_Yes, "btn_Yes");
            this.btn_Yes.BackgroundImage = null;
            this.btn_Yes.Font = null;
            this.btn_Yes.Name = "btn_Yes";
            this.btn_Yes.UseVisualStyleBackColor = true;
            this.btn_Yes.Click += new System.EventHandler(this.btn_Yes_Click);
            // 
            // btn_No
            // 
            this.btn_No.AccessibleDescription = null;
            this.btn_No.AccessibleName = null;
            resources.ApplyResources(this.btn_No, "btn_No");
            this.btn_No.BackgroundImage = null;
            this.btn_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_No.Font = null;
            this.btn_No.Name = "btn_No";
            this.btn_No.UseVisualStyleBackColor = true;
            this.btn_No.Click += new System.EventHandler(this.btn_No_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleDescription = null;
            this.pictureBox1.AccessibleName = null;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.BackgroundImage = null;
            this.pictureBox1.Font = null;
            this.pictureBox1.ImageLocation = null;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // lbl_Stock
            // 
            this.lbl_Stock.AccessibleDescription = null;
            this.lbl_Stock.AccessibleName = null;
            resources.ApplyResources(this.lbl_Stock, "lbl_Stock");
            this.lbl_Stock.Font = null;
            this.lbl_Stock.Name = "lbl_Stock";
            // 
            // StockForm
            // 
            this.AcceptButton = this.btn_Yes;
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.CancelButton = this.btn_No;
            this.Controls.Add(this.lbl_Stock);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_No);
            this.Controls.Add(this.btn_Yes);
            this.Controls.Add(this.tbx_Stock);
            this.Controls.Add(this.lbl_ProductInfo);
            this.Controls.Add(this.lbl_Warning);
            this.Font = null;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockForm";
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Warning;
        private System.Windows.Forms.Label lbl_ProductInfo;
        private System.Windows.Forms.TextBox tbx_Stock;
        private System.Windows.Forms.Button btn_Yes;
        private System.Windows.Forms.Button btn_No;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_Stock;
    }
}