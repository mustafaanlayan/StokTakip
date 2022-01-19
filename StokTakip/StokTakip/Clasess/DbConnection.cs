using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakip.Clasess
{
    class DbConnection
    {
        #region Degisken
        public SqlConnection sqlConn;
        private int commantTimeout = 600;
        #endregion
        #region Cons
        public DbConnection()
        {
            try
            {
                sqlConn = new SqlConnection();
                sqlConn.ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
                sqlConn.Open();
            }
            catch //(Exception)
            {

               
            }
            GC.Collect();
        }
           ~DbConnection()
        {
            try
            {
                if (sqlConn !=null)
                {
                    if (sqlConn.State !=System.Data.ConnectionState.Closed)
                    {
                        sqlConn.Close();
                    }
                    sqlConn.Dispose();
                    sqlConn = null;
                }
            }
            catch //(Exception)
            {

                
            }
            GC.Collect();
        }
        #endregion
        #region Fnk
        public void Close()
        {
            try
            {
                if (sqlConn !=null)
                {
                    if (sqlConn.State !=System.Data.ConnectionState.Closed)
                    {
                        sqlConn.Close();
                    }
                    sqlConn.Dispose();
                    sqlConn = null;
                }
            }
            catch //(Exception)
            {

            }
            GC.Collect();
        }
        //---------------------------
        public DataTable GetQuery(string prmQuery)
        {
            DataTable ret = null;

            try
            {
                ret = new DataTable();

                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();

                SqlDataAdapter sqlDataAdap = new SqlDataAdapter(prmQuery, sqlConn);
                sqlDataAdap.SelectCommand.CommandTimeout= this.commantTimeout;
                sqlDataAdap.Fill(ret);
                sqlDataAdap.Dispose();
                sqlDataAdap = null;
            }
            catch //(Exception)
            {

                ret = null;
            }
            finally
            {
                GC.Collect();
            }
            return ret;
        }
        //--------------------------
        public object RetStoredProc(string prmStoredProcName, List<SqlParameter> prmListSqlPar)
        {
            object ret = null;
            try
            {
                if (sqlConn.State !=ConnectionState.Open)
                {
                    sqlConn.Open();
                }

                SqlCommand cmd = new SqlCommand(prmStoredProcName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < prmListSqlPar.Count; i++)
                {
                    cmd.Parameters.Add(prmListSqlPar[i]);
                }

                ret = cmd.ExecuteScalar();
                cmd.Dispose();
                cmd = null;

            }
            catch //(Exception)
            {

                ret = null;
            }
            finally
            {
                GC.Collect();
            }
            return ret;
        }
        //-------------------------
        public DataTable RetStoredProcDataTable(string prmStoredProcName, List<SqlParameter> prmListSqlPar)
        {
            DataTable ret = new DataTable();

            try
            {
                if (sqlConn.State != ConnectionState.Open)
                    sqlConn.Open();

                SqlCommand cmd = new SqlCommand(prmStoredProcName, sqlConn);
                cmd.CommandType = CommandType.StoredProcedure;
                for (int i = 0; i < prmListSqlPar.Count; i++)
                {
                    cmd.Parameters.Add(prmListSqlPar[i]);
                }

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ret);
                da.Dispose();
                cmd.Dispose();
            }
            catch (Exception)
            {
                ret = null;
            }
            finally
            {
                GC.Collect();
            }

            return ret;

        }
        public object GetValue(string prmQuery, string prmColumn)
        {
            object ret = null;

            try
            {
                DataTable dt = this.GetQuery(prmQuery);
                if (dt.Rows.Count>0)
                    ret = dt.Rows[0][prmColumn];
                dt.Rows.Clear();
                dt.Dispose();

                
            }
            catch //(Exception e)
            {
            }
            GC.Collect();
            return ret;
        }
        #endregion
    }
}
