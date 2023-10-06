using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using MaterialControlAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatStockOutController : Controller
    {
        private readonly IMatStockOutService _matStockOutService;
        private readonly IMatStockMainService _matStockMainService;
        public MatStockOutController(IMatStockOutService matStockOutService, IMatStockMainService matStockMainService)
        {
            _matStockOutService = matStockOutService;
            _matStockMainService = matStockMainService;            
        }


        [HttpPost("Add")]
        public JsonResult Add(MatStockOutModel matStockOutModel)
        {
          
            var response = _matStockOutService.AddMatStockOut(matStockOutModel);
            if (response == true)
            {
                _matStockMainService.UpdateStockMainQty(matStockOutModel.Material_Id, matStockOutModel.StockOut_Qty * -1);
                return Json(new { Status = 201, Message = "Add Succest" });
            }
            else
            {
                return Json(new { Status = 400, Message = "Failed Insert" });
            }
        }

        [HttpPut("Edit")]
        public JsonResult EditMatStockOut(MatStockOutModel matStockOutModel)
        {
            var response = _matStockOutService.EditMatStockOut(matStockOutModel);
            if (response == true)
            {
                return Json(new { Status = 202, Message = "Update Succest" });
            }
            else
            {
                return Json(new { Status = 401, Message = "Can Not Update" });
            }
        }


        [HttpDelete("DeleteMatStockOut")]
        public JsonResult DeleteMatStockOut(int Id)
        {
            var response = _matStockOutService.DeleteMatStockOut(Id);
            if (response == true)
            {
                return Json(new { Status = 204, Message = "Delete Succest" });
            }
            else
            {
                return Json(new { Status = 401, Message = "Can Not Delete" });
            }
        }


        [HttpGet("GetAll")]
        public JsonResult GetAll()
        {
            IEnumerable<MatStockOutModel> list = _matStockOutService.GetAll();
            return Json(list);
        }

        [HttpGet("GetMatStockOut")]
        public JsonResult GetMatStockOut(int Id)
        {
            var response = _matStockOutService.GetMatStockOutById(Id);
            if (response == null)
            {
                return Json(new { Status = 404, Message = "Not Found" });
            }
            else
            {
                return Json(response);
            }
        }
    }

}

