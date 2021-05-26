using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _210520_WinFormApplication1
{
    public partial class FM_Login : Form
    {
        private SqlConnection Connect = null;
        public FM_Login()
        {
            InitializeComponent();
            this.Tag = "Fail";       // 딱 한가지 경우에만 못씀 : UserName이 Fail일 때
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            //비밀번호 변경 화면 팝업을 호출한다
            this.Visible = false;       //로그인 화면을 보이지 않게함
            FM_Password FmPAssword = new FM_Password();
            FmPAssword.ShowDialog();    //한 개창만 컨트롤할 수 있게 나옴
            this.Visible = true;        //비밀번호변경을 닫았을 때 다시 로그인창나오게함
            // FmPAssword.Show();       //두 개창을 다 쓸 수 있음
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {   // 1. 데이터베이스 접속경로 설정
            string strCon = "Data Source =61.105.9.203; Initial Catalog = AppDev;User ID=kfqs1;Password = 1234";
            Connect = new SqlConnection(strCon);
            // 2. 데이터베이스 연결상태확인
            Connect.Open();
            string sLoginid = string.Empty;
            string sPerPw = string.Empty;
            sLoginid = txtID.Text;
            sPerPw = txtPassword.Text;
            // 기존의 비밀번호 찾기
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT PW,USERNAME FROM TB_USER_KJW WHERE USERID = '" + sLoginid + "' ", Connect);
            DataTable DtTemp2 = new DataTable();
            Adapter.Fill(DtTemp2);
            if (DtTemp2.Rows[0]["PW"].ToString() == sPerPw)
            {
                MessageBox.Show("반갑습니다 ^^.");
                this.Close();
                Common.LogInId = txtID.Text;
                Common.LogInName = DtTemp2.Rows[0]["USERNAME"].ToString();  // 유저 명을 Common에 등록함
                this.Tag = DtTemp2.Rows[0]["USERNAME"].ToString(); // 유저네임 
                this.Close();
                return;
            }
            else if (DtTemp2.Rows[0]["PW"].ToString() != sPerPw)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }
        }

        private void FM_Login_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        // 비밀번호상자에서 ENTER키를 눌러도 로그인 할 수 있게 하기
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
