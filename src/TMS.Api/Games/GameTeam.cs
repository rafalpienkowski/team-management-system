namespace TMS.Api.Games
{
    public class GameTeam
    {
        public string Name { get; set; }
        public uint Score { get; set; }
        public bool IsAsta => Name.ToLowerInvariant().StartsWith("ast");
    }
}