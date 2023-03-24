using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assemble
{
    public class MyTabControl : TabControl
    {
        //생성자
        public MyTabControl() 
        {            //this.DrawMode = TabDrawMode.OwnerDrawFixed;

        }
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return; //인자로 받는 폼이 없을경우  실행 중지.
            NewForm.TopLevel = false; // 추가로 호출된 후속Form이 두번째, 새ㅔ번재 순으로 생성 되도록 설정.
            TabPage page = new TabPage(); // 탭 페이지 객체 생성.

            page.Controls.Clear(); // 페이지 초기화
            page.Controls.Add(NewForm); // 페이지에 폼 추가
            page.Text = NewForm.Text; // 폼에서 설정한 명칭으로 탭 페이지 고유 명칭 설정.
            page.Name = NewForm.Name; // 폼에서 설정한 이름으로 탭 페이지 고유 이름 설정.

            // !!! base : 상속 해준 클래스를 지칭.
            base.TabPages.Add(page); // 탭 컨트롤에 페이지를 추가한다.
            NewForm.Show();          // 인자로 받은 폼 페이지를 보여준다.
            base.SelectedTab = page; // 부모 컨트롤 TabCotrol에서 현재 선택된 페이지를 호출한 폼의 페이지로 설정.

        }
    }
}
