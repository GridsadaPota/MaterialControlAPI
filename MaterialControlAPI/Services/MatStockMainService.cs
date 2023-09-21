using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatStockMainService : IMatStockMainService
    {            
            private readonly string _connectionString;
            public MatStockMainService(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("ConnectDB");
            }
        public bool AddMatStockMain(MatStockMainModel matStockMainModel)
        {
             try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Material_StockMain (Material_Code, Material_Name, Unit, Type_Id, Shelf_Id, Stock_Qty, Hold_Stock, Remark, Create_Date)";
                sql += "values('" + matStockMainModel.Material_Code + "', '" + matStockMainModel.Material_Name + "', '" + matStockMainModel.Unit + "'";
                sql += ", '" + matStockMainModel.Type_Id + "', '" + matStockMainModel.Shelf_Id + "', '" + matStockMainModel.Stock_Qty + "'";
                sql += ", '"+matStockMainModel.Hold_Stock+"', '"+matStockMainModel.Remark+"', GETDATE())";
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

        public bool DeleteMatStockMain(string code)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "delete from Mat_StockMain where Material_Code = '" + code + "' ";
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

        public bool EditMatStockMain(MatStockMainModel matStockMainModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatStockMainModel> GetAll()
        {
            try
            {
                List<MatStockMainModel> list = new List<MatStockMainModel>();
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Material_Id, Material_Code, Material_Name, Unit, Type_Id, Shelf_Id, Stock_Qty, Hold_Stock, Remark, Create_Date, Modify_Date from Material_StockMain order by Material_Id";
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
                    MatStockMainModel model = new MatStockMainModel()
                    {
                        Material_Id = Convert.ToInt32(dt.Rows[i]["Material_Id"].ToString()),
                        Material_Code = dt.Rows[i]["Material_Code"].ToString(),
                        Material_Name = dt.Rows[i]["Material_Name"].ToString(),
                        Unit = dt.Rows[i]["Unit"].ToString(),
                        Type_Id = Convert.ToInt32(dt.Rows[i]["Type_Id"].ToString()),
                        Shelf_Id = Convert.ToInt32(dt.Rows[i]["Shelf_Id"].ToString()),
                        Stock_Qty = Convert.ToDecimal(dt.Rows[i]["Stock_Qty"].ToString()),
                        Hold_Stock = Convert.ToInt32(dt.Rows[0]["Hold_Stock"].ToString()),
                        Remark = dt.Rows[i]["Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[i]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[i]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["Modify_Date"].ToString())

                    };
                    list.Add(model);
                }               
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MatStockMainModel GetMatStockMainByCode(string code)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Material_Id, Material_Code, Material_Name, Unit, Type_Id, Shelf_Id, Stock_Qty, Hold_Stock, Remark, Create_Date, Modify_Date from Material_StockMain order by Material_Id"+ code + "'";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];              
                MatStockMainModel model = null;
                if (dt.Rows.Count > 0)
                {
                    model = new MatStockMainModel()
                    {
                        Material_Id = Convert.ToInt32(dt.Rows[0]["Material_Id"].ToString()),
                        Material_Code = dt.Rows[0]["Material_Code"].ToString(),
                        Material_Name = dt.Rows[0]["Material_Name"].ToString(),
                        Unit = dt.Rows[0]["Unit"].ToString(),
                        Type_Id = Convert.ToInt32(dt.Rows[0]["Type_Id"].ToString()),
                        Shelf_Id = Convert.ToInt32(dt.Rows[0]["Shelf_Id"].ToString()),
                        Stock_Qty = Convert.ToDecimal(dt.Rows[0]["Stock_Qty"].ToString()),
                        Hold_Stock = Convert.ToInt32(dt.Rows[0]["Hold_Stock"].ToString()),
                        Remark = dt.Rows[0]["Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[0]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[0]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[0]["Modify_Date"].ToString())

                    };
                }               
                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
