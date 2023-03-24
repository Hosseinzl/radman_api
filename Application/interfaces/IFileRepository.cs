namespace Application.interfaces
{
    public interface IFileRepository
    {
        Task<bool> AddFile(IFormFile file);
        Task<Model.File> GetFile(int id);
        bool ExistsById(int id);
        bool ExistsByName(string fileName);
    }
}
