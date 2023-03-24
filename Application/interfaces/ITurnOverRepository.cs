using Application.Model;

namespace Application.interfaces
{
    public interface ITurnOverRepository
    {
        MetaData GetMetaData();
        AllTurnOver GetTurnOvers(DateTime fromDate, DateTime toDate, int transactionType, int page, int pageSize);
    }
}
