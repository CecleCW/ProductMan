/////////////////////////////////////////////////////////////////////////////
//
// (c) 2007 BinaryComponents Ltd.  All Rights Reserved.
//
// http://www.binarycomponents.com/
//
/////////////////////////////////////////////////////////////////////////////

namespace BinaryComponents.SuperList.Helper
{
	partial class AvailableSectionsForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && (components != null) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AvailableSectionsForm));
            BinaryComponents.SuperList.Sections.SectionFactory sectionFactory1 = new BinaryComponents.SuperList.Sections.SectionFactory();
            this._panel = new System.Windows.Forms.Panel();
            this._availableSectionsControl = new BinaryComponents.SuperList.Helper.AvailableSectionsControl();
            this._label = new System.Windows.Forms.Label();
            this._panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _panel
            // 
            resources.ApplyResources(this._panel, "_panel");
            this._panel.Controls.Add(this._availableSectionsControl);
            this._panel.Name = "_panel";
            // 
            // _availableSectionsControl
            // 
            this._availableSectionsControl.AllowDrop = true;
            this._availableSectionsControl.ColumnList = null;
            resources.ApplyResources(this._availableSectionsControl, "_availableSectionsControl");
            this._availableSectionsControl.Name = "_availableSectionsControl";
            this._availableSectionsControl.SectionFactory = sectionFactory1;
            // 
            // _label
            // 
            resources.ApplyResources(this._label, "_label");
            this._label.Name = "_label";
            // 
            // AvailableSectionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._panel);
            this.Controls.Add(this._label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AvailableSectionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this._panel.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel _panel;
		private AvailableSectionsControl _availableSectionsControl;
		private System.Windows.Forms.Label _label;

	}
}