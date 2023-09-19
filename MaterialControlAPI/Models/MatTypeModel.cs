using System.Text.Json.Serialization;

namespace MaterialControlAPI.Models
{
    public class MatTypeModel
    {
        public int Type_Id { get; set; }
        public string Type_Code { get; set; }
        public string Type_Name { get; set;}
        public string Type_Remark { get; set;}
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set;}

        public static implicit operator MatTypeModel(MatLocalModel v)
        {
            throw new NotImplementedException();
        }
    }
}
