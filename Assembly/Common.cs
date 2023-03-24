using Infragistics.Win.UltraDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using DC00_assm;
using Infragistics.Win.UltraWinEditors;

namespace Assemble
{
    public static class Common
    {
        //DB 접속 정보
        public const string sConn = "Data Source=222.235.141.8; Initial Catalog=KDTB_1JO; User ID= 1JO ; Password= 1234";
        public static string userId = "";
        public static string userAutority = "";
        public static bool loginStatus = false;


        public static DataTable StandardCode(string columnName)
        {
            DBHelper helper = new DBHelper();
            DataTable dtTemp = new DataTable(); 
            try
             {
                string sql = "";
                sql += $"SELECT ''    AS CODE_ID                             ";
                sql += $"      ,'ALL' AS CODE_NAME                           ";
                sql += $"UNION ALL                                           ";
                sql += $"SELECT MINORCODE                        AS CODE_ID  ";
                sql += $"      ,'[' + MINORCODE + ']' + CODENAME AS CODE_NAME";
                sql += $"  FROM TB_Standard                                  ";
                sql += $" WHERE MAJORCODE = '{columnName}'                     ";
                sql += $"   AND MINORCODE <> '$'                              ";
                dtTemp = helper.FillTable(sql);
                

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            return dtTemp; 
        }

        public static void setComboBox(UltraComboEditor comboBox, DataTable dtTemp)
        {

            comboBox.DataSource = dtTemp;
            comboBox.DisplayMember = "CODE_NAME";
            comboBox.ValueMember = "CODE_ID";
            comboBox.Value = "";
            comboBox.SelectedIndex = 0; // 기본값 세팅
        }

        // 공통기준정보 테이블 조회 메서드(메이저 코드 조건)
        public static DataTable standardCode01(string columnName)
        {
            DBHelper helper = new DBHelper();
            DataTable dtTemp = new DataTable();

            try
            {
                string sql = "";

                sql += $"SELECT MAJORCODE AS CODE_ID  ";
                sql += $"     , CODENAME  AS CODE_NAME";
                sql += $" FROM TB_Standard            ";
                sql += $"WHERE MINORCODE = '$'        ";

                dtTemp = helper.FillTable(sql);


                //string sql = $"SELECT DISTINCT B.MAJORCODE";
                //       sql += $" FROM TB_Standard A RIGHT JOIN TB_Authority B ON A.MAJORCODE = B.MAJORCODE";

                //      dtTemp = helper.FillTable(sql);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            return dtTemp;
        }


        // 공통기준정보 테이블 조회 메서드(메이저 코드 조건)
        public static DataTable standardCode02(string majorCode)
        {
            DBHelper helper = new DBHelper();
            DataTable dtTemp = new DataTable();

            try
            {
                string sql = "";
                sql += $"SELECT '' AS CODE_ID                                 ";
                sql += $"      ,'ALL' AS CODE_NAME                            ";
                sql += $"  UNION ALL                                          ";
                sql += $" SELECT MINORCODE AS CODE_ID                         ";
                sql += $"       ,'[' + MINORCODE + ']' + CODENAME AS CODE_NAME";
                sql += $"   FROM TB_Standard                                  ";
                sql += $"  WHERE MAJORCODE = '{majorCode}'                     ";
                sql += $"    AND MINORCODE<> '$';                             ";




                dtTemp = helper.FillTable(sql);


                //string sql = $"SELECT DISTINCT B.MAJORCODE";
                //sql += $" FROM TB_Standard A RIGHT JOIN TB_Authority B ON A.MAJORCODE = B.MAJORCODE";

                //dtTemp = helper.FillTable(sql);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }

            return dtTemp;
        }


    }
}
