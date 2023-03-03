namespace Core.Contracts
{
    using Common.Models;
    using Data.Models.Entities;

    public interface IExcelManager
    {
        ManagerResult<string> CompararExcels(Stream fileStream, string fileName, string ruta);
    }
}
