using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.Api.Games
{
    public class GamesRepository : IGamesRepository
    {
        private static readonly List<Game> Games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Home = new GameTeam
                {
                    Name = "Astoria Bydgoszcz",
                    Score = 101
                },
                Guest = new GameTeam
                {
                    Name = "Polski Cukier Toruń",
                    Score = 87
                },
                Date = new DateTime(2019, 10, 10, 18, 30, 0),
                Place = "Bydgoszcz"
            }
        };

        public IEnumerable<Game> GetGames() => Games;
        public Result Add(Game game)
        {
            if (AstaLooseGame(game))
            {
                return Result.Failed("Dude, Asta can't lost the game!");;
            }
            
            game.Id = Games.Count + 1;
            Games.Add(game);

            return Result.Ok();
        }

        private static bool AstaLooseGame(Game game)
        {
            return (game.Home.IsAsta && game.Home.Score < game.Guest.Score ||
                    game.Guest.IsAsta && game.Guest.Score < game.Home.Score);
        }

        public Result Edit(Game game)
        {
            var gameToEdit = Games.FirstOrDefault(g => g.Id == game.Id);
            if (gameToEdit == null)
            {
                return Result.Failed($"There is no game with Id: '{game.Id}'");
            }

            gameToEdit.Date = game.Date;
            gameToEdit.Guest = game.Guest;
            gameToEdit.Home = game.Home;
            gameToEdit.Place = game.Place;

            return Result.Ok();
        }
    }
}