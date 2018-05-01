using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PPOB.Models.MasterMenu;

namespace PPOB.Models.MasterMenu
{
    public class MasterMenuRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterMenu>> GetMasterMenu()
        {
            List<MasterMenu> Result = new List<MasterMenu>();
            try
            {
                string Query = "GetMasterMenu";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterMenu
                        {
                            MenuId = Convert.ToString(dr["MenuId"]),
                            MenuName = Convert.ToString(dr["MenuName"]),
                            MenuURL = Convert.ToString(dr["MenuURL"]),
                            MenuIcon = Convert.ToString(dr["MenuIcon"]),
                            MenuParentId = Convert.ToString(dr["MenuParentId"]),
                            MenuParent = Convert.ToString(dr["MenuParent"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        

        public async Task<Boolean> CreateMasterMenu(string MenuName, string MenuURL, string MenuIcon, string MenuParentId, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "CreateMasterMenu";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[5];
                pParam[0] = new SqlParameter("@MenuName", SqlDbType.VarChar);
                pParam[0].Value = MenuName;
                pParam[1] = new SqlParameter("@MenuURL", SqlDbType.VarChar);
                pParam[1].Value = MenuURL;
                pParam[2] = new SqlParameter("@MenuIcon", SqlDbType.VarChar);
                pParam[2].Value = MenuIcon;
                pParam[3] = new SqlParameter("@MenuParentId", SqlDbType.VarChar);
                pParam[3].Value = MenuParentId;
                pParam[4] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[4].Value = User;
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

         public async Task<Boolean> EditMasterMenu(string MenuID, string MenuName, string MenuURL, string MenuIcon, string MenuParentId, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditMasterMenu";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[6];
                pParam[0] = new SqlParameter("@MenuID", SqlDbType.VarChar);
                pParam[0].Value = MenuID;
                pParam[1] = new SqlParameter("@MenuName", SqlDbType.VarChar);
                pParam[1].Value = MenuName;
                pParam[2] = new SqlParameter("@MenuURL", SqlDbType.VarChar);
                pParam[2].Value = MenuURL;
                pParam[3] = new SqlParameter("@MenuIcon", SqlDbType.VarChar);
                pParam[3].Value = MenuIcon;
                pParam[4] = new SqlParameter("@MenuParentId", SqlDbType.VarChar);
                pParam[4].Value = MenuParentId;
                pParam[5] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[5].Value = User;
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

        public async Task<Boolean> DeleteMasterMenu(string MenuID, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteMasterMenu";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[2];
                pParam[0] = new SqlParameter("@MenuID", SqlDbType.VarChar);
                pParam[0].Value = MenuID;
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

        public async Task<List<StandartComboBox>> GetParent()
        {
            List<StandartComboBox> Result = new List<StandartComboBox>();
            try
            {
                string Query = "GetMenuParent";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);
                Result.Add(
                new StandartComboBox
                {
                    Text = "Select",
                    Value = "0"
                });
                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new StandartComboBox
                        {
                            Value = Convert.ToString(dr["Value"]),
                            Text = Convert.ToString(dr["Text"])
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}