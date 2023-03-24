namespace Form_List
{
    partial class menu1_1
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
            this.ultraActivityIndicator1 = new Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator();
            this.ultraButton1 = new Infragistics.Win.Misc.UltraButton();
            this.SuspendLayout();
            // 
            // ultraActivityIndicator1
            // 
            this.ultraActivityIndicator1.CausesValidation = true;
            this.ultraActivityIndicator1.Location = new System.Drawing.Point(214, 256);
            this.ultraActivityIndicator1.Name = "ultraActivityIndicator1";
            this.ultraActivityIndicator1.Size = new System.Drawing.Size(100, 23);
            this.ultraActivityIndicator1.TabIndex = 0;
            this.ultraActivityIndicator1.TabStop = true;
            // 
            // ultraButton1
            // 
            this.ultraButton1.Location = new System.Drawing.Point(500, 308);
            this.ultraButton1.Name = "ultraButton1";
            this.ultraButton1.Size = new System.Drawing.Size(75, 23);
            this.ultraButton1.TabIndex = 1;
            this.ultraButton1.Text = "ultraButton1";
            // 
            // menu1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ultraButton1);
            this.Controls.Add(this.ultraActivityIndicator1);
            this.Name = "menu1_1";
            this.Text = "menu1_1";
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraActivityIndicator.UltraActivityIndicator ultraActivityIndicator1;
        private Infragistics.Win.Misc.UltraButton ultraButton1;
    }
}