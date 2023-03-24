namespace Assemble
{
    partial class DialogForm_YesOrNo
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnYES = new Infragistics.Win.Misc.UltraButton();
            this.btnNo = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("굴림", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(59, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(451, 65);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnYES
            // 
            this.btnYES.Location = new System.Drawing.Point(157, 92);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(75, 23);
            this.btnYES.TabIndex = 1;
            this.btnYES.Text = "YES";
            this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(296, 92);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 1;
            this.btnNo.Text = "NO";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // DialogForm_YesOrNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 127);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYES);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogForm_YesOrNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowMsg";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Infragistics.Win.Misc.UltraButton btnYES;
        private Infragistics.Win.Misc.UltraButton btnNo;
    }
}