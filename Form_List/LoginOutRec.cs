using Assemble;
using DC00_assm;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Form_List
{
	public partial class LoginOutRec : Assemble.BaseChildForm
	{
		UltraGridUtil _GridUtil = new UltraGridUtil();
		public LoginOutRec()
		{
			InitializeComponent();
		}


		#region < 로그인 이력 그리드 셋팅> 
		private void LoginRec_Load(object sender, EventArgs e)
		{
			_GridUtil.InitializeGrid(this.grid1); //그리드 초기화
			_GridUtil.InitColumnUltraGrid(grid1, "USERId"     , "사용자ID"  , GridColDataType_emu.VarChar    , 100, HAlign.Left,   true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "USERNAME",    "이름", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "DEPARTMENT", "부서", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "POSITION", "직위", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "SEQNO"      , "로그인순번", GridColDataType_emu.VarChar    , 130, HAlign.Right,  true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "INOUTFLAG"  , "로그인여부", GridColDataType_emu.VarChar    , 100, HAlign.Left,   true, true);
			//_GridUtil.InitColumnUltraGrid(grid1, "INDATE"     , "로그인일자", GridColDataType_emu.VarChar    , 100, HAlign.Left,   true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE"   , "로그인일시", GridColDataType_emu.DateTime24 , 200, HAlign.Left,   true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "MAKER"      , "생성자"    , GridColDataType_emu.VarChar    , 100, HAlign.Left,   false, true);
			_GridUtil.SetInitUltraGridBind(this.grid1); //그리드 데이터 바인딩 초기화

            DataTable dtTemp = Common.StandardCode("LOGINOUTFLAG");
			Common.setComboBox(cboINOUT, dtTemp);

			grid1.DisplayLayout.Bands[0].Columns["UserId"].Header.Appearance.ForeColor = Color.Blue;

            dtStartDate.Value = "2023-01-01 00:00:00";
            dtEndDate.Value = DateTime.Now;
        }
		#endregion

		public override void DoInquire()
		{
			base.DoInquire();
			string sUserId = txtLoginId.Text;
			string sINOUTFLAG = Convert.ToString(cboINOUT.Value);
			string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
			string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEndDate.Value);


			DBHelper helper = new DBHelper(false);
			try
			{
				helper.SPSet_Select("S2_LOGINOUTRec");
				helper.SelectParameter("@USERID", sUserId);
				helper.SelectParameter("@INOUTFLAG", sINOUTFLAG);
				helper.SelectParameter("@STARTDATE", sStartDate);
				helper.SelectParameter("@ENDDATE", sEndDate);


				DataTable dtTemp = helper.SPRun_Select();
				grid1.DataSource = dtTemp;


			}
			catch (Exception ex)
			{
				ShowMsg(ex.ToString());
			}
			finally
			{
				helper.Close();
			}

		}




	}
}
