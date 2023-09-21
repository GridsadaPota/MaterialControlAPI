using MaterialControlAPI.Interface;
using MaterialControlAPI.Models;
using MaterialControlAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaterialControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatStockMainController : Controller
    {
        private readonly IMatStockMainService _matStockMainService;
        public MatStockMainController(IMatStockMainService matStockMainService)
        {
            _matStockMainService = matStockMainService;
        }


        [HttpPost("Add")]
        public JsonResult Add(MatStockMainModel matStockMain)
        {
            var response = _matStockMainService.AddMatStockMain(matStockMain);
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
            IEnumerable<MatStockMainModel> list = _matStockMainService.GetAll();
            return Json(list);
        }


        [HttpGet("GetMatStockMain")]
        public JsonResult GetMatStockMain(string code)
        {
            var response = _matStockMainService.GetMatStockMainByCode(code);
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
