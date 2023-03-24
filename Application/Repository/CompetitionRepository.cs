using Application.Data;
using Application.interfaces;
using Application.Model;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly DataContext _dataContext;

        public CompetitionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public ICollection<Competition> GetCompetitions()
        {
            return _dataContext.competitions.Include(c => c.state).ToList();
        }
    }
}
