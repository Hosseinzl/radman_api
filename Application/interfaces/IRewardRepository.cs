using Application.Model;

namespace Application.interfaces
{
    public interface IRewardRepository
    {
        List<Category> GetAllCategories();
        Rewards GetRewardList(int max, string categoriesId, int pageSize, int page, int? sort, bool isFavorite, int min);
        List<SortType> GetSortTypes();
        RewardDetail GetRewardDetails(string rewardId);
        bool Buy(int count, string rewardId, string token);
        bool ExistsReward(string rewardId);
    }
}
