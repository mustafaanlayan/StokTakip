using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraPrinting.Native.Lines;

namespace StokTakip.Clasess
{
    class Musteri
    {
        #region Değişkenler

        public int ID = -1;
        public bool IsSilindi = false;
        public string Ad = "";
        public string TypeCode="";
        public string Adres = "";
        public string Telefon = "";

        #endregion

        #region Cons
        public  Musteri(){}
        #endregion
        #region Fonk
        public bool KayitAc(int prmID)
        {
            bool ret = false;

            try
            {
                DbConnection con = new DbConnection();
                string prmQuery = "SELECT * FROM TblOrenyeri WHERE IsSilindi=0 AND ID=" + prmID;
                DataTable dt = con.GetQuery(prmQuery);

                if (dt.Rows.Count>0)
                {
                    ret = true;
                    this.ID = Convert.ToInt32(dt.Rows[0][ID]);
                    this.IsSilindi = Convert.ToBoolean(dt.Rows[0]["IsSilindi"]);
                    this.Ad = dt.Rows[0]["Ad"].ToString();
                    this.Ad = dt.Rows[0]["Adres"].ToString();
                    this.Ad = dt.Rows[0]["Telefon"].ToString();
                }
                dt.Rows.Clear();
                dt.Clear();
                dt.Dispose();
                dt = null;
                con.Close();
            }
            catch //(Exception e)
            {
                ret = false;
            }
            GC.Collect();
            return ret;
        }

        public bool Kayit()
        {
            bool ret = false;

            try
            {
                DbConnection con = new DbConnection();
                List<SqlParameter> sqlParList = new List<SqlParameter>();
                sqlParList.Add(new SqlParameter("@ID",this.ID));
                sqlParList.Add(new SqlParameter("@IsSilindi",this.IsSilindi));
                sqlParList.Add(new SqlParameter("@Ad",this.Ad));
                sqlParList.Add(new SqlParameter("@Adres",this.Adres));
                sqlParList.Add(new SqlParameter("@Telefon",this.Telefon));

                object o = con.RetStoredProc("ysp_TblOrenYeri", sqlParList);

                if (o==null)
                {
                    ret = false;
                }
                else
                {
                    ret = true;
                    this.ID = Convert.ToInt32(o);
                }

                o = null;
                sqlParList.Clear();
                sqlParList = null;
                con.Close();
            }
            catch //(Exception e)
            {
                ret = false;
            }
            GC.Collect();
            return ret;
        }
        #endregion
    }
}
