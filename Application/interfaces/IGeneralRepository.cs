using Application.Model;

namespace Application.interfaces
{
    public interface IGeneralRepository
    {
        ICollection<Grade> GetAllGrades();
    }
}
