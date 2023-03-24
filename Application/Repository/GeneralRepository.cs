using Application.Data;
using Application.interfaces;
using Application.Model;

namespace Application.Repository
{
    public class GeneralRepository : IGeneralRepository
    {
        private readonly DataContext _dataContext;

        public GeneralRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public ICollection<Grade> GetAllGrades()
        {
            return _dataContext.grades.ToList();
        }
    }
}
