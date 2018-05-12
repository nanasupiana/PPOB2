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


namespace PPOB.Models.RoleMenu
{
    public class RoleMenuRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<RoleMenu>> GetRole()
        {
            List<RoleMenu> Result = new List<RoleMenu>();
            try
            {
                string Query = "GetRoleMaster";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new RoleMenu
                        {
                            RoleID = Convert.ToString(dr["RoleID"]),
                            RoleName = Convert.ToString(dr["Name"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<List<RoleMenu>> GetDetail()
        {
            List<RoleMenu> Result = new List<RoleMenu>();
            try
            {
                string Query = "GetRoleMenu";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new RoleMenu
                        {
                            MenuID = Convert.ToString(dr["MenuID"]),
                            MenuName = Convert.ToString(dr["MenuName"]),
                            Active = Convert.ToString(dr["Active"]),
                            Create = Convert.ToString(dr["Create"]),
                            Update = Convert.ToString(dr["Update"]),
                            Delete = Convert.ToString(dr["Delete"]),
                        });
                }

                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<RoleMenuDetail>> GetDetailById(string Id)
        {
            List<RoleMenuDetail> Result = new List<RoleMenuDetail>();
            try
            {
                string Query = "GetRoleMenuDetail";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@RoleID", SqlDbType.Int);
                pParam[0].Value = Id;
                dt = await dbAccess.GetDataTableByCommand_Async(Query,pParam);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new RoleMenuDetail
                        {
                            MenuID = Convert.ToString(dr["MenuID"]),
                            MenuName = Convert.ToString(dr["MenuName"]),
                            Active = Convert.ToString(dr["Active"]),
                            Create = Convert.ToString(dr["Create"]),
                            Update = Convert.ToString(dr["Update"]),
                            Delete = Convert.ToString(dr["Delete"]),
                        });
                }

                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Boolean> Setting(string RoleId, string MenuIds, string Actives, string Creates, string Updates, string Deletes, string User)
        {
            Boolean Result = false;
            var MenuId = "";
            var Active = "";
            var Create = "";
            var Update = "";
            var Delete = "";
            var Sparator = ";";
            try
            {

                string Query = "DelteRoleMenuMapping";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@RoleId", SqlDbType.VarChar);
                pParam[0].Value = RoleId;
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res != -1)
                {
                    if (MenuIds != "")
                    {
                        int Count = MenuIds.Split(new string[] { Sparator }, StringSplitOptions.None).Length;
                        for (int i = 0; i < Count; i++)
                        {
                            MenuId = MenuIds.Split(new string[] { Sparator }, StringSplitOptions.None)[i];
                            Active = Actives.Split(new string[] { Sparator }, StringSplitOptions.None)[i];
                            Create = Creates.Split(new string[] { Sparator }, StringSplitOptions.None)[i];
                            Update = Updates.Split(new string[] { Sparator }, StringSplitOptions.None)[i];
                            Delete = Deletes.Split(new string[] { Sparator }, StringSplitOptions.None)[i];
                            string sql = "CreateRoleMenuMepping";
                            dbAccess.strConn = conn;
                            SqlParameter[] Param = new SqlParameter[7];
                            Param[0] = new SqlParameter("@RoleId", SqlDbType.VarChar);
                            Param[0].Value = RoleId;
                            Param[1] = new SqlParameter("@MenuId", SqlDbType.VarChar);
                            Param[1].Value = MenuId;
                            Param[2] = new SqlParameter("@Active", SqlDbType.VarChar);
                            Param[2].Value = Active;
                            Param[3] = new SqlParameter("@Create", SqlDbType.VarChar);
                            Param[3].Value = Create;
                            Param[4] = new SqlParameter("@Update", SqlDbType.VarChar);
                            Param[4].Value = Update;
                            Param[5] = new SqlParameter("@Delete", SqlDbType.VarChar);
                            Param[5].Value = Delete;
                            Param[6] = new SqlParameter("@User", SqlDbType.VarChar);
                            Param[6].Value = User;
                            await dbAccess.ExecQueryByCommand(sql, Param);
                        }
                    }
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