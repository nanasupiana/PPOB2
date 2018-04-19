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

namespace PPOB.Models.Operator
{
    public class OperatorRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterOperator>> GetOperator()
        {
            List<MasterOperator> Result = new List<MasterOperator>();
            try
            {
                string Query = "GetOperator";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterOperator
                        {
                            IdOperator = Convert.ToString(dr["Id"]),
                            NamaOperator = Convert.ToString(dr["Nama"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Boolean> CreateOperator(string NamaOperator)
        {
            Boolean Result= false;
            try
            {
                string Query = "CreateOperator";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@nama", SqlDbType.VarChar);
                pParam[0].Value = NamaOperator;
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if(res == -1)
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

        public async Task<Boolean> EditOperator(string IdOperator, string NamaOperator)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditOperator";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[2];
                pParam[0] = new SqlParameter("@Id", SqlDbType.VarChar);
                pParam[0].Value = IdOperator;
                pParam[1] = new SqlParameter("@nama", SqlDbType.VarChar);
                pParam[1].Value = NamaOperator;
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res == -1)
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


        public async Task<Boolean> DeleteOperator(string IdOperator)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteOperator";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@Id", SqlDbType.VarChar);
                pParam[0].Value = IdOperator;
                int res = await dbAccess.ExecQueryByCommand(Query, pParam);
                if (res == -1)
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