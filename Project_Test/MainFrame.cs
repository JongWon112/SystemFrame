using Assemble;
using DC00_assm;
using Infragistics.Win.UltraWinExplorerBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Infragistics.Win.Misc;
using System.Reflection;
using Infragistics;
using Infragistics.Shared;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;
using Microsoft.VisualBasic.ApplicationServices;
using Form_List;

namespace Search_Dropdown_Test
{
    public partial class MainFrame : Form
    {
        #region <MEMBER AREA>
        DataTable rtnDtTemp = new DataTable(); // return DataTable 공통
        UltraGridUtil _GridUtil = new UltraGridUtil();  //그리드 객체 생성
        private BindingList<object> menuList = new BindingList<object>();
        #endregion

        #region <초기셋팅>
        public MainFrame()
        {
            InitializeComponent();
            gboAfterLogin.Dock = DockStyle.None;
            gboBeforeLogin.Location = new System.Drawing.Point(3, 0);
            gboBeforeLogin.Dock = DockStyle.Top;
            gboBeforeLogin.SendToBack();
        }


        private void Login_Load(object sender, EventArgs e)
        {
            cboMenu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            cboMenu.AutoCompleteSource = AutoCompleteSource.ListItems;
            picMainImg.Dock = DockStyle.Fill;
            picMainImg.Visible = true;

            //test


        }
        #endregion




        #region < 로그인 이벤트>
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            #region < 로그인 및 로그인 이력 기록>
            //new DBHelper(true); 안에 트루 값을 넣을떄는 트랜잭션 사용할때만 넣어야 접속된다.         
            DBHelper helper = new DBHelper(false);
            DataTable dtUserInfo = new DataTable();
            string UserId = "";
            string UserPw = "";
            string tempAuthority = "";

         
            try
            {

                UserId = Convert.ToString(txtLoginId.Value); // 로그인 ID
                UserPw = Convert.ToString(txtLoginPw.Value); // 로그인 PW

                helper.SPSet_Select("S1_LoginMaster");
                helper.SelectParameter("UserId", UserId);
                helper.SelectParameter("Password", UserPw);

                //데이터베이스로 전달할 쿼리문
                //string selectSQL = $"SELECT COUNT(*) AS CNT FROM TB_UserMaster WHERE UserId = '{UserId}' AND Password = '{UserPw}'";

                //SPRun_Select() -> DataTable로 결과를 돌려줌.
                //helper.SPRun_Select();

                //쿼리를 보낼 객체
                //SqlDataAdapter sAdapter = new SqlDataAdapter(selectSQL, helper.sCon);

                //쿼리 결과를 담을 Table
                dtUserInfo = helper.SPRun_Select();
                //sAdapter.Fill(dtTemp);

                //---------------------------------------------------

                if (dtUserInfo.Rows.Count  ==  0)
                {
                    gboBeforeLogin.Visible = true;
                    gboAfterLogin.Visible = false;
                    //ShowMsg($" 로그인에 실패하셨습니다.");
                    ShowMsg("로그인에 실패하였습니다.");
                    
                    return;
                }

                //로그인 시도 유저 권한 정보 저장
                tempAuthority = Convert.ToString(dtUserInfo.Rows[0]["AUTHORITY"]);

            }
            catch (Exception ex)
            {
                ShowMsg(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            //2.로그인 성 공 시 이력을 남긴다 .
            helper = new DBHelper(true);
            try
            {
                // 로그인 이력을 남긴다
                helper.SPSet_Add("U1_LOGINOUTREC_LOGIN");
                helper.AddParameter("@UserId", UserId);
                helper.AddParameter("@Password", UserPw);
                helper.SPRun_Add();
                // 로그인 이력 남기는거 실패 시 리턴
                if (helper.RS_CODE == "E")
                {
                    ShowMsg($" 로그인에 실패하셨습니다.");
                    helper.Rollback();
                    return;
                }


                #region < 로그인 상태창 불러오기 및 메인이미지 로드 >
                gboBeforeLogin.Visible = false;
                gboAfterLogin.Visible = true;
                gboAfterLogin.Dock = DockStyle.Top;
                txtLoginId.Value = "";
                txtLoginPw.Value = "";
                lblUName.Text = Convert.ToString(dtUserInfo.Rows[0]["UserName"]);
                lblUDepart.Text = Convert.ToString(dtUserInfo.Rows[0]["CODENAME"]);
                lblUEmail.Text = Convert.ToString(dtUserInfo.Rows[0]["Email"]);
                lblUPhone.Text = Convert.ToString(dtUserInfo.Rows[0]["Phone_Number"]);

                ////로그인 했을때 그리드칸에 이미지 바뀜
                //myTabControl1.Dock = DockStyle.Fill;
                //myTabControl1.BringToFront();
                //picMainImg.Dock = DockStyle.None;
                //picMainImg.Visible = false;
                //picMainImg.SendToBack();

                #endregion
                helper.Commit();
           
            }
            catch(Exception ex) 
            {
                ShowMsg("로그인 실패" + ex.ToString());
                helper.Rollback();
                return;
            }
            finally { helper.Close(); }

            Common.userId = UserId;
            Common.userAutority = tempAuthority;

            #endregion

            #region < 사용자 이미지 불러오기>
            //사용자이미지 불러오기
            if (Convert.ToString(dtUserInfo.Rows[0]["IMAGE"]) != "")
            {
                //byte[] 배열 형식으로 받아올 변수 생성
                Byte[] bImage = null;

                // byte 배열 형식으로 byte코드 형 변환
                bImage = (byte[])dtUserInfo.Rows[0]["IMAGE"];

                //byte[] 배열인 bImage를 Bitmap(픽셀 이미지로 변경해주는 클래스)로 변환.
                pickQ.Image = new Bitmap(new MemoryStream(bImage));

            }
            else
            {
                pickQ.Image = Properties.Resources.user;
                //pickQ.Image = Properties.Resources.mainimg;
                //pickQ.Image = null;
            }
            #endregion

            #region < 권한 별 메뉴 구성 >
            //1. 그룹 구성
            // 로그인 유저 별 메뉴 가져오기
            helper = new DBHelper();
            try
            {
                helper.SPSet_Select("S1_TB_MENULIST_USER");
                helper.SelectParameter("@USERID", Common.userId);
                helper.SelectParameter("@USERAUTH", Common.userAutority);
                DataTable dtTemp = helper.SPRun_Select();

                string groupText = "";
                string key = "";
                string value = "";
                //가져온 메뉴 구성하기
                
                foreach(DataRow dtRow in dtTemp.Rows)
                {
                    key = Convert.ToString(dtRow["MENU_KEY"]);
                    value = Convert.ToString(dtRow["MENU_NAME"]);
                    //구성할 메뉴가 메뉴그룹인지 메뉴 아이템인지 확인
                    if (dtRow["MENU_ID"].ToString() == dtRow["PARENT_ID"].ToString())
                    {
                        //메뉴 그룹으로 구성
                        
                        menus.Groups.Add(key, value);
                        groupText = key;
                        continue;
                    }

                    menus.Groups[groupText].Items.Add(key, value);

                }


                //메뉴검색 콤보박스 세팅
                SetMenuSearch();

            }
            catch(Exception ex)
            {
                ShowMsg("메뉴 구성에 실패하였습니다." + ex.ToString());
            }
            finally { helper.Close(); }

            #endregion

            #region < 상태창 및 세팅  및 공통변수 세팅 >
            //상태창 세팅
            stsUserId.Text = Common.userId;
            Common.loginStatus = true;

            ShowMsg($" {UserId}님 로그인 되셨습니다.");

            #endregion

        }
        #endregion

        #region < 로그아웃 이벤트>
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Func_Logout();
           

        }

       

        #endregion

        #region < 메뉴 오픈 이벤트 > 
        private void menus_ItemClick(string menuName)
        {

            

            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFrom($"{Application.StartupPath}\\Form_List.DLL");

            //클릭한 메뉴의 CS 파일 타입 확인
            Type typeForm = assembly.GetType($"Form_List.{menuName}");

            if (typeForm == null) return;
            // Form 형식으로 전환
            Form FormMdi = (Form)Activator.CreateInstance(typeForm);

            // 해당되는 폼이 이미 오픈 되어있는지 확인 후 활성화 또는 신규 오픈.
            bool check = false;

            foreach (TabPage page in myTabControl1.TabPages)
            {
                if (page.Name == menuName)
                {
                    check = true;
                    myTabControl1.SelectedTab = page;
                    break;
                }
            }

            if (!check) myTabControl1.AddForm(FormMdi);

            if (myTabControl1.TabPages.Count == 1)
            {
                //로그인 했을때 TabPage 이미지 바뀜
                myTabControl1.Dock = DockStyle.Fill;
                myTabControl1.BringToFront();
                picMainImg.Dock = DockStyle.None;
                picMainImg.Visible = false;
                picMainImg.SendToBack();
            }

            stsFormName.Text = myTabControl1.SelectedTab.Text;
        }


        //메뉴 클릭 이벤트
        private void menus_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            menus_ItemClick(e.Item.Key);
        }
        // 메뉴 검색 이벤트
        private void btnGu_Click(object sender, EventArgs e)
        {
            //menus_ItemClick(Convert.ToString(this.cboMenu.SelectedValue));
            menuListPopUp popup = new menuListPopUp(menus);

            //팝업창 위치를 메뉴얼로 변경
            //popup.StartPosition = FormStartPosition.Manual;
            //popup.Location = new Point(50, 50);
            var result = popup.ShowDialog();

            if (result == DialogResult.OK)
            {
                string openMenu = popup.returnMenu;
                //해당 메뉴 오픈
                menus_ItemClick(openMenu);
            }




        }


        #endregion

        #region < 메뉴 닫기 이벤트 >
        private void myTabControl1_DoubleClick(object sender, EventArgs e)
        {
            //오픈 되어 있는 페이지가 없을 경우 닫기 버튼 클릭 이벤트 종료
            if (myTabControl1.TabPages.Count == 0) return;
            // 닫기 버튼 클릭 시 활성화 되어 있는 페이지 닫기
            myTabControl1.SelectedTab.Dispose();

            if (myTabControl1.TabPages.Count == 0) mainImageClose();

            stsFormName.Text = "";

        }

      

        #endregion

        #region < 툴바 이벤트 >
        void DoFunction(string sStatus)
        {
            //오픈 되어 있는 페이지가 없을 경우 return
            if (myTabControl1.TabPages.Count == 0) return;

            // 현재 활성화 된 화면의 조회 / 추가 / 삭제 / 저장 기능을 수행하는 메서드
            BaseChildForm Child = myTabControl1.SelectedTab.Controls[0] as BaseChildForm;
            if (Child == null) return;



            if (sStatus == "조회") Child.DoInquire();
            else if (sStatus == "추가") Child.DoNew();
            else if (sStatus == "삭제") Child.DoDelete();
            else if (sStatus == "저장") Child.DoSave();
        }



        private void btnFunctionClick(object sender, EventArgs e)
        {
            UltraButton tsFunction = (UltraButton)sender;
            DoFunction(tsFunction.Text);

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); // -> 종료 이벤트를 실행함 FormClosing 이벤트
        }

        #endregion

        #region < 사용자 이미지 변경 >
        private void pickQ_DoubleClick(object sender, EventArgs e)
        {

            Byte[] bImage = null; // 이미지 파일이 등록 될 Byte 배열.
            // 파일 탐색기 호출 (OpenFileDialog : 파일 탐색기 클래스, Window 제공 API)
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult dirResult = dialog.ShowDialog();
            string sImageFilePath = dialog.FileName; // 사진 파일이 저장되어 있는 폴더의 경로와 사진 파일의 정보.

            if (dirResult != DialogResult.OK) return;

            //if (ShowMsg("현재 이미지를 등록하시겠습니까?", "이미지 등록", MessageBoxButtons.YesNo) == DialogResult.No) return;

            if (ShowMsg("현재 이미지를 등록 하시겠습니까?", MessageBoxButtons.YesNo) == DialogResult.No) return;
            
            SqlConnection sCon = new SqlConnection(Common.sConn);
            SqlCommand cmd;

            try
            {
                FileStream stream = new FileStream(Convert.ToString(sImageFilePath), FileMode.Open, FileAccess.Read);

                // 3. 스트림을 통해 읽어온 Binary 코드를 Byte코드로 변환.
                BinaryReader reader = new BinaryReader(stream);

                // 4. 만들어진 Binary 코드의 이미지를  Byte화 하여 App의 데이터 자료형 구조에 담는다.
                bImage = reader.ReadBytes(Convert.ToInt32(stream.Length));

                // 5. 바이너리 리더 종료
                reader.Close();
                // 6. 파일 스트림 종료
                stream.Close();
                sCon.Open();
                cmd = new SqlCommand();
                cmd.Connection = sCon;


                string sUpdateSql = "UPDATE TB_USERMASTER SET" +
                    $"       IMAGE = @IMAGE          " + 
                    $" WHERE UserId = '{Common.userId}'";

                cmd.Parameters.AddWithValue("@IMAGE", bImage);

                cmd.CommandText = sUpdateSql;
                cmd.ExecuteNonQuery();
                pickQ.Image = Bitmap.FromFile(sImageFilePath);
                ShowMsg("이미지가 정상적으로 등록 되었습니다.");


            }
            catch (Exception ex)
            {
                ShowMsg("이미지등록에 실패하였습니다.\r\n" + ex.ToString());
            }
            finally
            {
                sCon.Close();
            }





        }

        #endregion

        private void txtLoginPw_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter) 
            {
                btnLogIn_Click(sender, e);
            }
        }

        private void cboMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                menus_ItemClick(Convert.ToString(this.cboMenu.SelectedValue));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            stsTime.Text = DateTime.Now.ToString();
        }

        private void btnUserInfo_Click(object sender, EventArgs e)
        {
            UserInfo newform3 = new UserInfo();
            newform3.ShowDialog();
        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Func_Logout();
        }

        private void cboMenu_DropDownClosed(object sender, EventArgs e)
        {
            menus_ItemClick(Convert.ToString(this.cboMenu.SelectedValue));
        }

        #region < 메서드 > 

        #region < 메뉴 검색 목록 세팅 메서드 > 
        private void SetMenuSearch()
        {

            //메뉴 목록을 콤보 박스에 세팅
            cboMenu.DataSource = menuList;
            foreach (UltraExplorerBarGroup group in menus.Groups)
            {
                foreach (UltraExplorerBarItem item in group.Items)
                {
                    menuList.Add(new { Text = item.Text, Value = item.Key });
                    cboMenu.DisplayMember = "Text";
                    cboMenu.ValueMember = "Value";
                }
            }
        }
        #endregion

        #region < 로그아웃 메서드 >
        private void Func_Logout()
        {
            if (Common.userId == "") return;

            if (ShowMsg("로그아웃 하시겠습니까?", MessageBoxButtons.YesNo) == DialogResult.No) return;

            #region < 유저 정보 창 세팅 >
            gboBeforeLogin.Location = new System.Drawing.Point(3, 0);
            gboBeforeLogin.BringToFront();
            gboBeforeLogin.Dock = DockStyle.Top;
            gboAfterLogin.Dock = DockStyle.None;
            menus.Dock = DockStyle.Fill;
            menus.BringToFront();
            gboBeforeLogin.Visible = true;
            //gboAfterLogin.Visible= false;

            // 그리드 칸 이미지 셋팅
            mainImageClose();

            #endregion



            //menus.Groups[0].Items.Remove(menus.Groups[0].Items[3]);

            #region < 로그아웃 이력 남기기 >



            DBHelper helper = new DBHelper(true);
            try
            {
                helper.SPSet_Add("U2_LOGINOUTREC_LOGOUT");
                helper.AddParameter("@USERID", Common.userId);
                helper.SPRun_Add();
                helper.Commit();

                Common.userId = "";
                ShowMsg($"정상적으로 로그아웃 하셨습니다.");

            }
            catch (Exception ex)
            {
                ShowMsg("로그아웃 하였습니다.");
                ShowMsg("로그아웃 이력등록에 실패하였습니다." + ex.ToString());

                helper.Rollback();
            }
            finally
            {
                helper.Close();
            }


            #endregion



            #region <공통정보 초기화 및 메뉴 그룹 초기화>

            //공통정보 초기화
            Common.userId = "";
            Common.userAutority = "";
            Common.loginStatus = false;

            //상태창 초기화
            stsUserId.Text = "";

            //메뉴 초기화
            menus.Groups.Clear();

            //탭 컨트롤 초기화
            myTabControl1.TabPages.Clear();

            //메뉴검색 목록 초기화
            menuList.Clear();
            #endregion
        }

        #endregion

        #region < 메인이미지 숨김 이벤트 >
        private void mainImageClose()
        {
            picMainImg.Dock = DockStyle.Fill;
            picMainImg.Visible = true;
            picMainImg.BringToFront();
            myTabControl1.Dock = DockStyle.None;
            myTabControl1.SendToBack();
        }

        #endregion

        #region < 메세지popup  >
        public static void ShowMsg(string v)
        {
            DialogForm form1 = new DialogForm(v);
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
                if (yesOrNo == "YES") returnVal = DialogResult.Yes;

            }

            return returnVal;

        }

        #endregion 

        #endregion


    }
}