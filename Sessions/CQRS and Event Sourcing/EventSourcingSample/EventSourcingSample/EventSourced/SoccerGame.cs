using EventSourcingSample.Abstract;
using EventSourcingSample.EventSourced.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.EventSourced
{
    public class SoccerGame : AggregateBase
    {
        public SoccerGame()
        {
        }

        public SoccerGame(string id, string homeTeamId, string guestTeamId)
        {
            RaiseEvent(new GameCreated(id, homeTeamId, guestTeamId, DateTime.Now));
        }

        public string HomeTeamId { get; private set; }
        public string GuestTeamId { get; private set; }
        public DateTime? GameStartedAt { get; private set; }
        public DateTime? GameEndedAt { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int GuestTeamScore { get; private set; }
        public bool GameIsRunning => GameStartedAt.HasValue && !GameEndedAt.HasValue;

        public void StartGame()
        {
            RaiseEvent(new GameStarted(Id, DateTime.Now));
        }

        public void EndGame()
        {
            RaiseEvent(new GameEnded(Id, DateTime.Now));
        }

        public void HomeTeamGoal(string playerId)
        {
            RaiseEvent(new GoalScored(Id, DateTime.Now, HomeTeamId, playerId));
        }

        public void GuestTeamGoal(string playerId)
        {
            RaiseEvent(new GoalScored(Id, DateTime.Now, GuestTeamId, playerId));
        }

        public void PrintStats()
        {
            Console.WriteLine($"{HomeTeamId} ({HomeTeamScore}) : {GuestTeamId}({GuestTeamScore})");
        }

        internal void Apply(GoalScored ev)
        {
            if (ev.TeamId == HomeTeamId)
            {
                HomeTeamScore++;
            }
            else
            {
                GuestTeamScore++;
            }
        }

        internal void Apply(GameCreated ev)
        {
            Id = ev.AggregateId;
            HomeTeamId = ev.HomeTeamId;
            GuestTeamId = ev.GuestTeamId;
        }

        internal void Apply(GameStarted ev)
        {
            GameStartedAt = ev.Timestamp;
        }

        internal void Apply(GameEnded ev)
        {
            GameEndedAt = ev.Timestamp;
        }

        public IEnumerable<IDomainEvent<string>> Commit()
        {
            var eventAggregate = this as IEventSourcingAggregate<string>;
            var events = eventAggregate.GetUncommittedEvents().ToArray();
            eventAggregate.ClearUncommittedEvents();
            return events;
        }
    }
}
