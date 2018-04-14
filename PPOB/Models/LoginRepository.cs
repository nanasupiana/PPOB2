using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using PPOB.Models;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PPOB.Models
{
    public class LoginRepository
    {
        dbAccess dbAccess = new dbAccess();
        public async Task<Boolean> GetUserLogin(string Email,string Password)
        {           
            Boolean Res;
            string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;
            string Query = "GetUserLogin";

            DataTable dt = new DataTable();
            dbAccess.strConn = conn;
            SqlParameter[] pParam = new SqlParameter[2];
            pParam[0] = new SqlParameter("@Email", SqlDbType.VarChar);
            pParam[0].Value = Email;
            pParam[1] = new SqlParameter("@Password", SqlDbType.VarChar);
            pParam[1].Value = Password;

            dt = await dbAccess.GetDataTableByCommand_Async(Query,pParam);
            
            if (dt.Rows.Count > 0)
            {
                Res = true;
            }
            else
            {
                Res = false;
            }
            return Res;
        }

        enum Status { success , failled}
    }
}