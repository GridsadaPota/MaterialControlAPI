namespace MaterialControlAPI.Models
{
    public class MatShelfModel
    {
        public int Shelf_Id { get; set; }
        public string Shelf_Code { get; set; }
        public string Shelf_Name { get; set; }
        public string Shelf_Remark { get; set; }
        public int Local_Id { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set;}

        public static implicit operator MatShelfModel(MatStockMainModel v)
        {
            throw new NotImplementedException();
        }
    }
}
