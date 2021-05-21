using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dev_Form;


namespace _210520_WinFormApplication1
{
    public partial class FM_Main : Form
    {
        public FM_Main()
        {
            InitializeComponent();  // 무조건있어야됨
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
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void stbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            Form MDI_TEST = (Form)Activator.CreateInstance(typeForm);

            MDI_TEST.MdiParent = this;
            MDI_TEST.Show();

        }
    }
}
