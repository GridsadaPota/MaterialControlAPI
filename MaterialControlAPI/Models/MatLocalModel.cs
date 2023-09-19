using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Models
{
    public class MatLocalModel 
    {
        public int Local_Id { get; set; }
        public string Local_Code { get; set;}
        public string Local_Name { get; set;}
        public string Local_Remak { get; set;}
        public DateTime Create_Date { get; set; }
        public DateTime Modify_Date { get; set; }
    }
}


