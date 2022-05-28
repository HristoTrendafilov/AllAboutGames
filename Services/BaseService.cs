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
        protected readonly IMapper Mapper;

        public BaseService(AllAboutGamesDataContext db, IMapper mapper)
        {
            this.Db = db;
            this.Mapper = mapper;
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
