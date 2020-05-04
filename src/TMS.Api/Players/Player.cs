using System;

namespace TMS.Api.Players
{
    public class Player
    {
        public uint Id { get; set; }
        public uint TeamId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public ushort Number { get; set; }
        public DateTime Birth { get; set; }
        public ushort Height { get; set; }
        public string Country { get; set; }
    }
}