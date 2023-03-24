using Application.Data;
using Application.interfaces;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;


namespace Application.Repository
{
    public class FileRepository : IFileRepository
    {
        
        private readonly DataContext _dataContext;
        
        public FileRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> AddFile(IFormFile postedFile)
        {
            try
            {
                using var stream = new MemoryStream();
                await postedFile.CopyToAsync(stream);

                var file = new Model.File
                {
                    fileName = postedFile.FileName,
                    content = stream.ToArray()
                };

                await _dataContext.file.AddAsync(file);
                var save = await _dataContext.SaveChangesAsync();

                return save > 0 ? true : false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ExistsById(int id)
        {
            return _dataContext.file.Any(e => e.id == id);
        }

        public bool ExistsByName(string fileName)
        {
            return _dataContext.file.Any(e => e.fileName == fileName);
        }

        public async Task<Model.File> GetFile(int id)
        {
            var file = await _dataContext.file.FindAsync(id);
            return file;

        }

    }
}
