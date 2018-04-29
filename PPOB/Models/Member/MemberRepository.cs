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

namespace PPOB.Models.Member
{
    public class MemberRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterMember>> GetMember()
        {
            List<MasterMember> Result = new List<MasterMember>();
            try
            {
                string Query = "GetMember";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterMember
                        {
                            MemberId = Convert.ToString(dr["MemberId"]),
                            Photo = Convert.ToString(dr["Photo"]),
                            NamaMember = Convert.ToString(dr["Nama"]),
                            Email = Convert.ToString(dr["Email"]),
                            NoTepon = Convert.ToString(dr["NoTelpon"]),
                            KodeReverall = Convert.ToString(dr["KodeReverall"]),
                            TypeMember = Convert.ToString(dr["Deskripsi"]),
                            TanggalGabung = Convert.ToString(dr["TglBergabung"]),
                        });
                }
                return Result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Boolean> CreateMember(string NamaMember)
        {
            Boolean Result= false;
            try
            {
                string Query = "CreateMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@nama", SqlDbType.VarChar);
                pParam[0].Value = NamaMember;
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

        public async Task<Boolean> EditMember(string IdMember, string NamaMember)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[2];
                pParam[0] = new SqlParameter("@Id", SqlDbType.VarChar);
                pParam[0].Value = IdMember;
                pParam[1] = new SqlParameter("@nama", SqlDbType.VarChar);
                pParam[1].Value = NamaMember;
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


        public async Task<Boolean> DeleteMember(string IdMember)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@Id", SqlDbType.VarChar);
                pParam[0].Value = IdMember;
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