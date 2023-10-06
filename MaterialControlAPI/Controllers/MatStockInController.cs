using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using MaterialControlAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatStockInController : Controller
    {
        private readonly IMatStockInService _matStockInService;
        private readonly IMatStockMainService _matStockMainService;
        public MatStockInController(IMatStockInService matStockInService, IMatStockMainService matStockMainService)
        {
            _matStockInService = matStockInService;
            _matStockMainService = matStockMainService;
        }


        [HttpPost("Add")]
        public JsonResult Add(MatStockInModel matStockIn)
        {

            var response = _matStockInService.AddMatStockIn(matStockIn);
            if (response == true)
            {
                _matStockMainService.UpdateStockMainQty(matStockIn.Material_Id, matStockIn.StockIn_Qty);
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
            IEnumerable<MatStockInModel> list = _matStockInService.GetAll();
            return Json(list);
        }


        [HttpGet("GetMatStockIn")]
        public JsonResult GetMatStockIn(int Id)
        {
            var response = _matStockInService.GetMatStockInById(Id);
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
        public JsonResult EditMatStockIn(MatStockInModel matStockInModel)
        {
            var response = _matStockInService.EditMatStockIn(matStockInModel);
            if (response == true)
            {
                return Json(new { Status = 202, Message = "Update Succest" });
            }
            else
            {
                return Json(new { Status = 401, Message = "Can Not Update" });
            }
        }


        [HttpDelete("DeleteMatStockIn")]
        public JsonResult DeleteMatStockIn(int Id)
        {
            var response = _matStockInService.DeleteMatStockIn(Id);
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
