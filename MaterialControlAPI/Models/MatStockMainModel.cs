using System.Collections;

namespace MaterialControlAPI.Models
{
    public class MatStockMainModel
    {
        public int Material_Id { get; set; }
        public string Material_Code { get; set;}
        public string Material_Name { get; set;}
        public string Unit { get; set; } 
        public int Type_Id { get; set; }
        public int Shelf_Id { get; set;}
        public decimal Stock_Qty { get; set;}
        public int Hold_Stock { get; set; }
        public string Remark { get; set;}
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set;}

    }
}
