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


namespace PPOB.Models.RoleMaster
{
    public class RoleRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterRole>> GetRoleMaster()
        {
            List<MasterRole> Result = new List<MasterRole>();
            try
            {
                string Query = "GetRoleMaster";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterRole
                        {
                            RoleID = Convert.ToString(dr["RoleID"]),
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

        public async Task<Boolean> CreateRoleMaster(string Nama,string User)
        {
            Boolean Result = false;
            try
            {

                string Query = "CreateRole";
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

        public async Task<Boolean> EditRoleMaster(string RoleID,string Nama,string user)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditRole";
                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                pParam[0].Value = RoleID;
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

        public async Task<Boolean> DeleteRoleMMaster(string RoleID,string user)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteRole";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@RoleID", SqlDbType.VarChar);
                pParam[0].Value = RoleID;                
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