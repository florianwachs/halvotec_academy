using System;
using Xunit;
using EventSourcingSample.EventSourced;
using EventSourcingSample.Abstract;

namespace EventSourcingSample.Tests
{
    public class EventSourcedGameTests
    {
        [Fact]
        public void Should_be_able_to_create_new_game()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            Assert.Equal(0, game.GuestTeamScore);
            Assert.Equal(0, game.HomeTeamScore);
            Assert.False(game.GameIsRunning);
        }

        [Fact]
        public void Should_be_able_to_start_a_game()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            Assert.False(game.GameIsRunning);
            game.StartGame();
            Assert.True(game.GameIsRunning);
        }

        [Fact]
        public void Should_be_able_to_end_a_game()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            Assert.False(game.GameIsRunning);
            game.StartGame();
            Assert.True(game.GameIsRunning);
            game.EndGame();
            Assert.False(game.GameIsRunning);
        }

        [Fact]
        public void Should_be_able_to_play_game()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            game.StartGame();
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.GuestTeamGoal("Reus");
            game.EndGame();
            game.PrintStats();
            Assert.Equal(3, game.HomeTeamScore);
            Assert.Equal(1, game.GuestTeamScore);
        }

        [Fact]
        public void Should_be_able_to_commit_events()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            game.StartGame();
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.GuestTeamGoal("Reus");
            game.EndGame();

            var events = game.Commit();

            Assert.NotEmpty(events);
        }

        [Fact]
        public void Should_be_able_to_hydrate_from_events()
        {
            var game = new SoccerGame("Bayern - BVB", "Bay", "BVB");
            game.StartGame();
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.HomeTeamGoal("Müller");
            game.GuestTeamGoal("Reus");
            game.EndGame();

            var events = game.Commit();


            var newGame = new SoccerGame();
            var aggregate = newGame as IEventSourcingAggregate<string>;
            foreach (var ev in events)
            {
                aggregate.ApplyEvent(ev, 0);
            }

            Assert.Equal(3, game.HomeTeamScore);
            Assert.Equal(1, game.GuestTeamScore);

        }
    }
}
