using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatTypeController : Controller
    {
        private readonly IMatTypeService _mattypeService;
        public MatTypeController(IMatTypeService mattypeService)
        {
            _mattypeService = mattypeService;
        }

        //[HttpGet("Test")]
        //public JsonResult Test()
        //{
        //    return Json(new {name="Ant",Age=22});   
        //}



        [HttpPost("Add")]
        public JsonResult Add(MatTypeModel matType)
        {
            var response = _mattypeService.AddMatType(matType);
            if (response == true)
            {
                return Json(new { Status = 201, Message = "Add Succest" });
            }
            else
            {
                return Json(new { Status = 400, Message = "Failed Insert" });
            }
               
        }

        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            IEnumerable<MatTypeModel> list = _mattypeService.GetAll();
            return Json(list);
        }


        [HttpGet("GetMatType")]
        public JsonResult GetMatType(string code)
        {
            //MatTypeModel matType = _mattypeService.GetMatTypeByCode(code);
            //return  Json(matType);
            var response = _mattypeService.GetMatTypeByCode(code);
            if (response == null)
            {
                return Json(new { Status = 404, Message = "Not Found" });
            }
            else 
            {
                return Json(response);
            }
        }

        [HttpPut("Edit")]
        public JsonResult EditMatType(MatTypeModel matTypeModel)
        {
            var response = _mattypeService.EditMatType(matTypeModel);
            if (response == true) 
            {
                return Json(new { Status = 202, Message = "Update Succest" });
            }
            else 
            {
                return Json(new { Status = 401, Message = "Can Not Update" });
            }
        }
    }

}
