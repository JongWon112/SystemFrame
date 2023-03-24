using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assemble
{
    public partial class DialogForm_YesOrNo : Form
    {
        public string result = "";
        public DialogForm_YesOrNo(string msg)
        {
            InitializeComponent();
            label1.Text = msg;
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            this.result = "YES";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.result = "NO";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
