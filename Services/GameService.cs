using AllAboutGames.Data.DataContext;
using AllAboutGames.Data.Models;
#nullable disable

namespace AllAboutGames.Services
{
    public class GameService : BaseService
    {
        public GameService(AllAboutGamesDataContext db) : base(db) { }

        public async Task SaveGameAsync(Game game)
        {
            if (game.GameID > 0)
            {
                var entity = await Db.FindAsync<Game>(game.GameID);
                Db.Entry(entity).CurrentValues.SetValues(game);

                this.Db.Update(game);
            }
            else
            {
                await this.Db.AddAsync(game);
            }

            await this.Db.SaveChangesAsync();
        }
    }
}
