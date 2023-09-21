using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatShelfService
    {
        IEnumerable<MatShelfModel> GetAll();
        bool AddMatLocal(MatShelfModel matShelfModel);
        MatShelfModel GetMatShelfByCode(string code);
        bool EditMatShelf(MatShelfModel matShelfModel);
        bool DeleteMatShelf(string code);
    }
}
