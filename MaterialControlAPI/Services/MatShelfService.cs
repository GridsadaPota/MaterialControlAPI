using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatShelfService : IMatShelfService
    {
        private readonly string _connectionString;
        public MatShelfService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectDB");
        }


        public bool AddMatLocal(MatShelfModel matShelfModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Mat_Shelf (Shelf_Code, Shelf_Name, Shelf_Remark, Local_Id, Create_Date)";
                sql += "values ('"+matShelfModel.Shelf_Code+"','"+matShelfModel.Shelf_Name+"','"+matShelfModel.Shelf_Remark+"',"+matShelfModel.Local_Id+",getdate()) ";
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

        public bool DeleteMatShelf(string code)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "delete from Mat_Shelf where Shelf_Code = '" + code + "' ";
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

        public bool EditMatShelf(MatShelfModel matShelfModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "update Mat_Shelf set Shelf_Name = '"+matShelfModel.Shelf_Name+"' ";
                sql += ", Shelf_Code = '"+matShelfModel.Shelf_Code+"' ";
                sql += ", Shelf_Remark = '"+matShelfModel.Shelf_Remark+"' ";
                sql += ", Local_Id = '"+matShelfModel.Local_Id+"' ";
                sql += ", Modify_Date = GETDATE() ";
                sql += " where Shelf_Id = "+matShelfModel.Shelf_Id+" ";

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

        public IEnumerable<MatShelfModel> GetAll()
        {
            try
            {
                List<MatShelfModel>list = new List<MatShelfModel>();
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Shelf_Id, Shelf_Code, Shelf_Name, Shelf_Remark, Local_Id, Create_Date, Modify_Date from Mat_Shelf order by Shelf_Id";
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
                    MatShelfModel model = new MatShelfModel()
                    {
                        Shelf_Id = Convert.ToInt32(dt.Rows[i]["Shelf_Id"].ToString()),
                        Shelf_Code = dt.Rows[i]["Shelf_Code"].ToString(),
                        Shelf_Name = dt.Rows[i]["Shelf_Name"].ToString(),
                        Shelf_Remark = dt.Rows[i]["Shelf_Remark"].ToString(),
                        Local_Id = Convert.ToInt32(dt.Rows[i]["Local_Id"].ToString()),
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

        public MatShelfModel GetMatShelfByCode(string Scode)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Shelf_Id, Shelf_Code, Shelf_Name, Shelf_Remark, Local_Id, Create_Date, Modify_Date from Mat_Shelf where Shelf_Code ='"+Scode+"'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];

                //Add Data to Member model
                MatShelfModel model = null;
                if (dt.Rows.Count > 0)
                {
                    model = new MatShelfModel()
                    {
                        Shelf_Id = Convert.ToInt32(dt.Rows[0]["Shelf_Id"].ToString()),
                        Shelf_Code = dt.Rows[0]["Shelf_Code"].ToString(),
                        Shelf_Name = dt.Rows[0]["Shelf_Name"].ToString(),
                        Shelf_Remark = dt.Rows[0]["Shelf_Remark"].ToString(),
                        Local_Id = Convert.ToInt32(dt.Rows[0]["Local_Id"].ToString()),
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
