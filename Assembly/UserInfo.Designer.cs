namespace Form_List
{
	partial class UserInfo
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
            this.Tree = new Infragistics.Win.UltraWinTree.UltraTree();
            this.sLabel1 = new DC00_Component.SLabel();
            this.btnClose = new Infragistics.Win.Misc.UltraButton();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.btnMessageSend = new Infragistics.Win.Misc.UltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.Tree.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.Tree.Location = new System.Drawing.Point(108, 84);
            this.Tree.Name = "Tree";
            this.Tree.NodeConnectorColor = System.Drawing.SystemColors.ControlDark;
            this.Tree.Size = new System.Drawing.Size(257, 402);
            this.Tree.TabIndex = 0;
            // 
            // sLabel1
            // 
            appearance1.FontData.BoldAsString = "False";
            appearance1.FontData.UnderlineAsString = "False";
            appearance1.ForeColor = System.Drawing.Color.Black;
            appearance1.TextHAlignAsString = "Right";
            appearance1.TextVAlignAsString = "Middle";
            this.sLabel1.Appearance = appearance1;
            this.sLabel1.DbField = null;
            this.sLabel1.Font = new System.Drawing.Font("나눔고딕코딩", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sLabel1.Location = new System.Drawing.Point(171, 55);
            this.sLabel1.Name = "sLabel1";
            this.sLabel1.RequireFlag = DC00_Component.SLabel.RequireFlagEnum.NO;
            this.sLabel1.Size = new System.Drawing.Size(133, 23);
            this.sLabel1.TabIndex = 1;
            this.sLabel1.Text = "사용자 정보";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(108, 594);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(257, 55);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "종료";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.Controls.Add(this.btnMessageSend);
            this.ultraGroupBox1.Controls.Add(this.sLabel1);
            this.ultraGroupBox1.Controls.Add(this.btnClose);
            this.ultraGroupBox1.Controls.Add(this.Tree);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(500, 750);
            this.ultraGroupBox1.TabIndex = 3;
            // 
            // btnMessageSend
            // 
            this.btnMessageSend.Location = new System.Drawing.Point(108, 516);
            this.btnMessageSend.Name = "btnMessageSend";
            this.btnMessageSend.Size = new System.Drawing.Size(257, 55);
            this.btnMessageSend.TabIndex = 4;
            this.btnMessageSend.Text = "메세지 전달";
            // 
            // UserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 750);
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "사용자 정보";
            this.Load += new System.EventHandler(this.UserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Tree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private Infragistics.Win.UltraWinTree.UltraTree Tree;
		private DC00_Component.SLabel sLabel1;
		private Infragistics.Win.Misc.UltraButton btnClose;
		private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
		private Infragistics.Win.Misc.UltraButton btnMessageSend;
	}
}