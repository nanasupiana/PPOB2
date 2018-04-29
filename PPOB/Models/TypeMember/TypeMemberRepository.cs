using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mmt_Library;
using System.Configuration;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using PPOB.Models.TypeMember;

namespace PPOB.Models.TypeMember
{
    public class TypeMemberRepository
    {
        dbAccess dbAccess = new dbAccess();
        string conn = ConfigurationManager.ConnectionStrings["GetConn"].ConnectionString;

        public async Task<List<MasterTypeMember>> GetTypeMember()
        {
            List<MasterTypeMember> Result = new List<MasterTypeMember>();
            try
            {
                string Query = "GetTypemember";
                DataTable dt = new DataTable();
                dbAccess.strConn = conn;
                dt = await dbAccess.GetDataTable(Query);

                foreach (DataRow dr in dt.Rows)
                {
                    Result.Add(
                        new MasterTypeMember
                        {
                            TypeMember = Convert.ToString(dr["TypeMember"]),
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

        public async Task<Boolean> CreateTypeMember(string TypeMember,string Deskripsi,string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "CreateTypeMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@TypeMember", SqlDbType.VarChar);
                pParam[0].Value = TypeMember;
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

        public async Task<Boolean> EditTypeMember(string TypeMember, string Deskripsi,string User)
        {
            Boolean Result = false;
            try
            {
                string Query = "EditTypeMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[3];
                pParam[0] = new SqlParameter("@TypeMember", SqlDbType.VarChar);
                pParam[0].Value = TypeMember;
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

        public async Task<Boolean> DeleteTypeMember(string TypeMember)
        {
            Boolean Result = false;
            try
            {
                string Query = "DeleteTypeMember";

                dbAccess.strConn = conn;
                SqlParameter[] pParam = new SqlParameter[1];
                pParam[0] = new SqlParameter("@TypeMember", SqlDbType.VarChar);
                pParam[0].Value = TypeMember;
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