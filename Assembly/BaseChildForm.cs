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
    public partial class BaseChildForm : Form, IChildCommds
    {
        public BaseChildForm()
        {
            InitializeComponent();
        }

        public virtual void DoDelete()
        {
            
        }

        public virtual void DoInquire()
        {
            
        }

        public virtual void DoNew()
        {
            
        }

        public virtual void DoSave()
        {
          
        }

        public static void ShowMsg(string v)
        {
            DialogForm form1 = new DialogForm(v);
            //form1.StartPosition = FormStartPosition.Manual;
            //form1.Location = new Point()
            form1.ShowDialog();
        }

        public static DialogResult ShowMsg(string v, MessageBoxButtons mb)
        {
            DialogForm_YesOrNo form1 = new DialogForm_YesOrNo(v);
            DialogResult returnVal = DialogResult.No;
            var result = form1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string yesOrNo = form1.result;
                //해당 메뉴 오픈
                if(yesOrNo == "YES") returnVal = DialogResult.Yes;
                
            }

            return returnVal;

        }


    }
}
