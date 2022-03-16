﻿using AllAboutGames.Core;
using AllAboutGames.Core.Attributes;
using AllAboutGames.Data.DTO;
using AllAboutGames.Data.Models;
using AllAboutGames.Data.ViewModels;
using AllAboutGames.Services;
using AutoMapper;
using Newtonsoft.Json;
using Serilog;
#nullable disable

namespace AllAboutGames.Handlers
{
    public class GameHandler
    {
        private readonly GameService GameService;
        private readonly IMapper Mapper;

        public GameHandler(GameService gameService, IMapper mapper)
        {
            this.GameService = gameService;
            this.Mapper = mapper;
        }

        [BindRequest(typeof(GameDTO))]
        public async Task<CheckResult> SaveGameAsync(GameDTO request)
        {
            var checkResult = PropertyValidator.Validate(request);
            if (checkResult.IsFailed)
            {
                Log.Fatal("ERORS: ", checkResult.GetErrors());
                return checkResult;
            }

            await this.GameService.SaveEntityAsync<Game, GameDTO>(request);
            return checkResult;
        }

        public async Task<GameViewModel> GetGame(int gameID)
        {
            var game = await this.GameService.GetEntityAsync<Game>(x => x.GameID == gameID);
            return game == null ? null : this.Mapper.Map(game, new GameViewModel());
        }
    }

    public class SaveGameRequest
    {
        public GameDTO GameDTO { get; set; }
    }
}
