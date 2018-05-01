using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using PPOB.Models.PDAM;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PPOB.Models.PDAM
{
    public class PDAMRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterPDAM>> GetPDAM()
        {
            List<MasterPDAM> Result = new List<MasterPDAM>();
            try
            {
                string Query = "GetPDAM";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterPDAM
                        {
                            PDAMId = Convert.ToString(dr["PDAMId"]),
                            Deskripsi = Convert.ToString(dr["Deskripsi"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<Boolean> CreatePDAM(string PDAMId, string Deskripsi, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "CreatePDAM";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@PDAMId", SqlDbType.VarChar);
                pParam[0].Value = PDAMId;
                pParam[1] = new SqlParameter("@Deskripsi", SqlDbType.VarChar);
                pParam[1].Value = Deskripsi;
                pParam[2] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[2].Value = User;
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
        public async Task<Boolean> EditPDAM(string PDAMId, string Deskripsi, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditPDAM";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@PDAMId", SqlDbType.VarChar);
                pParam[0].Value = PDAMId;
                pParam[1] = new SqlParameter("@Deskripsi", SqlDbType.VarChar);
                pParam[1].Value = Deskripsi;
                pParam[2] = new SqlParameter("@User", SqlDbType.VarChar);
                pParam[2].Value = User;
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

        public async Task<Boolean> DeletePDAM(string PDAMId, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeletePDAM";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[2];
                pParam[0] = new SqlParameter("@PDAMId", SqlDbType.VarChar);
                pParam[0].Value = PDAMId;
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
    }
}