using Application.Data;
using Application.interfaces;
using Application.Model;

namespace Application.Repository
{
    public class RewardRepository : IRewardRepository
    {

        private readonly DataContext _dataContext;
        public RewardRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool Buy(int count, string rewardId, string token)
        {
            var user = _dataContext.users.Where(u => u.token == token);
            //do something with user
            return true;
        }

        public bool ExistsReward(string rewardId)
        {
            return _dataContext.rewards.Any(r => r.id == rewardId);
        }

        public List<Category> GetAllCategories()
        {
            return _dataContext.categories.ToList();
        }

        public RewardDetail GetRewardDetails(string rewardId)
        {
            var reward = _dataContext.rewards.Where(r => r.id == rewardId).FirstOrDefault();
            var detail = _dataContext.rewardDetails.Where(r => r.rewardId == rewardId).FirstOrDefault();
            return new RewardDetail
            {
                description = detail.description,
                categoryId = reward.categoryId,
                createdDate = reward.createdDate,
                imageUrl = reward.imageUrl,
                isFavorite = reward.isFavorite,
                miniDescription = reward.miniDescription,
                point = reward.point,
                id = reward.id,
                sellCount = reward.sellCount,
                title = reward.title
            };
        }

        public Rewards GetRewardList(int max, string categoriesId, int pageSize, int page, int? sort, bool isFavorite, int min)
        {
            var rewards = _dataContext.rewards.ToList();

            var categories = categoriesId.Split(',');
            FilterRewards(ref rewards, max, categories, pageSize, page, sort, isFavorite, min);

            return new Rewards
            {
                totalCount = rewards.Count(),
                rewards = rewards
            };

        }

        private void FilterRewards(ref List<Reward> rewards, int max, string[] categories, int pageSize, int page, int? sort, bool isFavorite, int min)
        {
            if (categories.Any())
            {
                rewards = rewards.Where(r => categories.Any(c => r.categoryId.Contains(c))).ToList();
            }

            //filter by max
            if (max > 0)
            {
                rewards = rewards.Where(r => r.point <= max).ToList();
            }

            //filter by min
            if (min > 0)
            {
                rewards = rewards.Where(r => r.point >= min).ToList();
            }

            //filter by isFavorite
            if (isFavorite)
            {
                rewards = rewards.Where(r => r.isFavorite).ToList();
            }

            //sort by sort case 1 newest, case 2 mostsaller, case 3 mostexpensive
            switch (sort)
            {
                case 1:
                    rewards = rewards.OrderByDescending(r => r.createdDate).ToList();
                    break;
                case 2:
                    rewards = rewards.OrderByDescending(r => r.sellCount).ToList();
                    break;
                case 3:
                    rewards = rewards.OrderByDescending(r => r.point).ToList();
                    break;
                default:
                    break;
            }

            //sort by pageSize and page
            rewards = rewards.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
        }

        public List<SortType> GetSortTypes()
        {
            return _dataContext.sortTypes.ToList();
        }

       
    }
}
