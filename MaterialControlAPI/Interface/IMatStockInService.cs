using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatStockInService
    {
        IEnumerable<MatStockInModel> GetAll();
        bool AddMatStockIn(MatStockInModel matStockInModel);
        MatStockInModel GetMatStockInByCode(string code);
        bool EditMatStockIn(MatStockInModel matStockInModel);
        bool DeleteMatStockIn(string code);
    }
}
