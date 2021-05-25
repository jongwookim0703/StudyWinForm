using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Transactions;

namespace Dev_Form
{
    public partial class FM_ITEM : Form
    {
        private SqlConnection Connect = null;  // 접속정보 객체명명
        // 접속 주소
        private string strConn = "Data Source =61.105.9.203; Initial Catalog = AppDev;User ID=kfqs1;Password = 1234";
        
        public FM_ITEM()
        {
            InitializeComponent();
        }

        private void FM_ITEM_Load(object sender, EventArgs e)
        {
            try
            {
                // 콤보박스 품목상세 데이터 조회 및 추가
                // 접속정보 커넥션에 등록 및 객체선언
                Connect = new SqlConnection(strConn);
                Connect.Open();

                if (Connect.State != System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("데이터 베이스 연결에 실패하였습니다.");
                    return;
                }

                // 조회할땐 어댑터가 필요하다
                // "", 값을 넣을때 ssms에서 실행해보고 검증해보고 넣는게 좋다
                SqlDataAdapter adapter = new SqlDataAdapter("select distinct ITEMDESC from TB_TESTITEM_KJW ", Connect);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // 콤보박스에 맵핑시키기
                cboItemDesc.DataSource = dtTemp;
                cboItemDesc.DisplayMember = "ITEMDESC";   // 눈으로 보여줄 항목
                cboItemDesc.ValueMember = "ITEMDESC";     // 실제 데이터를 처리할 코드 항목
                cboItemDesc.Text = "";


                // 출시일자 원하는 날짜 픽스
                dtpStart.Text = string.Format("{0:yyyy-MM-01}", DateTime.Now);

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
        private void btnSearch_Click(object sender, EventArgs e)
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
                // 조회를 위한 파라미터 설정
                string sItemCode = txtItemCode.Text;   //품목 코드
                string sItemName = txtItemName.Text;   //품목 명
                string sStartDate = dtpStart.Text;     //출시 시작일자
                string sEndDate = dtpEnd.Text;         //출시 종료일자
                string sItemdesc = cboItemDesc.Text;   //품목 상세

                string sEndFlag = "N";
                if (rdoEnd.Checked == true) sEndFlag = "Y"; // 단종여부
                if (chkNameOnly.Checked == true) sItemCode = ""; // 이름으로만 검색

                SqlDataAdapter adapter = new SqlDataAdapter("SELECT ITEMCODE,  "  +  
                                                            "       ITEMNAME,  "  +  
                                                            "       ITEMDESC,  "  +  
                                                            "       ITEMDESC2, "  +
                                                            "       CASE WHEN ENDFLAG = 'Y' Then '단종'"             +
                                                            "       WHEN ENDFLAG = 'N' Then '생산' END AS ENDFLAG, " +  
                                                            "       PRODDATE,  "  +  
                                                            "       MAKEDATE,  "  +  
                                                            "       MAKER,     "  +  
                                                            "       EDITDATE,  "  +  
                                                            "       EDITOR     "  +  
                                                            "       FROM TB_TESTITEM_KJW WITH(NOLOCK) "          +
                                                            "       WHERE ITEMCODE LIKE '%" + sItemCode + "%' "  +
                                                            "       AND ITEMNAME LIKE '%" + sItemName + "%' "    +
                                                            "       AND ITEMDESC LIKE '%" + sItemdesc + "%' "    +
                                                            "       AND ENDFLAG = '" + sEndFlag + "'"            +
                                                            "       AND PRODDATE BETWEEN '" + sStartDate + "'AND'" + sEndDate + "'"
                                                            , Connect);

                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {   // 조회할 데이터가 없을 때 초기화하라
                    dgvGrid.DataSource = null;
                    return;
                }
                    
                dgvGrid.DataSource = dtTemp;    //데이터그리드 뷰에 데이터 테이블등록

                // 그리드뷰의 헤더 명칭 선언 (칼럼명칭지정)
                dgvGrid.Columns["ITEMCODE"].HeaderText  = "품목 코드";
                dgvGrid.Columns["ITEMNAME"].HeaderText  = "품목 명";
                dgvGrid.Columns["ITEMDESC"].HeaderText  = "품목 상세";
                dgvGrid.Columns["ITEMDESC2"].HeaderText = "품목 상세2";
                dgvGrid.Columns["ENDFLAG"].HeaderText   = "단종 여부";
                dgvGrid.Columns["MAKEDATE"].HeaderText  = "등록 일시";
                dgvGrid.Columns["MAKER"].HeaderText     = "등록자";
                dgvGrid.Columns["EDITDATE"].HeaderText  = "수정일시";
                dgvGrid.Columns["EDITOR"].HeaderText    = "수정자";

                // 그리드뷰의 폭 지정
                dgvGrid.Columns[0].Width = 100;
                dgvGrid.Columns[1].Width = 200;
                dgvGrid.Columns[2].Width = 200;
                dgvGrid.Columns[3].Width = 200;
                dgvGrid.Columns[4].Width = 150;

                // 컬럼의 수정 여부를 지정한다
                dgvGrid.Columns["ITEMCODE"].ReadOnly = true;
                dgvGrid.Columns["MAKER"].ReadOnly    = true;
                dgvGrid.Columns["MAKEDATE"].ReadOnly = true;
                dgvGrid.Columns["EDITDATE"].ReadOnly = true;
                dgvGrid.Columns["EDITOR"].ReadOnly   = true;
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Connect.Close();
            }
        }

        // 데이터 그리드뷰에 신규행 추가
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)dgvGrid.DataSource).NewRow();
            ((DataTable)dgvGrid.DataSource).Rows.Add(dr);
            dgvGrid.Columns["ITEMCODE"].ReadOnly = false;
        }
        // 선택된 행을 삭제한다
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dgvGrid.Rows.Count == 0) return;
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
                string Itemcode = dgvGrid.CurrentRow.Cells["ITEMCODE"].Value.ToString();
                cmd.CommandText = "DELETE TB_TESTITEM_KJW WHERE ITEMCODE = '" + Itemcode + "'";

                cmd.ExecuteNonQuery();      //delete실행

                // 성공 시 DB Commit
                tran.Commit();
                MessageBox.Show("정상적으로 삭제하였습니다.");
                btnSearch_Click(null, null);  // 조회, 데이터삭제후 보여주려고
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

        // 데이터그리드뷰에서 저장버튼 누르기
        private void btnSave_Click(object sender, EventArgs e)
        {
            // 선택된 행 데이터 저장
            if (dgvGrid.Rows.Count == 0) return;        //-- 저장할 행이 없으면 리턴하라
            if (MessageBox.Show("선택된 데이터를 등록 하시겠습니까?", "데이터등록", 
                MessageBoxButtons.YesNo) == DialogResult.No) 
                return;

            string sItemCode = dgvGrid.CurrentRow.Cells["ITEMCODE"].Value.ToString();
            string sItemName = dgvGrid.CurrentRow.Cells["ITEMNAME"].Value.ToString();
            string sItemDesc = dgvGrid.CurrentRow.Cells["ITEMDESC"].Value.ToString();
            string sItemDesc2 = dgvGrid.CurrentRow.Cells["ITEMDESC2"].Value.ToString();
            string sItemEndFlag = dgvGrid.CurrentRow.Cells["ENDFLAG"].Value.ToString();
            string sProdDate = dgvGrid.CurrentRow.Cells["PRODDATE"].Value.ToString();

            SqlCommand cmd = new SqlCommand();
            SqlTransaction Tran;

            Connect = new SqlConnection(strConn);
            Connect.Open();

            // 데이터 조회 후 해당 데이터가 있는지 확인 후 UPDATE, INSERT 구문 분기
            //string sSql = "SELECT ITEMCODE FROM TB_TESTITEM_KJW WHERE ITEMCODE = '" + sItemCode + "'";
            //SqlDataAdapter adapter = new SqlDataAdapter(sSql, Connect);
            //DataTable dtTemp = new DataTable();
            //adapter.Fill(dtTemp);

            // 트랜잭션 설정
            Tran = Connect.BeginTransaction("TestTran");
            cmd.Transaction = Tran;
            cmd.Connection = Connect;

            //두 개를 한번에 처리하는함수
            cmd.CommandText = "UPDATE TB_TESTITEM_KJW " +
                                      "    SET ITEMNAME = '" + sItemName + "',    " +
                                      "        ITEMDESC = '" + sItemDesc + "',    " +
                                      "        ITEMDESC2 = '" + sItemDesc2 + "',  " +
                                      "        ENDFLAG = '" + "N" + "',           " +
                                      "        PRODDATE = '" + sProdDate + "',    " +
                                      "        EDITOR = '"    + Common.LogInId + "',  " +
                                      "        EDITDATE = GETDATE()               " +
                                      "  WHERE ITEMCODE = '" + sItemCode + "'     " +
                                      " IF (@@ROWCOUNT =0) " +
                                      "INSERT INTO TB_TESTITEM_KJW(ITEMCODE,           ITEMNAME,            ITEMDESC,           ITEMDESC2,          ENDFLAG,           PRODDATE,      MAKEDATE,     MAKER) " +
                                      "VALUES('" + sItemCode + "','" + sItemName + "','" + sItemDesc + "','" + sItemDesc2 + "','" + "N" + "','" + sProdDate + "',GETDATE(),'" + Common.LogInId + "')";

            // 데이터가 있는경우 UPDATE, 없는경우 INSERT
            //if (dtTemp.Rows.Count == 0)
            //{
            //    // 데이터가 없으니 INSERT 해라
            //    cmd.CommandText = "INSERT INTO TB_TESTITEM_KJW (ITEMCODE, ITEMNAME, ITEMDESC, ITEMDESC2, ENDFLAG, PRODDATE, MAKEDATE, MAKER) " +
            //                      "VALUES ('" + sItemCode + "', '" + sItemName + "', '" + sItemDesc + "', '" + sItemDesc2 + "', '" + "N" + "', '" + sProdDate + "',GETDATE(),'" + "')";
            //}
            //else
            //{
            //    // 데이터가 이미있으니 UPDATE 해라
            //    cmd.CommandText = cmd.CommandText = "UPDATE TB_TestItem_KJW                              " +
            //                                        "    SET ITEMNAME = '" + sItemName + "',             " +
            //                                        "        ITEMDESC = '" + sItemDesc + "',             " +
            //                                        "        ITEMDESC2 = '" + sItemDesc2 + "',           " +
            //                                        "        ENDFLAG = '" + "N" + "',           " +
            //                                        "        PRODDATE = '" + sProdDate + "',             " +
            //                                        "        EDITOR = '',  " +
            //                                      //"        EDITOR = '"    + Commoncs.LoginUserID + "', " +
            //                                        "        EDITDATE = GETDATE()                        " +
            //                                        "  WHERE ITEMCODE = '" + sItemCode + "'              ";
            //}
            cmd.ExecuteNonQuery(); //위에작성한쿼리를 실행하라

            // 성공 시 DB COMMIT
            Tran.Commit();
            MessageBox.Show("정상적으로 등록하였습니다.");
            Connect.Close();
        }
    }
}
