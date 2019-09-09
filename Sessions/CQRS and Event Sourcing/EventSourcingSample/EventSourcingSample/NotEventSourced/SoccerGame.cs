using EventSourcingSample.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcingSample.NotEventSourced
{
    public class SoccerGame : Entity
    {
        public SoccerGame(string id, string homeTeamId, string guestTeamId)
        {
            Id = id;
            HomeTeamId = homeTeamId;
            GuestTeamId = guestTeamId;
        }

        public string HomeTeamId { get; }
        public string GuestTeamId { get; }
        public DateTime? GameStartedAt { get; private set; }
        public DateTime? GameEndedAt { get; private set; }
        public int HomeTeamScore { get; private set; }
        public int GuestTeamScore { get; private set; }
        public bool GameIsRunning => GameStartedAt.HasValue && !GameEndedAt.HasValue;


        public void StartGame()
        {
            GameStartedAt = DateTime.Now;
        }

        public void EndGame()
        {
            GameEndedAt = DateTime.Now;
        }

        public void HomeTeamGoal()
        {
            HomeTeamScore++;
        }

        public void GuestTeamGoal()
        {
            GuestTeamScore++;
        }

        public void PrintStats()
        {
            Console.WriteLine($"{HomeTeamId} ({HomeTeamScore}) : {GuestTeamId}({GuestTeamScore})");
        }
    }
}
