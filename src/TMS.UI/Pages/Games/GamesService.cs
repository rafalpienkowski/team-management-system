using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TMS.UI.Api;

namespace TMS.UI.Pages.Games
{
    public class GamesService : IGamesService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GamesService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Result<IEnumerable<GameModel>>> GetGames()
        {
            try
            {
                var result = await _httpClient.GetJsonAsync<IEnumerable<GameModel>>(_httpContextAccessor, $"/games");
                return Result<IEnumerable<GameModel>>.Ok(result);
            }
            catch (HttpRequestException e)
            {
                return e.Message.Contains("Forbidden")
                    ? Result<IEnumerable<GameModel>>.Forbidden()
                    : Result<IEnumerable<GameModel>>.Failed(e.Message);
            }
        }

        public async Task<Result> AddGame(GameModel game)
        {
            try
            {
                var resultDto =
                    await _httpClient.PostJsonAsync<GameModel, ResultDto>(_httpContextAccessor, "/games", game);
                return resultDto.Success ? Result.Ok() : Result.Failed(resultDto.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Result> EditGame(GameModel game)
        {
            try
            {
                var resultDto =
                    await _httpClient.PutJsonAsync<GameModel, ResultDto>(_httpContextAccessor, "/games", game);
                return resultDto.Success ? Result.Ok() : Result.Failed(resultDto.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}