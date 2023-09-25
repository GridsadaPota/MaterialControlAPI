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
        public MatStockInController(IMatStockInService matStockInService)
        {
            _matStockInService = matStockInService;
        }


        [HttpPost("Add")]
        public JsonResult Add(MatStockInModel matStockIn)
        {
            var response = _matStockInService.AddMatStockIn(matStockIn);
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
            IEnumerable<MatStockInModel> list = _matStockInService.GetAll();
            return Json(list);
        }
    }
}
