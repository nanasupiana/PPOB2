using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PPOB.Models;
using System.Web.Mvc;


namespace PPOB.Models.User
{
    public class UserRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<User>> GetUser()
        {
            List<User> Result = new List<User>();
            try
            {
                string Query = "GetUser";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new User
                        {
                            UserID = Convert.ToString(dr["UserID"]),
                            Name = Convert.ToString(dr["Name"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Boolean> CreateUser(string Nama,string User)
        {
            Boolean Result = false;
            try
            {

                string Query = "CreateUser";
                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[2];
                pParam[0] = new SqlParameter("@Nama", SqlDbType.VarChar);
                pParam[0].Value = Nama;
                pParam[1] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[1].Value = User;                

                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res == 1)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                throw;
            }
            return Result;
        }

        public async Task<Boolean> EditUser(string UserID,string Nama,string user)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditUser";
                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@UserID", SqlDbType.Int);
                pParam[0].Value = UserID;
                pParam[1] = new SqlParameter("@Nama", SqlDbType.VarChar);
                pParam[1].Value = Nama;
                pParam[2] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[2].Value = user;
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res == 1)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                throw;
            }
            return Result;
        }

        public async Task<Boolean> DeleteUserMMaster(string UserID,string user)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteUser";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
                pParam[0].Value = UserID;                
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res == 1)
                {
                    Result = true;
                }
                else
                {
                    Result = false;
                }
            }
            catch (Exception ex)
            {
                Result = false;
                throw;
            }
            return Result;
        }
    }
}