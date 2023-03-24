using Assemble;
using DC00_assm;
using Infragistics.Win;
using Infragistics.Win.UltraWinTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
	public partial class UserInfo : Form
	{
		UltraGridUtil _GridUtil = new UltraGridUtil();
		UltraTreeNode childNode;
		public UserInfo()
		{
			InitializeComponent();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}


		private void UserInfo_Load(object sender, EventArgs e)
		{

			
			DBHelper helper = new DBHelper();
			helper.SPSet_Select("S1_USERINFO");
			DataTable dtTemp = helper.SPRun_Select();
			Tree.Nodes.Clear();

			UltraTreeNode node = Tree.Nodes.Add("root", "부서");
		
			UltraTreeNode childNode_sub;
			foreach (DataRow dr in dtTemp.Rows) 
			{
				if (Convert.ToString(dr["GROUPS"]) != "" && Convert.ToString(dr["MEMBERS"]) == "")
				{
					childNode = node.Nodes.Add(Convert.ToString(dr["GROUPS"]), Convert.ToString(dr["GROUPS"]));					
					//continue;
					continue;
				}
				if (Convert.ToString(dr["GROUPS"]) == "" && Convert.ToString(dr["MEMBERS"]) != "")
				{
					childNode_sub = childNode.Nodes.Add("", Convert.ToString(dr["MEMBERS"]));
				}

			}

		}
	}
}
