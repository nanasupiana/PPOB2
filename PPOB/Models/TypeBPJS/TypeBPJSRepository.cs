using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PPOB.Models.TypeBPJS
{
    public class TypeBPJSRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterTypeBPJS>> GetBPJSType()
        {
            List<MasterTypeBPJS> Result = new List<MasterTypeBPJS>();
            try
            {
                string Query = "GetBPJSType";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterTypeBPJS
                        {
                            BPJSId = Convert.ToString(dr["BPJSId"]),
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

        public async Task<Boolean> CreateTypeBPJS(string BPJSId, string Deskripsi, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "CreateTypeBPJS";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@BPJSId", SqlDbType.VarChar);
                pParam[0].Value = BPJSId;
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

        public async Task<Boolean> EditBPJSType(string BPJSId, string Deskripsi, string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditBPJSType";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@BPJSId", SqlDbType.VarChar);
                pParam[0].Value = BPJSId;
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

        public async Task<Boolean> DeleteTypeBPJS(string BPJSId)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteTypeBPJS";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@BPJSId", SqlDbType.VarChar);
                pParam[0].Value = BPJSId;
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