using System;

namespace TMS.Api.Games
{
    public class Game
    {
        public int Id { get; set; }
        public GameTeam Guest { get; set; }
        public GameTeam Home { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
    }
}