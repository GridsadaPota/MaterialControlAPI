using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatStockOutService : IMatStockOutService
    {
        private readonly string _connectionString;
        public MatStockOutService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectDB");
        }

        public bool AddMatStockOut(MatStockOutModel matStockOutModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Material_StockOut (Material_Id, Product_Lot, StockOut_Qty, Staff_Id, Remark, Create_Date)";
                sql += "values('" + matStockOutModel.Material_Id + "', '" + matStockOutModel.Product_Lot + "', '" +matStockOutModel.StockOut_Qty + "'";
                sql += ", '" + matStockOutModel.Staff_Id + "', '" + matStockOutModel.Remark + "', GETDATE())";
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

        public bool DeleteMatStockOut(int Id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "delete from Material_StockOut where StockOut_Id = '" + Id + "' ";
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

        public bool EditMatStockOut(MatStockOutModel matStockOutModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = " update Material_StockOut set Material_Id = '"+matStockOutModel.Material_Id+"'";
                sql += ", Product_Lot = '"+matStockOutModel.Product_Lot+ "', StockOut_Qty = '"+matStockOutModel.StockOut_Qty+"'";
                sql += ", Staff_Id = '"+matStockOutModel.Staff_Id+ "', Remark = '"+matStockOutModel.Remark+"'";
                sql += ", Modify_Date = GETDATE() where StockOut_Id = '" + matStockOutModel.StockOut_Id + "' ";

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

        public IEnumerable<MatStockOutModel> GetAll()
        {
            try
            {
                List<MatStockOutModel> list = new List<MatStockOutModel>();
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select T1.StockOut_Id, T1.Material_Id, T2.Material_Code, T2.Material_Name, T1.Product_Lot, T1.StockOut_Qty" ;
                sql += ", T1.Staff_Id, T1.Remark, T1.Create_Date, T1.Modify_Date" ;
                sql += " from Material_StockOut T1 left outer join Material_StockMain T2 on T1.Material_Id = T2.Material_Id";
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
                    MatStockOutModel matStockOutModel = new MatStockOutModel()
                    {
                        StockOut_Id = Convert.ToInt32(dt.Rows[i]["StockOut_Id"].ToString()),
                        Material_Id = Convert.ToInt32(dt.Rows[i]["Material_Id"].ToString()),
                        Material_Code = dt.Rows[i]["Material_Code"].ToString(),
                        Material_Name = dt.Rows[i]["Material_Name"].ToString(),
                        Product_Lot = dt.Rows[i]["Product_Lot"].ToString(),
                        StockOut_Qty = Convert.ToDecimal(dt.Rows[i]["StockOut_Qty"].ToString()),
                        Staff_Id = dt.Rows[i]["Staff_Id"].ToString(),
                        Remark = dt.Rows[i]["Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[i]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[i]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["Modify_Date"].ToString())
                    };
                    list.Add(matStockOutModel);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MatStockOutModel GetMatStockOutById(int Id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select StockOut_Id, Material_Id, Product_Lot, StockOut_Qty, Staff_Id, Remark, Create_Date, Modify_Date from Material_StockOut where StockOut_Id = '" + Id + "' ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];
                MatStockOutModel model = null;
                if (dt.Rows.Count > 0)
                {
                    model = new MatStockOutModel()
                    {
                        StockOut_Id = Convert.ToInt32(dt.Rows[0]["StockOut_Id"].ToString()),
                        Material_Id = Convert.ToInt32(dt.Rows[0]["Material_Id"].ToString()),                        
                        Product_Lot = dt.Rows[0]["Product_Lot"].ToString(),
                        StockOut_Qty = Convert.ToDecimal(dt.Rows[0]["StockOut_Qty"].ToString()),
                        Staff_Id = dt.Rows[0]["Staff_Id"].ToString(),
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
