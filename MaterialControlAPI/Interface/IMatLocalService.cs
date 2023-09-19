using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatLocalService
    {
        IEnumerable<MatLocalModel> GetAll();
        bool AddMatLocal(MatLocalModel matLocalModel);
        MatLocalModel GetMatLocalByCode(string code);
        bool EditMatLocal(MatLocalModel matLocalModel);
        bool DeleteMatLocal(string code);

    }
}
