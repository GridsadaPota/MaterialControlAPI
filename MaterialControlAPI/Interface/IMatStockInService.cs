using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatStockInService
    {
        IEnumerable<MatStockInModel> GetAll();
        bool AddMatStockIn(MatStockInModel matStockInModel);
        MatStockInModel GetMatStockInById(int Id);
        bool EditMatStockIn(MatStockInModel matStockInModel);
        bool DeleteMatStockIn(int id);
    }
}
