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

	public partial class Standard : Assemble.BaseChildForm
	{

		UltraGridUtil _GridUtil = new UltraGridUtil();

		public Standard()
		{
			InitializeComponent();
		}

		private void Standard_Load(object sender, EventArgs e)
		{

			#region < 그리드 셋팅 >
			_GridUtil.InitializeGrid(this.grid1); //그리드 초기화
			_GridUtil.InitColumnUltraGrid(grid1, "MAJORCODE", "메이져코드"  , GridColDataType_emu.VarChar     , 100, HAlign.Left, true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "MINORCODE", "마이너코드"  , GridColDataType_emu.VarChar     , 130, HAlign.Left, true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "CODENAME" , "코드이름"    , GridColDataType_emu.VarChar     , 100, HAlign.Left, true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "AUTHORITY", "권한"        , GridColDataType_emu.VarChar     , 100, HAlign.Left, true, true);
			_GridUtil.InitColumnUltraGrid(grid1, "MAKEDATE" , "MAKEDATE"    , GridColDataType_emu.DateTime24  , 200, HAlign.Left, false, true);
			_GridUtil.InitColumnUltraGrid(grid1, "MAKER"    , "MAKER"       , GridColDataType_emu.VarChar     , 200, HAlign.Left, false, true);
			_GridUtil.InitColumnUltraGrid(grid1, "EDITDATE" , "EDITDATE"    , GridColDataType_emu.DateTime24  , 100, HAlign.Left, false, true);
			_GridUtil.InitColumnUltraGrid(grid1, "EDITOR"   , "EDITOR"      , GridColDataType_emu.VarChar     , 100, HAlign.Left, false, true);

			_GridUtil.SetInitUltraGridBind(this.grid1); //그리드 데이터 바인딩 초기화

			grid1.DisplayLayout.Bands[0].Columns["MAJORCODE"].Header.Appearance.ForeColor = Color.Blue;
			grid1.DisplayLayout.Bands[0].Columns["MINORCODE"].Header.Appearance.ForeColor = Color.Brown;

			#endregion

			#region < 콤보박스 셋팅. >
			DataTable dtTemp = new DataTable();

			//메이저코드 콤보박스 셋팅
			dtTemp = Common.standardCode01("MAJORCODE");
			Common.setComboBox(cboMajor, dtTemp);

			//마이너코드 콤보박스 셋팅
			dtTemp = Common.standardCode02(Convert.ToString(cboMajor.Value));
			Common.setComboBox(cboMinor, dtTemp);
			#endregion




		}

		// 공통기준정보 조횐
		public override void DoInquire()
		{
			base.DoInquire();

			DBHelper helper = new DBHelper();
			try
			{
				string sMajorCode = Convert.ToString(cboMajor.Value);
				string sMinorCode = Convert.ToString(cboMinor.Value);

				helper.SPSet_Select("S1_StandardMaster");
				helper.SelectParameter("@MAJORCODE", sMajorCode);
				helper.SelectParameter("@MINORCODE", sMinorCode);

				DataTable dtTemp = helper.SPRun_Select();
				grid1.DataSource = dtTemp;



			}
			catch (Exception ex)
			{
				ShowMsg(ex.ToString());
				helper.Rollback();
			}
			finally
			{

				helper.Close();
			}
		}

		private void cboMajor_SelectionChanged(object sender, EventArgs e)
		{
			DataTable dtTemp = new DataTable();
			//마이너코드 콤보박스 셋팅
			dtTemp = Common.standardCode02(Convert.ToString(cboMajor.Value));
			Common.setComboBox(cboMinor, dtTemp);
		}
	}
}
