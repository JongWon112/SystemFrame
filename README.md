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
 
![메인화면](https://raw.githubusercontent.com/JongWon112/studyASPNET/main/images/html_screen01.png)
메인화면
![라이트박스화면](https://github.com/JongWon112/studyASPNET/blob/main/images/html_screen03.png?raw=true)
라이트박스화면



1. 웹 기반기술 총복습
   - 핀터레스트 스타일 프론트엔드 연습
   - [소스](https://github.com/JongWon112/studyASPNET/tree/main/Day04/FrontendExec/Pages)
2. 결과화면


![메인화면](https://raw.githubusercontent.com/JongWon112/studyASPNET/main/images/html_screen01.png)
메인화면
![라이트박스화면](https://github.com/JongWon112/studyASPNET/blob/main/images/html_screen03.png?raw=true)
라이트박스화면
