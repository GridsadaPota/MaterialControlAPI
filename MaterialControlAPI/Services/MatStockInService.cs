using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatStockInService : IMatStockInService
    {
        private readonly string _connectionString;
        public MatStockInService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectDB");
        }
        public bool AddMatStockIn(MatStockInModel matStockInModel)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Material_StockIn (Material_Id,Invoice_No,Invoice_Date,Item_No,StockIn_Qty,Staff_Id,Remark,Create_Date) ";
                sql += "values ( '"+matStockInModel.Material_Id+"', '" + matStockInModel.Invoice_No + "','" + matStockInModel.Invoice_Date.ToString("yyyy-MM-dd") + "'";
                sql += ",'" + matStockInModel.Item_No + "', '"+matStockInModel.StockIn_Qty+"', '"+matStockInModel.Staff_Id+"', '"+matStockInModel.Remark+ "', GETDATE())";
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

        public bool DeleteMatStockIn(string code)
        {
            throw new NotImplementedException();
        }

        public bool EditMatStockIn(MatStockInModel matStockInModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MatStockInModel> GetAll()
        {
            try
            {
                List<MatStockInModel> list = new List<MatStockInModel>();
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select StockIn_Id, Material_Id, Invoice_No, Invoice_Date, Item_No, StockIn_Qty, Staff_Id, Remark, Create_Date, Modify_Date from Material_StockIn order by StockIn_Id";
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
                    MatStockInModel matStockInModel = new MatStockInModel()
                    {
                        StockIn_Id = Convert.ToInt32(dt.Rows[i]["StockIn_Id"].ToString()),
                        Material_Id = Convert.ToInt32(dt.Rows[i]["Material_Id"].ToString()),
                        Invoice_No = dt.Rows[i]["Invoice_No"].ToString(),
                        Invoice_Date = Convert.ToDateTime(dt.Rows[i]["Invoice_Date"].ToString()),
                        Item_No = dt.Rows[i]["Item_No"].ToString(),
                        StockIn_Qty = Convert.ToDecimal(dt.Rows[i]["StockIn_Qty"].ToString()),
                        Staff_Id = dt.Rows[i]["Staff_Id"].ToString(),
                        Remark = dt.Rows[i]["Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[i]["Create_Date"].ToString()),
                        Modify_Date = string.IsNullOrEmpty(dt.Rows[i]["Modify_Date"].ToString()) ? DateTime.MinValue : Convert.ToDateTime(dt.Rows[i]["Modify_Date"].ToString())
                    }; 
                    list.Add(matStockInModel);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public MatStockInModel GetMatStockInByCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}
