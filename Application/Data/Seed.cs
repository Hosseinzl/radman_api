using Application.Model;

namespace Application.Data
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void SeedDataContext()
        {
            if (!_dataContext.competitions.Any())
            {
                var state1 = new State
                {
                
                    title = "مسابقات جاری"
                };

                var state2 = new State
                {
             
                    title = "مسابقات در جریان"
                };
                
                _dataContext.states.Add(state1);
                _dataContext.states.Add(state2);
                _dataContext.SaveChanges();
                
                var competitions = new List<Competition>
                {
                    new Competition
                    {
                        id = "8b6dfe44-36f8-43b8-b42f-198d94ec2a07",
                        title = "پیش بینی شاخص شنبه 12 شهریور",
                        state = state1,
                        startTime = new DateTime(2022, 9, 3, 8, 30, 0),
                        endTime = new DateTime(2022, 9, 3, 12, 30, 0),
                        competitorCounts = 72,
                        yourPoint = 130,
                        totalCount = 1256778,
                        isUserAttend = true
                    },
                    new Competition
                    { 
                        id = "c3a3b8da-08db-4225-870d-57de564c54de",
                        title = "پیش بینی هم وزن شنبه 12 شهریور",
                        state = state1,
                        startTime = new DateTime(2022, 9, 3, 8, 30, 0),
                        endTime = new DateTime(2022, 9, 3, 12, 30, 0),
                        competitorCounts = 90,
                        yourPoint = 0,
                        totalCount = 95007,
                        isUserAttend = false
                    },
                    new Competition
                    {
                        id = "7823b819-a741-4b67-9298-3e95b793833c",
                        title = "پیش بینی هم وزن شنبه 11 شهریور",
                        state = state2,
                        startTime = new DateTime(2022, 9, 2, 8, 30, 0),
                        endTime = new DateTime(2022, 9, 2, 12, 30, 0),
                        competitorCounts = 109,
                        yourPoint = 30,
                        totalCount = 12300,
                        isUserAttend = true
                    },
                    new Competition
                    {
                        id = "1aa069ad-de3e-4f4f-9bce-737ad4572496",
                        title = "پیش بینی هم وزن شنبه 11 شهریور",
                        state = state2,
                        startTime = new DateTime(2022, 9, 2, 8, 30, 0),
                        endTime = new DateTime(2022, 9, 2, 12, 30, 0),
                        competitorCounts = 109,
                        yourPoint = 30,
                        totalCount = 12300,
                        isUserAttend = false
                    }
                };

                _dataContext.competitions.AddRange(competitions);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.credits.Any())
            {
                var generaInfo = new GeneralInfo
                {
                    creditId = 1,
                    totalCash = 1350000,
                    totalAsset = 1770000,
                    totalStock = 420000,
                    remainingDays = 15
                };
                var portfoloItems = new List<PortfoloItems>
                {
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شبندر",
                         price = 5430,
                         quantity = 100,
                         value = 543000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شستا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },
                    new PortfoloItems
                    {
                         idOfCredit = 1,
                         title = "شپنا",
                         price = 1340,
                         quantity = 100,
                         value = 134000
                    },

                };

                var credit = new Credit
                {
                    generalInfo = generaInfo,
                    portfoloItems = portfoloItems
                };

                //_dataContext.portfolioItems.AddRange(portfoloItems);
                //_dataContext.generalinfos.Add(generaInfo);
                _dataContext.credits.Add(credit);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.friends.Any())
            {
                var friendInvitation = new List<FriendInvitation>
                {
                    new FriendInvitation
                    {
                        UserId = 1,
                        isMale = true,
                        moblie = "09022382204",
                        recivedPoint = 2,
                        state = "rejected"
                    },                   
                    new FriendInvitation
                    {
                        UserId = 1,
                        isMale = false,
                        moblie = "09125535640",
                        recivedPoint = 6,
                        state = "accepted"
                    }
                };
                var invitationStatistics = new InvitationStatistics
                {
                    idUser = 1,
                    acceptedCount = 1,
                    totalInvitationPoint = 8,
                    totalSentInvitationCount = 2,
                    waitingCount = 0
                };
                var friend = new Friends
                {
                    totalCount = 2,
                    friendInvitations = friendInvitation,
                    invitationStatistics = invitationStatistics
                };

                _dataContext.friends.Add(friend);
                _dataContext.SaveChanges();
                
           }
            if (!_dataContext.grades.Any())
            {
                var grades = new List<Grade>
                {
                    new Grade {
                        id = "63e11398aa7622e9032f90c1",
                        name = "خاکستری",
                        min = 0,
                        max = 40000,
                        isMaxInfinity = false,
                        colorHex = "#DAF7A6"
                    },
                    new Grade {
                        id = "63e11398aa7622e9032f90c3",
                        name = "نارنجی",
                        min = 40000,
                        max = 100000,
                        isMaxInfinity = false,
                        colorHex = "#FF5733"
                    },
                    new Grade {
                        id = "63e11398aa7622e9032f90c5",
                        name = "نقره ای",
                        min = 200000,
                        max = 700000,
                        isMaxInfinity = false,
                        colorHex = "#900C3F"
                    },
                    new Grade {
                        id = "63e11398aa7622e9032f90c6",
                        name = "طلایی",
                        min = 700000,
                        max = 0,
                        isMaxInfinity = true,
                        colorHex = "#581845"
                    },
                    new Grade {
                        id = "63e11398aa7622e9032f90c2",
                        name = "زرد",
                        min = 10000,
                        max = 40000,
                        isMaxInfinity = false,
                        colorHex = "#FFC300"
                    },

                };
                _dataContext.grades.AddRange(grades);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category {
                        id= "637cac1e51ffee7ca3d656ec",
                        name= "بسته های اعتباری",
                        productCounts= 1,
                        predefinedCategoryType = 0
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656ed",
                        name= "برگشت کارمزد نقدی",
                        productCounts= 1,
                        predefinedCategoryType = 1
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656ee",
                        name= "کالاهای دیجیتال",
                        productCounts= 1,
                        predefinedCategoryType = 2
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656ef",
                        name= "دوره های آموزشی",
                        productCounts= 1,
                        predefinedCategoryType = 3
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656f0",
                        name= "کارت هدیه",
                        productCounts= 1,
                        predefinedCategoryType = 4
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656f1",
                        name= "امور خیریه",
                        productCounts= 1,
                        predefinedCategoryType = 5
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656f2",
                        name= "لوازم خانگی",
                        productCounts= 1,
                        predefinedCategoryType = null
                    },
                    new Category {
                        id= "637cac1e51ffee7ca3d656f3",
                        name= "لوازم دکوراتیو",
                        productCounts= 1,
                        predefinedCategoryType = null
                    },
                };

                _dataContext.categories.AddRange(categories);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.rewards.Any())
            {
                var rewards = new List<Reward>
                {
                    new Reward {
                        id= "63d5653446717dc213db507d",
                        title= "برگشت کارمزد نقدی",
                        miniDescription= "برگشت کارمزد 100 درصدی بی نهایت",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638121079057593722_3a706a6e-3071-4075-bed9-735325072daf",
                        point= 7000,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656ed"
                    },
                    new Reward {
                        id= "63dfec2646717dc213db9054",
                        title= "کارت هدیه دیجی کالا",
                        miniDescription= "کارت هدیه 1 میلیون تومانی دیجی کالا",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638112287243129484_a0e9a193-ca17-4b73-9d0a-69bbd38f80d5",
                        point= 7000,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656f0"
                    },
                    new Reward {
                        id= "63ed59f731a100d6c05251d3",
                        title= "کمک به موسسه ی محک",
                        miniDescription= "کمک 100 هزارتومانی به موسسه ی محک",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638121087665768938_28947954-2095-43e5-9e7a-55877cdb5d65",
                        point= 100,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656f1"
                    },
                    new Reward {
                        id= "63ed5aad31a100d6c0525211",
                        title= "دوره ی اختیار و آپشن",
                        miniDescription= "دوره ی آموزشی یک ماهه اختیار معامله",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638121095028976049_2ae1dcfe-4f01-42fa-a926-fc59ac6c0ca7",
                        point= 490,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656ef"
                    },
                    new Reward {
                        id= "63ed5b3631a100d6c0525237",
                        title= "iphone 14 به صورت Register شده",
                        miniDescription= "iphone 14 به صورت Register شده",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638121090932190360_576a35f4-cc16-4637-9a8e-66cbf9fb42e9",
                        point= 1200000,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656ee"
                    },
                    new Reward {
                        id= "63d55ed046717dc213db4e2b",
                        title= "بسته اعتباری",
                        miniDescription= "توضیحات مختصر در مورد بسته اعتباری",
                        isFavorite= false,
                        imageUrl= "http://clubapitest.radmanict.com/api/File/Download/638105962157607289_eb0c7ccf-6b5d-453f-9e22-1ed1e48819fb",
                        point= 1500,
                        createdDate= new DateTime(1,1,1,0,0,0),
                        sellCount= 0,
                        categoryId="637cac1e51ffee7ca3d656ec"
                    },
                };
                _dataContext.rewards.AddRange(rewards);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.sortTypes.Any())
            {
                var sortTypes = new List<SortType>
                {
                    new SortType
                    {
                        name = "Newest",
                        persianName = "جدید ترین",
                    },
                    new SortType
                    {
                        name = "MostSeller",
                        persianName = "پر فروش ترین",
                    },
                    new SortType
                    {
                        name = "MostExpencive",
                        persianName = "گران ترین",
                    }
                };

                _dataContext.sortTypes.AddRange(sortTypes);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.rewardDetails.Any())
            {
                var details = new List<RewardDetails>
                {
                    new RewardDetails
                    {
                        id = "0",
                        rewardId = "63d5653446717dc213db507d",
                        description = null
                    },
                    new RewardDetails
                    {
                        id = "1",
                        rewardId = "63dfec2646717dc213db9054",
                        description = "با این کد کیف پول شما در سایت دیجی کالا به مقدار یک میلیون تومان شارژ خواهد شد."
                    },
                    new RewardDetails
                    {
                        id = "2",
                        rewardId = "63ed59f731a100d6c05251d3",
                        description = null
                    },
                    new RewardDetails
                    {
                        id = "3",
                        rewardId = "63ed5aad31a100d6c0525211",
                        description = null
                    },
                    new RewardDetails
                    {
                        id = "4",
                        rewardId = "63ed5b3631a100d6c0525237",
                        description = null
                    },
                    new RewardDetails
                    {
                        id = "5",
                        rewardId = "63d55ed046717dc213db4e2b",
                        description = "<p>بسته ی اعتباری 10 میلیون تومانی 30 روزه </p><p>مناسب برای پورتفوی زیر 100 میلیون تومان</p><p></p>"
                    }
                };

                _dataContext.rewardDetails.AddRange(details);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.pointState.Any())
            {
                var pointStates = new List<PointState>
                {
                    new PointState
                    {
                        id = 0,
                        title = "انجام شده",
                    },
                    new PointState
                    {
                        id = 1,
                        title = "کنسل شده",
                    },
                };
                _dataContext.pointState.AddRange(pointStates);
                _dataContext.SaveChanges();
            }
            if (!_dataContext.eventType.Any())
            {
                var eventTypes = new List<EventType>
                {
                    new EventType
                    {
                        id = 0,
                        title = "اعتبار",
                    },
                    new EventType
                    {
                        id = 1,
                        title = "معاملات",
                    },
                    new EventType
                    {
                        id = 2,
                        title = "پاداش",
                    },
                };
                _dataContext.eventType.AddRange(eventTypes);
                _dataContext.SaveChanges();
            }
            if(!_dataContext.transactionType.Any())
            { 
                var transactionTypes = new List<TransactionType>
                { 
                    new TransactionType
                    {
                        id = 0,
                        title = "دریافت",
                    },
                    new TransactionType
                    {
                        id = 1,
                        title = "پرداخت",
                    },
                    new TransactionType
                    {
                        id = 2,
                        title = "کنسل",
                    }

                };
                _dataContext.transactionType.AddRange(transactionTypes);
                _dataContext.SaveChanges();
            }
            if(!_dataContext.turnOvers.Any())
            {
                var turnOvers = new List<TurnOverDataBase>
                {
                    new TurnOverDataBase
                    {
                        
                        id = "6415821a0d5533478e24b77c",
                        title = "امتیاز معاملات 27 اسفند",
                        date = new DateTime(2023, 1, 28, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 19626,
                        state = 0  
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b77d",
                        title = "امتیاز معاملات 25 اسفند",
                        date = new DateTime(2023, 3, 16, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 37342,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b77e",
                        title = "امتیاز معاملات 24 اسفند",
                        date = new DateTime(2023, 3, 15, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 25561,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b77f",
                        title = "امتیاز معاملات 23 اسفند",
                        date = new DateTime(2023, 3, 14, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 60887,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b780",
                        title = "امتیاز معاملات 22 اسفند",
                        date = new DateTime(2023, 3, 13, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 12677,
                        state = 0
                        
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b781",
                        title = "امتیاز معاملات 20اسفند",
                        date = new DateTime(2023, 3, 11, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 61494,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b7a9",
                        title = "خرید از پاداش کارت هدیه دیجی کالا",
                        date = new DateTime(2023, 1, 30, 9, 19, 22),
                        transactionType = 1,
                        eventType = 2,
                        point = -7000,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b7a5",
                        title = "امتیاز معاملات 15 بهمن",
                        date = new DateTime(2023, 2, 4, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 46667,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b7a6",
                        title = "خرید از پاداش بسته اعتباری",
                        date = new DateTime(2023, 2, 4, 9, 19, 22),
                        transactionType = 1,
                        eventType = 2,
                        point = -1500,
                        state = 0
                    },
                    new TurnOverDataBase
                    {
                        id = "6415821a0d5533478e24b7ac",
                        title = "خرید از پاداش بسته اعتباری",
                        date = new DateTime(2023, 2, 4, 9, 19, 22),
                        transactionType = 1,
                        eventType = 2,
                        point = -1500,
                        state = 0
                    },
                    new TurnOverDataBase
                    {

                        id = "6415821a0d5533478e24b7a8",
                        title = "امتیاز معاملات 13 بهمن",
                        date = new DateTime(2023, 2, 2, 9, 19, 22),
                        transactionType = 0,
                        eventType = 1,
                        point = 6716,
                        state = 0
                    },
                    new TurnOverDataBase
                    {
                        id = "6415821a0d5533478e24b799",
                        title = " iphone 14 به صورت Register شده",
                        date = new DateTime(2023, 2, 12, 9, 19, 22),
                        transactionType = 1,
                        eventType = 2,
                        point = -1200000,
                        state = 0
                    },
                };
                _dataContext.turnOvers.AddRange(turnOvers);
                _dataContext.SaveChanges();
            }
        }
    }
}
