using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using MaterialControlAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatShelfController : Controller
    {
        private readonly IMatShelfService _matShelfService;
        public MatShelfController(IMatShelfService matShelfService)
        {
            _matShelfService = matShelfService;
        }

        [HttpPost("Add")]
        public JsonResult Add(MatShelfModel matShelf)
        {
            var response = _matShelfService.AddMatLocal(matShelf);
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
            IEnumerable<MatShelfModel> list = _matShelfService.GetAll();
            return Json(list);
        }


        [HttpGet("GetMatShelf")]
        public JsonResult GetMatShelf(string code)
        {         
            var response = _matShelfService.GetMatShelfByCode(code);
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
        public JsonResult EditMatShelf(MatShelfModel matShelfModel )
        {
            var response = _matShelfService.EditMatShelf(matShelfModel);
            if (response == true)
            {
                return Json(new { Status = 202, Message = "Update Succest" });
            }
            else
            {
                return Json(new { Status = 401, Message = "Can Not Update" });
            }
        }



        [HttpDelete("Delete")]
        public JsonResult DeleteMatShelf(string code)
        {
            var response = _matShelfService.DeleteMatShelf(code);
            if (response == true)
            {
                return Json(new { Status = 204, Message = "Delete Succest" });
            }
            else
            {
                return Json(new { Status = 401, Message = "Can Not Delete" });
            }
        }
    }
}
