using AllAboutGames.Core;
using AllAboutGames.Data.Attributes;
using AllAboutGames.Data.DataContext;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
#nullable disable

namespace AllAboutGames.Services
{
    public class BaseService
    {
        protected readonly AllAboutGamesDataContext Db;
        private readonly IMapper Mapper;

        public BaseService(AllAboutGamesDataContext db, IMapper mapper)
        {
            this.Db = db;
            this.Mapper = mapper;
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
                .Where(x => x.IsDefined(typeof(IncludeInQuery), false))
                .ToList();

            foreach (var property in properties)
            {
                query = query.Include(property.Name);
            }

            return query;
        }

        public async Task<CheckResult> SaveEntityAsync<TEntity>(object entityDTO)
        {
            var checkResult = new CheckResult();

            var entity = Activator.CreateInstance(typeof(TEntity));
            var dbEntity = this.Mapper.Map(entityDTO, entity);
            var primaryKey = dbEntity.GetType()
                .GetProperties()
                .Where(x => x.IsDefined(typeof(KeyAttribute), false))
                .FirstOrDefault();

            if (primaryKey == null)
            {
                checkResult.AddError("Cant resolve the given model.");
                return checkResult;
            }

            var primaryKeyValue = (long)primaryKey.GetValue(dbEntity);
            if (primaryKeyValue > 0)
            {
                this.Db.Update(dbEntity);
            }
            else
            {
                await this.Db.AddAsync(dbEntity);
            }

            return checkResult;
        }

        public async Task SaveChangesAsync()
        {
            await this.Db.SaveChangesAsync();
        }
    }
}
