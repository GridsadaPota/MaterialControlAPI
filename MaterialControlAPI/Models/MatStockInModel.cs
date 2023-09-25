namespace MaterialControlAPI.Models
{
    public class MatStockInModel
    { 
        public int StockIn_Id { get; set; }
        public int Material_Id { get; set; }
        public string Invoice_No { get; set; }
        public DateTime Invoice_Date { get; set; }
        public string Item_No { get; set; }
        public Decimal StockIn_Qty { get; set; }
        public string Staff_Id { get; set; }
        public string Remark { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }
    }
}
