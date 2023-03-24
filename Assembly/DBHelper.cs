using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assemble
{
    public class DBHelper
    {
        public SqlConnection sCon;
        private SqlCommand cmd;
        private SqlTransaction sTran;
        private SqlDataAdapter adapter;
        public string RS_CODE = "S";
        public string RS_MSG = "";


        public DbProviderFactory dataFactory;


        private bool Init(bool bTran)
        {
            try
            {
                dataFactory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                sCon = new SqlConnection(Common.sConn);
                sCon.Open();
                if (bTran)
                {
                    sTran = sCon.BeginTransaction();
                }
                //MessageBox.Show("db 접속~!!");
                return true;
            }
            catch (Exception ex)
            {
                Close();
                MessageBox.Show("DB 접속에 실패하였습니다.");
                return false;

            }
        }

        //DB Connection 시 트랜잭션 유무
        public DBHelper()
        {
            //트랜잭션 미사용
            Init(false);

        }

        public DBHelper(bool bTran)
        {
            //트랜잭션 사용/미사용 선택
            Init(bTran);

        }

        //sql 조회
        public DataTable FillTable(string sql)
        {
            adapter = new SqlDataAdapter(sql, sCon);
            DataTable dtTemp = new DataTable();
            adapter.Fill(dtTemp);
            return dtTemp;

        }

        //public DataTable FillTable(string query, CommandType commandType, params object[] parameters)
        //{
        //    cmd = sCon.CreateCommand();
        //    cmd.Connection = sCon;
        //    cmd.CommandText= query;
        //    cmd.CommandType = commandType;
        //    RS_CODE = "S";
        //    RS_MSG = string.Empty;

        //    if(parameters != null)
        //    {
        //        for(int i = 0; i < parameters.Length; i++)
        //        {
        //            cmd.Parameters.Add(parameters[i]);
        //        }
        //    }
        //}

        //프로시져용 조회파라미터 세팅
        public void SelectParameter(string name, string value)
        {
            adapter.SelectCommand.Parameters.AddWithValue(name, value);

        }

        //프로시져용 저장 파라미터 세팅
        public void AddParameter(string name, string value)
        {
            cmd.Parameters.AddWithValue(name, value);
        }
        public void AddParameter(string name, object value)
        {
            cmd.Parameters.AddWithValue(name, value);
        }

        //조회 프로시져 준비 
        public void SPSet_Select(string name)
        {
            adapter = new SqlDataAdapter(name, sCon);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand.Parameters.AddWithValue("@LANG", "KO");
            adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
            adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;
        }

        //저장 프로시저 준비
        public void SPSet_Add(string name)
        {
            cmd = new SqlCommand();
            cmd.Transaction = sTran;
            cmd.Connection = sCon;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = name;


            cmd.Parameters.AddWithValue("@LANG", "KO");
            cmd.Parameters.Add(CreateParameter("RS_CODE", DbType.String, ParameterDirection.Output, null, 1));
            cmd.Parameters.Add(CreateParameter("RS_MSG", DbType.String, ParameterDirection.Output, null, 200));


        }


        public DbParameter CreateParameter(string parameterName, DbType DbType, ParameterDirection parameterDirection, object value, int? size)
        {
            DbParameter dbParameter = null;
            try
            {
                dbParameter = dataFactory.CreateParameter();
                dbParameter.ParameterName = parameterName.ToUpper();
                dbParameter.DbType = DbType;
                dbParameter.Direction = parameterDirection;
                dbParameter.Value = value;
                if (size.HasValue)
                {
                    dbParameter.Size = size.Value;
                    return dbParameter;
                }

                return dbParameter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //조회 프로시져 실행
        public DataTable SPRun_Select()
        {
            DataTable temp = new DataTable();
            adapter.Fill(temp);

            //RS_CODE = Convert.ToString(cmd.Parameters["@RS_CODE"].Value);
            //RS_MSG  = Convert.ToString(cmd.Parameters["@RS_MSG"].Value);

            return temp;
        }

        //저장 프로시져 실행
        public void SPRun_Add()
        {
            cmd.ExecuteNonQuery();

            RS_CODE = Convert.ToString(cmd.Parameters["RS_CODE"].Value);
            RS_MSG = Convert.ToString(cmd.Parameters["RS_MSG"].Value);
        }

        public void Commit()
        {
            if (sTran != null)
            {
                sTran.Commit();
                sTran = null;
            }
        }

        public void Rollback()
        {
            if (sTran != null)
            {
                sTran.Rollback();
                sTran = null;
            }
        }

        public void Close()
        {
            sCon.Close();
        }
    }
}