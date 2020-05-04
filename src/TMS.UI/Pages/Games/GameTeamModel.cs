using System.ComponentModel.DataAnnotations;

namespace TMS.UI.Pages.Games
{
    public class GameTeamModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(0, 300)]
        public int Score { get; set; }
    }
}