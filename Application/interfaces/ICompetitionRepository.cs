using Application.Model;

namespace Application.interfaces
{
    public interface ICompetitionRepository
    {
        ICollection<Competition> GetCompetitions();
    }
}
