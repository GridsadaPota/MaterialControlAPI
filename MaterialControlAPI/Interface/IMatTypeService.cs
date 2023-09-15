using MaterialControlAPI.Models;

namespace MaterialControlAPI.Interface
{
    public interface IMatTypeService
    {
        IEnumerable<MatTypeModel> GetAll();
        bool AddMatType(MatTypeModel matTypeModel);
        MatTypeModel GetMatTypeByCode(string code);
        bool EditMatType(MatTypeModel matTypeModel);

    }
}
