using Application.Data;
using Application.Dto;
using Application.interfaces;
using Application.Migrations;
using Application.Model;
using AutoMapper;

namespace Application.Repository
{
    public class TurnOverRepository : ITurnOverRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;


        public TurnOverRepository(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }
        
        public MetaData GetMetaData()
        {
            var pointState = _dataContext.pointState.ToList();
            var eventTypes = _dataContext.eventType.ToList();
            var transactionTypes = _dataContext.transactionType.ToList();
            return new MetaData{
                pointState = pointState,
                eventTypes = eventTypes,
                transactionTypes = transactionTypes
            };
        }

        public AllTurnOver GetTurnOvers(DateTime fromDate, DateTime toDate, int transactionType, int page, int pageSize)
        {
            var allTurnOver = new AllTurnOver();

            var turnOvers = _dataContext.turnOvers.ToList();

            allTurnOver.totalCount = turnOvers.Count();

            FilterTurnOvers(ref turnOvers, fromDate, toDate, transactionType, page, pageSize);            
            InitialReports(ref allTurnOver);
            InitialTurnOvers(turnOvers, ref allTurnOver);


            return allTurnOver;
        }

        private void FilterTurnOvers(ref List<TurnOverDataBase> turnOvers, DateTime fromDate, DateTime toDate, int transactionType, int page, int pageSize)
        {

            if (fromDate != DateTime.MinValue) turnOvers = turnOvers.Where(e => e.date >= fromDate).ToList();
            if (fromDate != DateTime.MinValue) turnOvers = turnOvers.Where(e => e.date <= toDate).ToList();

            //filter by transactionType
            if (transactionType == 0 || transactionType == 1 || transactionType == 2)
                turnOvers = turnOvers.Where(e => e.transactionType == transactionType).ToList();

            turnOvers = turnOvers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        private void InitialTurnOvers(List<TurnOverDataBase> turnOvers, ref AllTurnOver allTurnOver)
        {            
            foreach (TurnOverDataBase turnOver in turnOvers)
            {

                allTurnOver.turnOvers.Add(new TurnOvers
                {
                    id = turnOver.id,
                    title = turnOver.title,
                    date = turnOver.date,
                    eventType = GetMetaData().eventTypes.Where(e => e.id == turnOver.eventType).FirstOrDefault(),
                    transactionType = GetMetaData().transactionTypes.Where(e => e.id == turnOver.transactionType).FirstOrDefault(),
                    state = GetMetaData().pointState.Where(e => e.id == turnOver.state).FirstOrDefault(),
                    point = turnOver.point
                });
                if (turnOver.transactionType == 0 && turnOver.state == 0)
                {
                    allTurnOver.turnOverReport.income[turnOver.eventType].point += turnOver.point;
                    allTurnOver.totalIncome += turnOver.point;
                }
                else if (turnOver.transactionType == 1 && turnOver.state == 0)
                {
                    allTurnOver.turnOverReport.outcome[turnOver.eventType].point += turnOver.point;
                    allTurnOver.totalOutcome += turnOver.point;
                }
            }

            allTurnOver.turnOverReport.income.RemoveAll(e => e.point == 0);
            allTurnOver.turnOverReport.outcome.RemoveAll(e => e.point == 0);
        }

        private void InitialReports(ref AllTurnOver turnOvers)
        {
            foreach (EventType eventType in GetMetaData().eventTypes)
            {
                turnOvers.turnOverReport.income.Add(new Report
                {
                    title = eventType.title,
                    point = 0,
                    percentage = 0
                });
                turnOvers.turnOverReport.outcome.Add(new Report
                {
                    title = eventType.title,
                    point = 0,
                    percentage = 0
                });
            }
        }
    }
}
