namespace MaterialControlAPI.Models
{
    public class MatStockOutModel
    {
        public int StockOut_Id { get; set; }
        public int Material_Id { get; set; }
        public string Material_Code { get; set; }
        public string Material_Name { get; set; }
        public string Product_Lot { get; set; }
        public decimal StockOut_Qty { get; set; }
        public string Staff_Id { get; set; }
        public string Remark { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }
    }
}
