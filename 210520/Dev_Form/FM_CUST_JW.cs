using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Dev_Form
{
    public partial class FM_CUST_JW : Form
    {
        private SqlConnection Connect = null;  // 접속정보 객체명명
        private string strConn = "Data Source =222.235.141.8; Initial Catalog = AppDev;User ID=kfqs1;Password = 1234";


        public FM_CUST_JW()
        {
            InitializeComponent();
        }

        private void FM_CUST_Load(object sender, EventArgs e)
        {
            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
                    return;
                }
                SqlDataAdapter adapter = new SqlDataAdapter("select distinct CUSTTYPE from TB_CUST_KJW ", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // 출시일자 원하는 날짜 픽스
                dtpStartC.Text = string.Format("{0:2018-MM-01}", DateTime.Now);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Connect.Close();
            }
        }
        // 조회 클릭 이벤트
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Connect = new SqlConnection(strConn);
                Connect.Open();
                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
                    return;
                }
                string cCustCode = txtcustcodeC.Text;   //거래처 코드
                string cCustName = txtcustnameC.Text;   //거래처 명
                string cStartDate = dtpStartC.Text;     //출시 시작일자
                string cEndDate   = dtpEndC.Text;       //출시 종료일자
                string cCustType = string.Empty;

                string cBIZTYPE = "상용차 부품";
                if (rbo1C.Checked == true) cBIZTYPE = "상용차 부품"; // 사용여부
                if (rbo2C.Checked == true) cBIZTYPE = "자동차부품";  // 사용여부
                if (rbo3C.Checked == true) cBIZTYPE = "절삭가공";    // 사용여부
                if (rbo4C.Checked == true) cBIZTYPE = "펌프압축기";  // 사용여부
                if (chkCustOnlyC.Checked == true) 
                {
                    cCustType = "C";
                }  // 고객사만 검색
                else cCustType = "";

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT CUSTCODE,  " +
                                                            "       CASE WHEN CUSTTYPE = 'C' THEN '고객사'" +
                                                            "       WHEN CUSTTYPE = 'V' Then '협력사' END AS CUSTTYPE, " +
                                                            "       CUSTNAME,  " +
                                                            "       BIZCLASS,  " +
                                                            "       BIZTYPE,   " +
                                                            "       CASE WHEN USEFLAG = 'N' THEN '미사용'" +
                                                            "       WHEN USEFLAG = 'Y' THEN '사용' END AS USEFLAG," +
                                                            "       FIRSTDATE, " +
                                                            "       MAKEDATE,  " +
                                                            "       MAKER,     " +
                                                            "       EDITDATE,  " +
                                                            "       EDITOR     " +
                                                            "       FROM TB_CUST_KJW WITH(NOLOCK) "             +
                                                            "       WHERE CUSTCODE LIKE '%" + cCustCode + "%' " +
                                                            "       AND CUSTNAME LIKE '%" + cCustName + "%' "   +
                                                            "       AND CUSTTYPE  LIKE '%" + cCustType + "%'"   +
                                                            "       AND BIZTYPE = '" + cBIZTYPE + "'"           +
                                                            "       AND FIRSTDATE BETWEEN '" + cStartDate + "'AND'" + cEndDate + "'"
                                                            , Connect);

                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {   // 조회할 데이터가 없을 때 초기화하라
                    MessageBox.Show("검색 조건에 맞는 데이터가 없습니다.");
                    dgvGridC.DataSource = null;
                    return;
                }

                dgvGridC.DataSource = dtTemp;    //데이터그리드 뷰에 데이터 테이블등록

                // 그리드뷰의 헤더 명칭 선언 (칼럼명칭지정)
                dgvGridC.Columns["CUSTCODE"].HeaderText = "거래처 코드";
                dgvGridC.Columns["CUSTTYPE"].HeaderText = "거래처타입";
                dgvGridC.Columns["CUSTNAME"].HeaderText = "거래처명";
                dgvGridC.Columns["BIZCLASS"].HeaderText = "업태";
                dgvGridC.Columns["BIZTYPE"].HeaderText = "종목";
                dgvGridC.Columns["USEFLAG"].HeaderText = "사용여부";
                dgvGridC.Columns["FIRSTDATE"].HeaderText = "거래일자";
                dgvGridC.Columns["MAKEDATE"].HeaderText = "등록일자";
                dgvGridC.Columns["MAKER"].HeaderText = "등록자";
                dgvGridC.Columns["EDITDATE"].HeaderText = "수정일시";
                dgvGridC.Columns["EDITOR"].HeaderText = "수정자";

                // 그리드뷰의 폭 지정
                dgvGridC.Columns[0].Width = 100;
                dgvGridC.Columns[1].Width = 80;
                dgvGridC.Columns[2].Width = 200;
                dgvGridC.Columns[3].Width = 80;
                dgvGridC.Columns[4].Width = 150;

                // 컬럼의 수정 여부를 지정한다
                dgvGridC.Columns["CUSTCODE"].ReadOnly = true;
                dgvGridC.Columns["CUSTTYPE"].ReadOnly = true;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvGridC.Rows.Count == 0) return;    
            DataRow dr = ((DataTable)dgvGridC.DataSource).NewRow();
            ((DataTable)dgvGridC.DataSource).Rows.Add(dr);
            dgvGridC.Columns["CUSTCODE"].ReadOnly = false;
            dgvGridC.Columns["CUSTTYPE"].ReadOnly = false;

            // 마지막에 추가된 행 선택
            int MaxRow = dgvGridC.Rows.Count - 1;
            dgvGridC.Rows[MaxRow].Selected = true;
            dgvGridC.CurrentCell = dgvGridC.Rows[MaxRow].Cells[0];
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.dgvGridC.Rows.Count == 0) return;
            if (MessageBox.Show("선택된 데이터를 삭제하시겠습니까", "데이터삭제", MessageBoxButtons.YesNo) == DialogResult.No) return;

            SqlCommand cmd = new SqlCommand();
            SqlTransaction tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();  //데이터베이스에 로그인

            // 트랜잭션 관리를 위한 권한 위임
            tran = Connect.BeginTransaction("TranStart");   // 트랜잭션시작
            cmd.Transaction = tran;
            cmd.Connection = Connect;

            try
            {
                string cCustcode = dgvGridC.CurrentRow.Cells["CUSTCODE"].Value.ToString();
                cmd.CommandText = "DELETE TB_CUST_KJW WHERE CUSTCODE = '" + cCustcode + "'";

                cmd.ExecuteNonQuery();      //delete실행

                // 성공 시 DB Commit
                tran.Commit();
                MessageBox.Show("정상적으로 삭제하였습니다.");
                button2_Click(null, null);  // 조회, 데이터삭제후 보여주려고
            }
            catch
            {
                tran.Rollback();
                MessageBox.Show("데이터삭제에 실패하였습니다.");
            }
            finally
            {
                Connect.Close();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // 선택된 행 데이터 저장
            if (dgvGridC.Rows.Count == 0) return;        //-- 저장할 행이 없으면 리턴하라
            if (MessageBox.Show("선택된 데이터를 등록 하시겠습니까?", "데이터등록",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string cCustCode = dgvGridC.CurrentRow.Cells["CUSTCODE"].Value.ToString();
            string cCustType = dgvGridC.CurrentRow.Cells["CUSTTYPE"].Value.ToString();
            string cCustName = dgvGridC.CurrentRow.Cells["CUSTNAME"].Value.ToString();
            string cBizClass = dgvGridC.CurrentRow.Cells["BIZCLASS"].Value.ToString();
            string cBizType = dgvGridC.CurrentRow.Cells["BIZTYPE"].Value.ToString();
            string cUseFlag = dgvGridC.CurrentRow.Cells["USEFLAG"].Value.ToString();
            string cProdDate = dgvGridC.CurrentRow.Cells["FIRSTDATE"].Value.ToString();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction Tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            Tran = Connect.BeginTransaction("TestTran");
            cmd.Transaction = Tran;
            cmd.Connection = Connect;

            //두 개를 한번에 처리하는함수
            cmd.CommandText = "UPDATE TB_CUST_KJW " +
                                      "    SET CUSTCODE = '" + cCustCode + "',    " +
                                      "        CUSTTYPE = '" + cCustType + "',    " +
                                      "        CUSTNAME = '" + cCustName + "',    " +
                                      "        BIZCLASS = '" + cBizClass + "',    " +
                                      "        BIZTYPE = '" + cBizType + "',      " +
                                      "        USEFLAG = '" + cUseFlag + "',      " +
                                      "        FIRSTDATE = '" + cProdDate + "',   " +
                                      "        EDITDATE = GETDATE()              ," +
                                      "        EDITOR = '" + Common.LogInId + "'  " +
                                      "  WHERE CUSTCODE = '" + cCustCode + "'     " +
                                      " IF (@@ROWCOUNT =0) " +
                                      "INSERT INTO TB_CUST_KJW(CUSTCODE,   CUSTTYPE,      CUSTNAME,           BIZCLASS,          BIZTYPE,           USEFLAG,      FIRSTDATE,                    EDITDATE     ,    EDITOR) " +
                                      "VALUES('" + cCustCode + "','" + cCustType + "','" + cCustName + "','" + cBizClass + "','" + cBizType + "','" + cUseFlag + "','" + cProdDate + "',GETDATE(),'" + Common.LogInId + "')";

            cmd.ExecuteNonQuery(); //위에작성한쿼리를 실행하라

            // 성공 시 DB COMMIT
            Tran.Commit();
            MessageBox.Show("정상적으로 등록하였습니다.");
            Connect.Close();
        }
    }
}

   
