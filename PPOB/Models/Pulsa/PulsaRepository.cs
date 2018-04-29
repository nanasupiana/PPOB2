using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PPOB.Models.Pulsa;

namespace PPOB.Models.Pulsa
{
    public class PulsaRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterPulsa>> GetPulsa()
        {
            List<MasterPulsa> Result = new List<MasterPulsa>();
            try
            {
                string Query = "GetPulsa";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterPulsa
                        {
                            PulsaId = Convert.ToString(dr["PulsaId"]),
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

        public async Task<Boolean> CreatePulsa(string PulsaID, string Deskripsi,string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "CreatePulsa";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@PulsaID", SqlDbType.VarChar);
                pParam[0].Value = PulsaID;
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

        public async Task<Boolean> EditPulsa(string PulsaID, string Deskripsi,string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditPulsa";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@PulsaId", SqlDbType.VarChar);
                pParam[0].Value = PulsaID;
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

        public async Task<Boolean> DeletePulsa(string PulsaId)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeletePulsa";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@PulsaId", SqlDbType.VarChar);
                pParam[0].Value = PulsaId;
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