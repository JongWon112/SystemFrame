namespace Search_Dropdown_Test
{
    partial class dbhelper_Test
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComboBox = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.loginGbox = new System.Windows.Forms.GroupBox();
            this.logoutGbox = new System.Windows.Forms.GroupBox();
            this.loginBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBox
            // 
            this.ComboBox.AutoSize = true;
            this.ComboBox.Location = new System.Drawing.Point(149, 73);
            this.ComboBox.Name = "ComboBox";
            this.ComboBox.Size = new System.Drawing.Size(68, 12);
            this.ComboBox.TabIndex = 0;
            this.ComboBox.Text = "ComboBox";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "가",
            "가나다",
            "abc",
            "bca",
            "test",
            "test11",
            "가마고"});
            this.comboBox1.Location = new System.Drawing.Point(245, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // loginGbox
            // 
            this.loginGbox.Location = new System.Drawing.Point(151, 134);
            this.loginGbox.Name = "loginGbox";
            this.loginGbox.Size = new System.Drawing.Size(200, 100);
            this.loginGbox.TabIndex = 2;
            this.loginGbox.TabStop = false;
            this.loginGbox.Text = "로그인 그룹박스";
            // 
            // logoutGbox
            // 
            this.logoutGbox.Location = new System.Drawing.Point(151, 134);
            this.logoutGbox.Name = "logoutGbox";
            this.logoutGbox.Size = new System.Drawing.Size(200, 100);
            this.logoutGbox.TabIndex = 3;
            this.logoutGbox.TabStop = false;
            this.logoutGbox.Text = "로그아웃 그룹박스";
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(582, 109);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 4;
            this.loginBtn.Text = "db 접근";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.logoutGbox);
            this.Controls.Add(this.loginGbox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.ComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ComboBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox loginGbox;
        private System.Windows.Forms.GroupBox logoutGbox;
        private System.Windows.Forms.Button loginBtn;
    }
}

