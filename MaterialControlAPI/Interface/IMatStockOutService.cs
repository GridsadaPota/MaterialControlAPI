using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatStockOutService
    {
        IEnumerable<MatStockOutModel> GetAll();
        bool AddMatStockOut(MatStockOutModel matStockOutModel);
        MatStockOutModel GetMatStockOutById(int Id);
        bool EditMatStockOut(MatStockOutModel matStockOutModel);
        bool DeleteMatStockOut(int Id);
    }
}
