using AllAboutGames.Data.Attributes;
using AllAboutGames.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
#nullable disable

namespace AllAboutGames.Services
{
    public class BaseService
    {
        protected readonly AllAboutGamesDataContext Db;

        public BaseService(AllAboutGamesDataContext db)
        {
            this.Db = db;
        }

        public async Task<TEntity> GetEntityAsync<TEntity>(Expression<Func<TEntity, bool>> filter) 
            where TEntity : class =>  await this.GetQuery(filter).FirstOrDefaultAsync();

        public async Task<List<TEntity>> GetEntitiesAsync<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class => await this.GetQuery(filter).ToListAsync();

        private IQueryable<TEntity> GetQuery<TEntity>(Expression<Func<TEntity, bool>> filter)
            where TEntity : class
        {
            var query = this.Db.Set<TEntity>().Where(filter);

            var properties = typeof(TEntity)
                .GetProperties()
                .Where(prop => prop.IsDefined(typeof(IncludeInQuery), false))
                .ToList();

            foreach (var property in properties)
            {
                query = query.Include(property.Name);
            }

            return query;
        }
    }
}
