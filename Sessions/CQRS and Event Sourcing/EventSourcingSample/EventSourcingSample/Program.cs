using System;

namespace EventSourcingSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var newGame = new NotEventSourced.SoccerGame("Bayern - BVB", "Bay", "BVB");
            newGame.HomeTeamGoal();
            newGame.HomeTeamGoal();
            newGame.HomeTeamGoal();
            newGame.GuestTeamGoal();

            newGame.PrintStats();


        }
    }
}
