using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TMS.UI.Api;

namespace TMS.UI.Pages.Games
{
    public class GameDialogBase : ComponentBase
    {
        [Inject] public IGamesService GamesService { get; set; }
        public bool ShowDialog { get; set; }
        protected string ApiMessage { get; set; }
        protected bool ShowApiMessage => !string.IsNullOrEmpty(ApiMessage);
        
        public GameModel Game { get; set; }

        [Parameter] 
        public EventCallback<bool> CloseEventCallback { get; set; }

        protected async Task HandleValidSubmit()
        {
            ApiMessage = string.Empty;
            Result result = Result.Failed("");
            if (Game.Id == 0)
            {
                result = await GamesService.AddGame(Game);
            }
            else
            {
                result = await GamesService.EditGame(Game);
            }

            if (result.Failure)
            {
                RenderApiMessage(result.Message);
            }
            else
            {
                ShowDialog = false;
                await CloseEventCallback.InvokeAsync(true);
            }

            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        private void RenderApiMessage(string message)
        {
            ApiMessage = message;
        }

        protected void PlaceChanged(ChangeEventArgs e)
        {
            var newValue = (string)e.Value;
            Game.Place = newValue;
            if (newValue.ToLowerInvariant() == "toruń")
            {
                Game.Date = DateTime.UtcNow.AddMonths(3);
            }
        }
    }
}