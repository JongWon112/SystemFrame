using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assemble;

namespace Search_Dropdown_Test
{
    public partial class dbhelper_Test : Form
    {
        public dbhelper_Test()
        {
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            string str = comboBox1.Text;
            //MessageBox.Show(comboBox1.Items.ToString());
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.AutoCompleteMode= AutoCompleteMode.Suggest;
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;

            //로그인 그룹박스 invi
            loginGbox.Visible= false;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {

            //DataTable dtTemp = new DataTable();
            //DBHelper helper = new DBHelper();
            //helper.SPSet_Select("TESTSP");
            //helper.SelectParameter("@USERID", "1JO_01");
            //dtTemp = helper.SPRun_Select();

            DBHelper helper = new DBHelper(true);
            helper.SPSet_Add("TESTSP");
            helper.AddParameter("@USERID", "1JO_Test");
            helper.AddParameter("@PASSWORD", "1111");
            helper.AddParameter("@USERNAME", "테스트");
            helper.SPRun_Add();
            if(helper.RS_CODE != "S")
            {
                helper.Rollback();
                MessageBox.Show(helper.RS_MSG);
                return;
            }

            helper.Commit();
           
        }


    }
}
