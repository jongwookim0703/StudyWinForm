using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _210520_WinFormApplication1
{
    public partial class FM_Login : Form
    {
        public FM_Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            //비밀번호 변경 화면 팝업을 호출한다
            FM_Password FmPAssword = new FM_Password();
            FmPAssword.ShowDialog();    //한 개창만 컨트롤할 수 있게 나옴
            // FmPAssword.Show();       //두 개창을 다 쓸 수 있음
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        private void FM_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
