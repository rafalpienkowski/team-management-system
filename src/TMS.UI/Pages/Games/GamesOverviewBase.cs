using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BethanysPieShopHRM.ComponentsLibrary.Map;
using Microsoft.AspNetCore.Components;
using TMS.UI.Services;

namespace TMS.UI.Pages.Games
{
    public class GamesOverviewBase : ComponentBase
    {
        [Inject]
        public IGamesService GamesService { get; set; }
        
        [Inject]
        public ILocationService LocationService { get; set; }
        protected IEnumerable<GameModel> Games { get; set; }
        protected bool IsAuthorized { get; set; }
        public GameDialogBase GameDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetGames();
        }

        private async Task GetGames()
        {
            var result = await GamesService.GetGames();
            if (result.IsOk)
            {
                Games = result.Value;
                foreach (var gameModel in Games)
                {
                    gameModel.Markers.Add(LocationService.GetMarkerFromPlace(gameModel.Place));
                }
                IsAuthorized = true;
            }

            if (result.Message == "Forbidden")
            {
                Games = new List<GameModel>();
                IsAuthorized = false;
            }
        }

        public async void GameDialog_OnDialogClose()
        {
            await GetGames();
            StateHasChanged();
        }

        protected void OpenGameDialog()
        {
            GameDialog.Game = new GameModel
                {Home = new GameTeamModel(), Guest = new GameTeamModel(), Date = DateTime.UtcNow};
            GameDialog.Show();
        }

        protected void OpenGameDialog(GameModel game)
        {
            GameDialog.Game = game;
            GameDialog.Show();
        }
    }
}