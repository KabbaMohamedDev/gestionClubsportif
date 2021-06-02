using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace gestionClubsportif.BL
{
    class login
    {
        public DataTable LOGIN(string ID, string PWD)

        {

            DAL.DataAcessLayer DAL = new DAL.DataAcessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            param[0].Value = ID;
            param[1] = new SqlParameter("@passe", SqlDbType.VarChar, 50);
            param[1].Value = PWD;
            DAL.open();
            DataTable dt = new DataTable();
            dt = DAL.SelectData("SP_LOGIN", param);
            DAL.close();
            return dt;
        }
    }
}
