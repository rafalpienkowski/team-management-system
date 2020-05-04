using System;
using System.Net;

namespace TMS.UI.Pages.Players
{
    public class PlayerModel
    {
        public uint Id { get; set; }
        public uint TeamId { get; set; }
        public string Name { get; set; }
        public Position Position { get; set; }
        public ushort Number { get; set; }
        public DateTime Birth { get; set; }
        public ushort Height { get; set; }
        public string Country { get; set; }

        public string Image
        {
            get
            {
                if (IsFirstTeam)
                {
                    return $"/images/team_20192020/{WebUtility.UrlEncode(Name.Replace(' ', '_'))}.png";
                }
                return $"/images/team_20192020/Unknown.png";
            }
        }
        
        public bool IsFirstTeam => TeamId == 1;
    }
}