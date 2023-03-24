using Infragistics.Win.UltraWinExplorerBar;
using Infragistics.Win.UltraWinTree;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Assemble
{
    public  partial class menuListPopUp : Form
    {
        public string returnMenu;
        
        public menuListPopUp(UltraExplorerBar exBar)
        {
            InitializeComponent();
            menuTree.ExpansionIndicatorColor = Color.Red;
            menuTree.ImageTransparentColor = Color.Blue;

            menuTree.Nodes.Clear();
            //메뉴를 트리뷰에 세팅
            // Add a root node
            UltraTreeNode node = this.menuTree.Nodes.Add("root", "메뉴");
            UltraTreeNode childNode;
            foreach (UltraExplorerBarGroup group in exBar.Groups)
            {
                childNode = node.Nodes.Add(group.Key, group.Text);
                foreach (UltraExplorerBarItem item in group.Items)
                {
                    childNode.Nodes.Add(item.Key, item.Text);
                }
            }

            //// Add some child nodes
            //UltraTreeNode childNode = node.Nodes.Add("child node 1");
            //childNode.Nodes.Add("child child 1");
            //childNode.Nodes.Add("child child 2");
            //childNode.Nodes.Add("child child 3");
            //MessageBox.Show(exBar.ToString());


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            
            foreach (UltraTreeNode iNodes in menuTree.Nodes[0].Nodes)
            {
                foreach(UltraTreeNode iNode in iNodes.Nodes)
                {

                    if (iNode.Text.Contains(txtSearchString.Text))
                    {
                        this.menuTree.ActiveNode = iNode;
                        this.menuTree.ActiveNode.Selected = true;
                        break;
                    }
                }
               
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (menuTree.ActiveNode == null) return;
            //선택 트리가 상위트리 일때 종료
            if (menuTree.ActiveNode.Level != 2) return;

            this.returnMenu = menuTree.ActiveNode.Key;
            this.DialogResult = DialogResult.OK;
            this.Close();

            
        }

        private void txtSearchString_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnSearch_Click(null, null);
        }
    }
}
