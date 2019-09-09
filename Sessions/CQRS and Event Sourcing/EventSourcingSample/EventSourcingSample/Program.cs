using System;

namespace EventSourcingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            RunNotEventSourced();
            RunEventSourced();
        }

        private static void RunNotEventSourced()
        {
            var newGame = new NotEventSourced.SoccerGame("Bayern - BVB", "Bay", "BVB");
            newGame.HomeTeamGoal();
            newGame.HomeTeamGoal();
            newGame.HomeTeamGoal();
            newGame.GuestTeamGoal();

            newGame.PrintStats();
        }
        private static void RunEventSourced()
        {
            var newGame = new EventSourced.SoccerGame("Bayern - BVB", "Bay", "BVB");
            newGame.HomeTeamGoal("Müller");
            newGame.HomeTeamGoal("Müller");
            newGame.HomeTeamGoal("Müller");
            newGame.GuestTeamGoal("Reus");

            newGame.PrintStats();
        }
    }
}
