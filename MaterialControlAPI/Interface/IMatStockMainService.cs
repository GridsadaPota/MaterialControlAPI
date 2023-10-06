using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatStockMainService
    {
        IEnumerable<MatStockMainModel> GetAll();
        bool AddMatStockMain(MatStockMainModel matStockMainModel);
        MatStockMainModel GetMatStockMainByCode(string code);
        bool EditMatStockMain(MatStockMainModel matStockMainModel);
        bool DeleteMatStockMain(string code);
        bool UpdateStockMainQty(int Material_Id, decimal Qty);
    }
}
