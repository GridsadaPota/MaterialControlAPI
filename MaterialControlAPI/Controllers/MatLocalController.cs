using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using MaterialControlAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MatLocalController : Controller
    {
        private readonly IMatLocalService _matLocalService;
        public MatLocalController(IMatLocalService matLocalService)
        {
            _matLocalService = matLocalService;
        }

        [HttpPost("Add")]
        public JsonResult Add(MatLocalModel matLocal)
        {
            var response = _matLocalService.AddMatLocal(matLocal);
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
            IEnumerable<MatLocalModel> list = _matLocalService.GetAll();
            return Json(list);            
        }


        [HttpGet("GetMatLocal")]
        public JsonResult GetMatLocal(string code)
        {
            //MatTypeModel matType = _mattypeService.GetMatTypeByCode(code);
            //return  Json(matType);
            var response = _matLocalService.GetMatLocalByCode(code);
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
        public JsonResult EditMatLocal(MatLocalModel matLocalModel)
        {
            var response = _matLocalService.EditMatLocal(matLocalModel);
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
        public JsonResult DeleteMatLocal(string code)
        {
            var response = _matLocalService.DeleteMatLocal(code);
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
