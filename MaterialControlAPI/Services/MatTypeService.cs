using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System;
using System.Data;

namespace MaterialControlAPI.Services
{
    public class MatTypeService : IMatTypeService
    {
        private readonly string _connectionString;
        public MatTypeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectDB");
        }
        public bool AddMatType(MatTypeModel matTypeModel)
        {
            try
            {

                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "insert into Material_Type(Type_Code, Type_Name, Type_Remark, Create_Date) ";
                sql += "values('" + matTypeModel.Type_Code + "', '" + matTypeModel.Type_Name + "', '" + matTypeModel.Type_Remark + "', getdate()) ";
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

        public bool DeleteMatType(string code)
        {
            try 
            { 
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "delete from Material_Type where Type_Code = '"+code+"' ";
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

        public bool EditMatType(MatTypeModel matTypeModel)
        {
            try
            {
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "update Material_Type set Type_Name = '" + matTypeModel.Type_Name + "' ";
                sql += ", Type_Remark = '"+matTypeModel.Type_Remark+"', Modify_Date = GETDATE() where Type_Id = "+matTypeModel.Type_Id+" ";

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

        public IEnumerable<MatTypeModel> GetAll()
        {
            try
            {
                List<MatTypeModel> list = new List<MatTypeModel>();
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Type_Id, Type_Code, Type_Name, Type_Remark, Create_Date, Modify_Date from Material_Type";
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
                    MatTypeModel model = new MatTypeModel()
                    {
                        Type_Id = Convert.ToInt32(dt.Rows[i]["Type_Id"].ToString()),
                        Type_Code = dt.Rows[i]["Type_Code"].ToString(),
                        Type_Name = dt.Rows[i]["Type_Name"].ToString(),
                        Type_Remark = dt.Rows[i]["Type_Remark"].ToString(),
                        Create_Date = Convert.ToDateTime(dt.Rows[i]["Create_Date"].ToString())            

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

        public MatTypeModel GetMatTypeByCode(string code)
        {
            try
            {
                //string connectionstring = "Data Source=MSI\\SQLEXPRESS2019; Initial Catalog=Demo; User ID=sa; Password=1234; TrustServerCertificate=True";
                SqlConnection conn = new SqlConnection(_connectionString);
                string sql = "select Top 1 Type_Id, Type_Code, Type_Name, Type_Remark, Create_Date, Modify_Date from Material_Type where Type_Code = '"+code+"' ";
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                conn.Close();
                dt = ds.Tables[0];

                //Add Data to Member model
                MatTypeModel model = null;
                if (dt.Rows.Count > 0)
                {
                    model = new MatTypeModel()
                    {
                        Type_Id = Convert.ToInt32(dt.Rows[0]["Type_Id"].ToString()),
                        Type_Code = dt.Rows[0]["Type_Code"].ToString(),
                        Type_Name = dt.Rows[0]["Type_Name"].ToString(),
                        Type_Remark =dt.Rows[0]["Type_Remark"].ToString(),
                        Create_Date =Convert.ToDateTime(dt.Rows[0]["Create_Date"].ToString())

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
