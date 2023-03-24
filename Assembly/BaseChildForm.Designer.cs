namespace Assemble
{
    partial class BaseChildForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            this.gbxHeader = new Infragistics.Win.Misc.UltraGroupBox();
            this.gbxBody = new Infragistics.Win.Misc.UltraGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxHeader
            // 
            appearance1.BackColor = System.Drawing.Color.AliceBlue;
            appearance1.BackColor2 = System.Drawing.Color.AliceBlue;
            appearance1.BackColorDisabled = System.Drawing.Color.AliceBlue;
            appearance1.BackColorDisabled2 = System.Drawing.Color.AliceBlue;
            appearance1.BorderColor = System.Drawing.Color.AliceBlue;
            appearance1.BorderColor2 = System.Drawing.Color.AliceBlue;
            appearance1.BorderColor3DBase = System.Drawing.Color.AliceBlue;
            appearance1.ForeColor = System.Drawing.Color.AliceBlue;
            appearance1.ForeColorDisabled = System.Drawing.Color.AliceBlue;
            this.gbxHeader.Appearance = appearance1;
            this.gbxHeader.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxHeader.ContentPadding.Bottom = 2;
            this.gbxHeader.ContentPadding.Left = 2;
            this.gbxHeader.ContentPadding.Right = 2;
            this.gbxHeader.ContentPadding.Top = 4;
            this.gbxHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxHeader.Location = new System.Drawing.Point(0, 0);
            this.gbxHeader.Margin = new System.Windows.Forms.Padding(2);
            this.gbxHeader.Name = "gbxHeader";
            this.gbxHeader.Size = new System.Drawing.Size(1136, 124);
            this.gbxHeader.TabIndex = 1;
            this.gbxHeader.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // gbxBody
            // 
            this.gbxBody.BorderStyle = Infragistics.Win.Misc.GroupBoxBorderStyle.RectangularSolid;
            this.gbxBody.ContentPadding.Bottom = 4;
            this.gbxBody.ContentPadding.Left = 4;
            this.gbxBody.ContentPadding.Right = 4;
            this.gbxBody.ContentPadding.Top = 6;
            this.gbxBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxBody.Location = new System.Drawing.Point(0, 124);
            this.gbxBody.Margin = new System.Windows.Forms.Padding(2);
            this.gbxBody.Name = "gbxBody";
            this.gbxBody.Size = new System.Drawing.Size(1136, 701);
            this.gbxBody.TabIndex = 2;
            this.gbxBody.ViewStyle = Infragistics.Win.Misc.GroupBoxViewStyle.XP;
            // 
            // BaseChildForm
            // 
            this.ClientSize = new System.Drawing.Size(1136, 825);
            this.Controls.Add(this.gbxBody);
            this.Controls.Add(this.gbxHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseChildForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.gbxHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gbxBody)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public Infragistics.Win.Misc.UltraGroupBox gbxHeader;
        public Infragistics.Win.Misc.UltraGroupBox gbxBody;
    }
}