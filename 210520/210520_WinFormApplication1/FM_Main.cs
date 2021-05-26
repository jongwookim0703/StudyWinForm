using System;
using System.Reflection;
using System.Windows.Forms;
using Dev_Form;


namespace _210520_WinFormApplication1
{
    public partial class FM_Main : Form
    {
        public FM_Main()
        {
            InitializeComponent();  // 무조건있어야됨
            //로그인폼 호출
            FM_Login login = new FM_Login();
            login.ShowDialog();

            tssUserName.Text = login.Tag.ToString();  
            if (login.Tag.ToString() == "Fail")
            {
                System.Environment.Exit(0);    // 닫기창 눌렀을 때 닫히게하는것
            }

            // 메뉴 클릭 이벤트 추가
            // M시스템에서 드롭다운을 눌렀을 때           new 이내용으로 실행해라
            this.M_SYSTEM.DropDownItemClicked +=
                new System.Windows.Forms.ToolStripItemClickedEventHandler(this.M_SYSTEM_DropDownItemClicked);

            // 버튼 닫기 이벤트 추가
            this.stbClose.Click += new System.EventHandler(this.stbClose_Click);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void stbClose_Click(object sender, EventArgs e)
        {
            // 열려있는 화면이 있는지 확인
            if (myTabControl1.TabPages.Count == 0) return;
            // 선택된 탭페이지를 닫는다
            myTabControl1.SelectedTab.Dispose();
        }


        // 조회 버튼 이벤트 추가
        private void stbSearch_Click(object sender, EventArgs e)
        {
            ChildCommand("SEARCH");
        }
        // 추가 버튼 이벤트 추가
        private void stbInsert_Click(object sender, EventArgs e)
        {
            ChildCommand("NEW");
        }
        // 제거 버튼 이벤트 추가
        private void stbDelete_Click(object sender, EventArgs e)
        {
            ChildCommand("DELETE");
        }
        // 저장 버튼 이벤트 추가
        private void stbSave_Click(object sender, EventArgs e)
        {
            ChildCommand("SAVE");
        }
        // 종료 버튼 이벤트 추가
        private void stbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        // 타이머 툴바 시간
        private void timer1_Tick(object sender, EventArgs e)
        {
            tssNowDate.Text = DateTime.Now.ToString();
        }

        private void M_SYSTEM_Click(object sender, EventArgs e)
        {

        }
        private void M_SYSTEM_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //// 1. 단순히 폼을 호출하는 경우.
            // 폼안에 부모와 자식관계를 만들어준다
            // isMDicontainer = true 로 수정 후 
            //Dev_Form.MDI_TEST Form = new MDI_TEST();
            //Form.MdiParent = this;
            //Form.Show();

            //// 2. 프로그램을 호출
            // 내가 메뉴를 클릭했을 때 내가 클릭한 메뉴이름이랑 똑같은 이름을 가진폼을 출력해라 어디서? Dev_Form에서
            Assembly assemb = Assembly.LoadFrom(Application.StartupPath + @"\" + "Dev_Form.dll");  // Dev_Form.DLL이라는 파일을 가져와라
            Type typeForm = assemb.GetType("Dev_Form." + e.ClickedItem.Name.ToString(), true);
            Form ShowForm = (Form)Activator.CreateInstance(typeForm);

            //// 해당되는 폼이 이미 오픈되어 있는지 확인 후 활성화 또는 신규오픈 한다
            for (int i = 0; i < myTabControl1.TabPages.Count; i++)
            {
                if (myTabControl1.TabPages[i].Name == e.ClickedItem.Name.ToString())
                {
                    myTabControl1.SelectedTab = myTabControl1.TabPages[i];
                    return;
                }
            }



            //ShowForm.MdiParent = this;
            //ShowForm.Show();
            myTabControl1.AddForm(ShowForm);    // 탭페이지에 폼을 추가하여 오픈한다
        }

        //  Child인터페이스 브릿지
        private void ChildCommand(string Command)
        {
            if (this.myTabControl1.TabPages.Count == 0) return;
            var Child = myTabControl1.SelectedTab.Controls[0] as Dev_Form.ChildInterface;
            switch (Command)
            {
                case "NEW"   : Child.DoNew();    break;
                case "SAVE"  : Child.Save();     break;
                case "SEARCH": Child.Inquire();  break;
                case "DELETE": Child.Delete();   break;
            }
        }
    }

    // 도구상자에 나만의 사용자정의 탭컨트롤을 만든다
    public partial class MDIForm : TabPage
    {

    }
    public partial class MyTabControl : TabControl
    {
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;       // 인자로 받은 폼이 없을경우 시행 중지
            NewForm.TopLevel = false;          // 인자로 받은 폼이 최상위 개체가 아님을 선언
            MDIForm page = new MDIForm();      // 탭 페이지 객체 생성
            page.Controls.Clear();             // 페이지 초기화
            page.Controls.Add(NewForm);        // 페이지에 폼 추가
            page.Text = NewForm.Text;          // 폼에서 지정한 명칭으로 탭 페이지 설정
            page.Name = NewForm.Name;          // 폼에서 설정한 이름으로 탭 페이지 설정
            base.TabPages.Add(page);           // 탭 컨트롤에 페이지를 추가한다
            NewForm.Show();                    // 인자로 받은 폼을 보여준다
            base.SelectedTab = page;           // 현재 선택된 페이지를 호출한 폼의 페이지로 설정한다
        }
    }
}
