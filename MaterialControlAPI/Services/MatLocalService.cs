using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatLocalService : IMatLocalService
    {
        private readonly string _connectionString;
        public MatLocalService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectDB");
        }
        public bool AddMatLocal(MatLocalModel matLocalModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Mat_Location (Local_Code, Local_Name, Local_Remark, Create_Date) ";
                sql += "values ('"+matLocalModel.Local_Code+"', '"+matLocalModel.Local_Name+"', '"+matLocalModel.Local_Remark+"', GETDATE())";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                //throw;
                return false;
            }
        }

        public bool DeleteMatLocal(string code)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "delete from Mat_Location where Local_Code = '" + code + "' ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditMatLocal(MatLocalModel matLocalModel)
        {
            try
            {
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "update Mat_Location set Local_Name = '" + matLocalModel.Local_Name + "' ";
                sql += ", Local_Code = '"+ matLocalModel.Local_Code+"' ";
                sql += ", Local_Remark = '" + matLocalModel.Local_Remark + "', Modify_Date = GETDATE() where Local_Id = " + matLocalModel.Local_Id + " ";

                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<MatLocalModel> GetAll()
        {
            try
            {
                List<MatLocalModel> list = new List<MatLocalModel>();
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Local_Id, Local_Code, Local_Name, Local_Remark, Create_Date, Modify_Date from Mat_Location order by Local_Id";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MatLocalModel model = new MatLocalModel()
                    {
                        Local_Id = Convert.ToInt32(dt.Rows[i]["Local_Id"].ToString()),
                        Local_Code = dt.Rows[i]["Local_Code"].ToString(),
                        Local_Name = dt.Rows[i]["Local_Name"].ToString(),
                        Local_Remark = dt.Rows[i]["Local_Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[i]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[i]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["Modify_Date"].ToString())

                    };
                    //add Model to list
                    list.Add(model);
                }



                //return data 
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MatLocalModel GetMatLocalByCode(string code)
        {
            try
            {
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Top 1 Local_Id, Local_Code, Local_Name, Local_Remark, Create_Date, Modify_Date from Mat_Location where Local_Code = '" + code + "' ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];

                //Add Data to Member model
                MatLocalModel model = null;
                if (dt.Rows.Count > 0)
                {
                    model = new MatLocalModel()
                    {
                        Local_Id = Convert.ToInt32(dt.Rows[0]["Local_Id"].ToString()),
                        Local_Code = dt.Rows[0]["Local_Code"].ToString(),
                        Local_Name = dt.Rows[0]["Local_Name"].ToString(),
                        Local_Remark = dt.Rows[0]["Local_Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[0]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[0]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["Modify_Date"].ToString())

                    };
                }
                //return data 
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
