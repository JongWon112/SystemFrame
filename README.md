# SystemFrame
winform 기반 Infragistic 상용 컴포넌트를 사용한 시스템 프레임 구축


## 1. 메뉴 클릭 이벤트
 - Source
<pre>
<code>
// 메뉴 클릭 이벤트
 private void menus_ItemClick(string menuName)
        {
            //Form 리스트를 로드
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
                //클릭한 메뉴가 이미 열려있는 메뉴면 탭페이지 선택 변경
                if (page.Name == menuName)
                {
                    check = true;
                    myTabControl1.SelectedTab = page;
                    break;
                }
            }

            //열려있지않은 메뉴 탭페이지에 오픈
            if (!check) myTabControl1.AddForm(FormMdi);
            
            //상태창 초기화
            stsFormName.Text = myTabControl1.SelectedTab.Text;
        }

</code>
</pre>
<pre>
<code>
// Form을 보여줄 탭 컨트롤 컴포넌트
    //Tab 컨트롤 상속받아 사용
    public class MyTabControl : TabControl  
    {
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return; //인자로 받는 폼이 없을경우  실행 중지.
            NewForm.TopLevel = false; // 추가로 호출된 후속Form이 두번째, 새ㅔ번재 순으로 생성 되도록 설정.
            TabPage page = new TabPage(); // 탭 페이지 객체 생성.

            page.Controls.Clear(); // 페이지 초기화
            page.Controls.Add(NewForm); // 페이지에 폼 추가
            page.Text = NewForm.Text; // 폼에서 설정한 명칭으로 탭 페이지 고유 명칭 설정.
            page.Name = NewForm.Name; // 폼에서 설정한 이름으로 탭 페이지 고유 이름 설정.
            
            base.TabPages.Add(page); // 탭 컨트롤에 페이지를 추가한다.
            NewForm.Show();          // 인자로 받은 폼 페이지를 보여준다.
            base.SelectedTab = page; // 부모 컨트롤 TabCotrol에서 현재 선택된 페이지를 호출한 폼의 페이지로 설정.
        }
    }

</code>
</pre>

 - 화면
 
![메인화면](https://github.com/JongWon112/SystemFrame/blob/main/images/main.png)
메인화면
![폼 오픈](https://github.com/JongWon112/SystemFrame/blob/main/images/FormOpen.png)
폼 오픈 화면


## 2. 로그인 권한 별 메뉴 구성
 - Source
<pre>
<code>
   #region < 권한 별 메뉴 구성 >
            //1. 그룹 구성
            // 로그인 유저 별 메뉴 가져오기
            helper = new DBHelper();
            try
            {
                //로그인 사용자의 권한이 있는 메뉴 Key,Value 값을 가져온다.
                
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
                    //구성할 메뉴가 상위메뉴인지 하위 메뉴인지 확인
                    if (dtRow["MENU_ID"].ToString() == dtRow["PARENT_ID"].ToString())
                    {
                        //상위 메뉴 그룹으로 구성
                        menus.Groups.Add(key, value);
                        groupText = key;
                        continue;
                    }

                    // 하위 메뉴로 구성
                    menus.Groups[groupText].Items.Add(key, value);

                }


                //사용 가능한 메뉴 검색 콤보박스 세팅
                SetMenuSearch();

            }
            catch(Exception ex)
            {
                ShowMsg("메뉴 구성에 실패하였습니다." + ex.ToString());
            }
            finally { helper.Close(); }

            #endregion

</code>
</pre>

 - 화면
 
![사용자별 메뉴](https://github.com/JongWon112/SystemFrame/blob/main/images/Authority.png)
사용자별 메뉴
![사용자별 메뉴 조회](https://github.com/JongWon112/SystemFrame/blob/main/images/Authority_Table.png)
사용자별 메뉴 조회
