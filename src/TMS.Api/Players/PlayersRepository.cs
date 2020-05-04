using System;
using System.Collections.Generic;
using System.Linq;

namespace TMS.Api.Players
{
    public class PlayersRepository : IPlayersRepository
    {
        public IEnumerable<Player> GetByTeam(uint teamId)
        {
            return _players.Where(p => p.TeamId == teamId);
        }

        public Player GetById(uint id)
        {
            return _players.FirstOrDefault(p => p.Id == id);
        }
        
        private readonly List<Player> _players = new List<Player>
        {
            // Seniors
            new Player
            {
                Number = 0, Name = "Marcel Afeltowicz", Birth = new DateTime(2000, 10, 5), Country = "Poland",
                Height = 189, Id = 0, Position = Position.SG, TeamId = 1
            },
            new Player
            {
                Number = 1, Name = "Kris Clyburn", Birth = new DateTime(1996, 4, 20), Country = "USA",
                Height = 198, Id = 1, Position = Position.SG, TeamId = 1
            },
            new Player
            {
                Number = 2, Name = "Mateusz Zębski", Birth = new DateTime(1992, 5, 13), Country = "PL",
                Height = 190, Id = 2, Position = Position.SG, TeamId = 1
            },
            new Player
            {
                Number = 3, Name = "Paweł Kopycki", Birth = new DateTime(2000, 5, 3), Country = "PL",
                Height = 200, Id = 3, Position = Position.PF, TeamId = 1
            },
            new Player
            {
                Number = 4, Name = "Dorian Szyttenholm", Birth = new DateTime(1983, 5, 2), Country = "PL",
                Height = 193, Id = 4, Position = Position.PF, TeamId = 1
            },
            new Player
            {
                Number = 5, Name = "Michał Aleksandrowicz", Birth = new DateTime(1989, 5, 10), Country = "PL",
                Height = 192, Id = 5, Position = Position.SG, TeamId = 1
            },
            new Player
            {
                Number = 8, Name = "Michał Chyliński", Birth = new DateTime(1986, 2, 22), Country = "PL",
                Height = 196, Id = 6, Position = Position.SF, TeamId = 1
            },
            new Player
            {
                Number = 21, Name = "Michał Krasuski", Birth = new DateTime(2000, 5, 21), Country = "PL",
                Height = 197, Id = 7, Position = Position.SF, TeamId = 1
            },
            new Player
            {
                Number = 22, Name = "AJ Walton", Birth = new DateTime(1990, 12, 28), Country = "USA",
                Height = 185, Id = 8, Position = Position.PG, TeamId = 1
            },
            new Player
            {
                Number = 25, Name = "Michał Nowakowski", Birth = new DateTime(1988, 6, 18), Country = "PL",
                Height = 202, Id = 9, Position = Position.PF, TeamId = 1
            },
            new Player
            {
                Number = 45, Name = "Łukasz Frąckiewicz", Birth = new DateTime(1996, 12, 27), Country = "PL",
                Height = 205, Id = 10, Position = Position.C, TeamId = 1
            },
            new Player
            {
                Number = 50, Name = "Adam Kemp", Birth = new DateTime(1990, 12, 20), Country = "USA",
                Height = 208, Id = 11, Position = Position.C, TeamId = 1
            },
            new Player
            {
                Number = 55, Name = "Marcin Nowakowski", Birth = new DateTime(1989, 11, 9), Country = "PL",
                Height = 184, Id = 12, Position = Position.PG, TeamId = 1
            },
            // Juniors
            new Player
            {
                Number = 0, Name = "Marcel Afeltowicz", Birth = new DateTime(2000, 10, 5), Country = "PL",
                Height = 189, Id = 13, Position = Position.SG, TeamId = 2
            },
            new Player
            {
                Number = 1, Name = "Kacper Bochat", Birth = new DateTime(2001, 7, 31), Country = "PL",
                Height = 170, Id = 14, Position = Position.PG, TeamId = 2
            },
            new Player
            {
                Number = 5, Name = "Paweł Kopycki", Birth = new DateTime(2000, 5, 3), Country = "PL",
                Height = 200, Id = 15, Position = Position.C, TeamId = 2
            },
            new Player
            {
                Number = 10, Name = "Mateusz Bierwagen", Birth = new DateTime(1988, 9, 3), Country = "PL",
                Height = 195, Id = 16, Position = Position.SF, TeamId = 2
            },
            new Player
            {
                Number = 11, Name = "Karol Lebiedziński", Birth = new DateTime(2002, 9, 10), Country = "PL",
                Height = 180, Id = 17, Position = Position.PG, TeamId = 2
            },
            new Player
            {
                Number = 14, Name = "Mateusz Ziółkowski", Birth = new DateTime(2001, 3, 10), Country = "PL",
                Height = 193, Id = 18, Position = Position.PF, TeamId = 2
            },
            new Player
            {
                Number = 15, Name = "Szymon Goszczyński", Birth = new DateTime(2002, 10, 26), Country = "PL",
                Height = 193, Id = 19, Position = Position.PF, TeamId = 2
            },
            new Player
            {
                Number = 22, Name = "Adam Frąckiewicz", Birth = new DateTime(2002, 4, 19), Country = "PL",
                Height = 198, Id = 20, Position = Position.C, TeamId = 2
            },
            new Player
            {
                Number = 24, Name = "Kacper Jędrzejak", Birth = new DateTime(1999, 6, 22), Country = "PL",
                Height = 191, Id = 21, Position = Position.SF, TeamId = 2
            },
            new Player
            {
                Number = 29, Name = "Wojciech Duda", Birth = new DateTime(1989, 3, 9), Country = "PL",
                Height = 198, Id = 22, Position = Position.PF, TeamId = 2
            },
            new Player
            {
                Number = 33, Name = "Maksymilian Estkowski", Birth = new DateTime(2002, 11, 20), Country = "PL",
                Height = 201, Id = 23, Position = Position.C, TeamId = 2
            },
            new Player
            {
                Number = 77, Name = "Dominik Maroszek", Birth = new DateTime(2000, 02, 29), Country = "PL",
                Height = 191, Id = 24, Position = Position.PF, TeamId = 2
            }
        };
    }
}