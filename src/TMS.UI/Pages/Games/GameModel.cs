using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BethanysPieShopHRM.ComponentsLibrary.Map;

namespace TMS.UI.Pages.Games
{
    public class GameModel
    {
        public int Id { get; set; }
        [ValidateComplexType]
        public GameTeamModel Guest { get; set; }
        [ValidateComplexType]
        public GameTeamModel Home { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Place { get; set; }
        public bool ShowHallDetails { get; set; }
        public List<Marker> Markers { get; set; } = new List<Marker>();
    }
}