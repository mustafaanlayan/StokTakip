using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StokTakip.Clasess;

namespace StokTakip
{
    class Kullanici
    {
        #region Değişkenler

        public int ID = -1;
        public bool IsSilindi = false;
        public string KullaniciAdi = "";
        public string Parola = "";
        #endregion
        public Kullanici()
        {

        }

        #region Fonk

        public bool KayitAc(string prmKullaniciAdi, string prmParola)
        {
            bool ret = false;

            try
            {
                DbConnection con = new DbConnection();

                List<SqlParameter> sqlParList = new List<SqlParameter>();
                sqlParList.Add(new SqlParameter("@KullAd",prmKullaniciAdi));
                sqlParList.Add(new SqlParameter("@Parola",prmParola));

                DataTable dt = con.RetStoredProcDataTable("sp_KullBul", sqlParList);

                if (dt.Rows.Count > 0)
                {
                    ret = true;
                    this.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                    this.IsSilindi = Convert.ToBoolean(dt.Rows[0]["IsSilindi"]);
                    this.KullaniciAdi = dt.Rows[0]["KullaniciAdi"].ToString();
                    this.Parola = dt.Rows[0]["Parola"].ToString();
                }
                dt.Rows.Clear();
                dt.Clear();
                dt.Dispose();
                dt = null;
                con.Close();
            }
            catch (Exception e)
            {
                ret = false;
            }
            GC.Collect();
            return ret;
        }
        #endregion
    }
}
