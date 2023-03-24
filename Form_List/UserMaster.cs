using Assemble;
using Infragistics.Win;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DC00_Component;
using Infragistics.Win.UltraWinGrid;
using DC00_assm;
using System.Xml.Linq;
using Assemble;



namespace Form_List
{
    public partial class UserMaster : BaseChildForm
    {
        UltraGridUtil _GridUtil = new UltraGridUtil();
        public UserMaster()
        {
            InitializeComponent();
        }

        #region < 그리드 세팅, 콤보박스 세팅 >
        public void UserMaster_Load(object sender, EventArgs e)
        {
            _GridUtil.InitializeGrid(this.grid1); //그리드 초기화
            _GridUtil.InitColumnUltraGrid(grid1, "UserId", "ID", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "UserName", "이름", GridColDataType_emu.VarChar, 130, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Department", "부서", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Position", "직위", GridColDataType_emu.VarChar, 100, HAlign.Center, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Address", "주소", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Phone_Number", "전화번호", GridColDataType_emu.VarChar, 100, HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Authority", "권한", GridColDataType_emu.Integer, 100, HAlign.Right, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "MakeDate", "만든날짜", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "Maker", "등록자", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EditDate", "수정날짜", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.InitColumnUltraGrid(grid1, "EDITOR", "수정자", GridColDataType_emu.VarChar, 100, HAlign.Left, true, true);
            _GridUtil.SetInitUltraGridBind(this.grid1); //그리드 데이터 바인딩 초기화


            DataTable dtTemp = Common.StandardCode("DEPARTMENT");
            Common.setComboBox(cboDept, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "DEPARTMENT", dtTemp); // 그리드에 콤보박스 세팅

            dtTemp = Common.StandardCode("POSITION");
            Common.setComboBox(cboPosition, dtTemp);
            UltraGridUtil.SetComboUltraGrid(grid1, "POSITION", dtTemp); // 그리드에 콤보박스 세팅

            dtStartDate.Value = "2023-01-01 00:00:00";
            dtEndDate.Value = DateTime.Now;

        }

        #endregion

        #region < ToolBar EVENT >
        public override void DoInquire()
        {
            string sUserName = txtName.Text;
            string sDepartment = cboDept.Value.ToString();
            string sPosition = cboPosition.Value.ToString();
            string sStartDate = string.Format("{0:yyyy-MM-dd}", dtStartDate.Value);
            string sEndDate = string.Format("{0:yyyy-MM-dd}", dtEndDate.Value);

            DBHelper helper = new DBHelper(false);
            try
            {



                // DataTable dtTemp = new DataTable();
                helper.SPSet_Select("S1_UserMaster");
                helper.SelectParameter("@USERNAME", sUserName);
                helper.SelectParameter("@DEPARTMENT", sDepartment);
                helper.SelectParameter("@POSITION", sPosition);
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

        public override void DoDelete()
        {
            grid1.DeleteRow();
        }

        public override void DoSave()
        {

            DataTable dt = grid1.chkChange();
            if (dt == null)
            {
                //  ShowDialog("저장할 행이 없습니다");
                return;
            }

            DBHelper helper = new DBHelper(true);

            try
            {

                string sUSERID = string.Empty;
                string sUSERNAME = string.Empty;
                string sDEPARTMENT = string.Empty;
                string sPOSITION = string.Empty;
                string sADDRESS = string.Empty;
                string sPHONE_NUMBER = string.Empty;
                string sWRITER = string.Empty;
                foreach (DataRow dr in dt.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            sUSERID = Convert.ToString(dr["USERID"]);
                            sUSERNAME = Convert.ToString(dr["USERNAME"]);


                            helper.SPSet_Add("D1_UserMaster");
                            helper.AddParameter("@USERID", sUSERID);
                            helper.AddParameter("@USERNAME", sUSERNAME);
                            helper.SPRun_Add();
                            if (helper.RS_CODE != "S")
                            {
                                helper.Rollback();
                                ShowMsg("다시하십시요");
                                return;

                            }

                            // DELETE Rogic
                            break;
                        case DataRowState.Added:
                            // INSERT Rogic
                            break;
                        case DataRowState.Modified:
                            // UPDATE Rogic

                            sUSERID = Convert.ToString(dr["USERID"]);
                            sUSERNAME = Convert.ToString(dr["USERNAME"]);
                            sDEPARTMENT = Convert.ToString(dr["DEPARTMENT"]);
                            sPOSITION = Convert.ToString(dr["POSITION"]);
                            sADDRESS = Convert.ToString(dr["ADDRESS"]);
                            sPHONE_NUMBER = Convert.ToString(dr["PHONE_NUMBER"]);
                            sWRITER = Common.userId;




                            helper.SPSet_Add("U1_UserMaster");
                            helper.AddParameter("@USERID", sUSERID);
                            helper.AddParameter("@USERNAME", sUSERNAME);
                            helper.AddParameter("@DEPARTMENT", sDEPARTMENT);
                            helper.AddParameter("@POSITION", sPOSITION);
                            helper.AddParameter("@ADDRESS", sADDRESS);
                            helper.AddParameter("@PHONE_NUMBER", sPHONE_NUMBER);
                            helper.AddParameter("@WRITER", sWRITER);

                            helper.SPRun_Add();

                            if (helper.RS_CODE != "S")
                            {
                                helper.Rollback();
                                return;

                            }
                            //helper.SelectParameter("@USERID", Convert.ToString(dr["USERID"])),
                            break;


                    }
                }


                helper.Commit();
                this.DoInquire();
                ShowMsg("정상적으로 등록을 완료 하였습니다.");
            }

            catch (Exception ex)
            {
                helper.Rollback();
                ShowMsg(ex.ToString());
            }
            finally
            {
                helper.Close();
            }


        }


        #endregion

        #region < 사용자 등록 >
        private void btnUserInform_Click(object sender, EventArgs e)
        {
            FormUserInform newform2 = new FormUserInform();
            newform2.ShowDialog();
        }
        #endregion
    }
}