using Assemble;
using DC00_Component;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_List
{
	public partial class FormUserInform : Form
	{
		public FormUserInform()
		{
			InitializeComponent();
		}

		private void FormUserInform_Load(object sender, EventArgs e)
		{

			//부서 콤보박스 셋팅
			DataTable dtTemp = Common.StandardCode("DEPARTMENT");
			Common.setComboBox(cboDepart, dtTemp);

			//직책 콤보박스 셋팅
			dtTemp = Common.StandardCode("POSITION");
			Common.setComboBox(cboUserPosition, dtTemp);

			//권한 콤보박스 셋팅
			dtTemp = Common.StandardCode("AUTHORITY");
			Common.setComboBox(cboUserAuthority,dtTemp);

			
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnRegist_Click(object sender, EventArgs e)
		{


			DBHelper helper = new DBHelper(true);
			string sUser = string.Empty;
			try
			{
				string sUserId    = txtUserId.Text;
				string sUserPw    = txtUserPw.Text;
				string sUserName  = txtUserName.Text;
				string sDepart    = cboDepart.Value.ToString();
				string sPosition  = cboUserPosition.Value.ToString(); // 코드말고 이름으로 뜨게 만들기
				string sAddress   = txtUserAddress.Text;
				string sPhone     = txtUserPhone.Text;
				string sEmail     = txtUserEmail.Text;
				string sAuthority = cboUserAuthority.Value.ToString();

				

				if (sUserId == "")
				{
					BaseChildForm.ShowMsg("아이디 를 입력하지 않았습니다.");
					return;
				}
				if (sUserPw == "")
				{
                    BaseChildForm.ShowMsg("패스워드 를 입력하지 않았습니다.");
					return;
				}
				if (sUserName == "")
				{
                    BaseChildForm.ShowMsg("이름을 입력하지 않았습니다.");
					return;
				}



				// 사용자 정보를 데이터 베이스로 던져줄 파라메터
				helper.SPSet_Add("I1_User_Registration");
				helper.AddParameter("@USERID"        , sUserId);
				helper.AddParameter("@PASSWORD"      , sUserPw);
				helper.AddParameter("@USERNAME"      , sUserName);
				helper.AddParameter("@DEPARTMENT"    , sDepart);
				helper.AddParameter("@POSITON"       , sPosition);
				helper.AddParameter("@ADDRESS"       , sAddress);
				helper.AddParameter("@PHONE_NUMBER"  , sPhone);
				helper.AddParameter("@EMAIL"         , sEmail);
				helper.AddParameter("@AUTHORITY"     , sAuthority);
				helper.AddParameter("@MAKER"         , Common.userId);



				helper.SPRun_Add();

				//일치하는 ID가 있을때 메세지를 던져준다.
				sUser = helper.RS_MSG;
				if (helper.RS_CODE != "S") throw new Exception(helper.RS_MSG);

				helper.Commit();
                BaseChildForm.ShowMsg("사용자 정보 등록을 완료하였습니다.");
			}
			catch (Exception ex)
			{
				
				BaseChildForm.ShowMsg(helper.RS_MSG);
				helper.Rollback();
			}
			finally 
			{
				helper.Close(); 
			}

		}
	}
}
