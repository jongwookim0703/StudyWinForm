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
        {
            string strCon = "Data Source =61.105.9.203; Initial Catalog = AppDev;User ID=kfqs;Password = 1234";
            Connect = new SqlConnection(strCon);
            Connect.Open();
            string sLoginid = string.Empty;
            string sPerPw = string.Empty;
            sLoginid = txtID.Text;
            sPerPw = txtPassword.Text;
            SqlDataAdapter Adapter = new SqlDataAdapter("SELECT PW FROM TB_USER_KJW WHERE USERID = '" + sLoginid + "' ", Connect);
            DataTable DtTemp2 = new DataTable();
            Adapter.Fill(DtTemp2);
            if (DtTemp2.Rows[0]["PW"].ToString() == sPerPw)
            {
                MessageBox.Show("반갑습니다 ^^.");
                return;
            }
            else if (DtTemp2.Rows[0]["PW"].ToString() != sPerPw)
            {
                MessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }
            else
            {
                MessageBox.Show("반갑습니다 ^^");
            }
        }

        private void FM_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
