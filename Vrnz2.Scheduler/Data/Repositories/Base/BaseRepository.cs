using Vrnz2.Scheduler.Data.Contexts;
using Vrnz2.Scheduler.Data.Entities.Base;

namespace Vrnz2.Scheduler.Data.Repositories.Base
{
    #region Enums

    public enum TRepository
    {
        ScheduledEvent = 1,
        ScheduledEventWeeklyDetails = 10,
        ScheduledEventMountlyDetails = 20,

    }

    #endregion

    public abstract class BaseRepository<TModel>
        where TModel : BaseDataEntity, new()
    {
        #region Constants

        public readonly string GeneralDatabasePath;

        #endregion

        #region Variables

        protected readonly IDbContext _dbContext;

        #endregion

        #region Constructors

        protected BaseRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;

            GeneralDatabasePath = string.Concat("Filename=", Path.Combine(_dbContext.DataPath, dbContext.DatabaseName), ";connection=shared");
        }

        #endregion

        #region Attributes

        public abstract TRepository RepositoryType { get; }

        public abstract string CollectionName { get; }

        public IDbContext DbContext => _dbContext;

        #endregion

        #region Methods

        protected abstract TModel UpdateHandler(TModel persistedEntity, TModel newEntity);

        public virtual TModel? FindById(Guid id)

        {
            TModel? result = default;

            _dbContext.Exec((db) => result = db.GetCollection<TModel>(CollectionName).FindOne(x => x.Id.Equals(id)), GeneralDatabasePath);

            return result;
        }

        public virtual List<TModel> ListAll()
        {
            List<TModel> result = [];

            _dbContext.Exec((db) =>
            {
                IEnumerable<TModel> results = db.GetCollection<TModel>(CollectionName).FindAll();

                result.AddRange(results ?? []);
            }, GeneralDatabasePath);

            return result;
        }

        public List<TModel> ListAllActives()
        {
            List<TModel> result = [];

            _dbContext.Exec((db) =>
            {
                IEnumerable<TModel> results = db.GetCollection<TModel>(CollectionName).Find(f => f.Active);

                result.AddRange(results ?? []);
            }, GeneralDatabasePath);

            return result;
        }

        public virtual void Insert(TModel dto)
        {
            _dbContext.Exec((db, model) =>
            {
                db.GetCollection<TModel>(CollectionName).Insert(model);
            }, GeneralDatabasePath, dto);
        }

        public virtual void Update(TModel entity)
        {
            _dbContext.Exec((db, model) =>
            {
                var col = db.GetCollection<TModel>(CollectionName);

                var founded = col.FindOne(x => x.Id.Equals(model.Id));

                if (founded is not null)
                    col.Update(UpdateHandler(founded, model));
            }, GeneralDatabasePath, entity);
        }

        public virtual void Delete(Guid id)
        {
            _dbContext.Exec((db, model_id) =>
            {
                db.GetCollection<TModel>(CollectionName).DeleteMany(x => x.Id.Equals(model_id));
            }, GeneralDatabasePath, id);
        }

        public virtual void DeleteAll()
        {
            _dbContext.Exec((db) => db.GetCollection<TModel>(CollectionName).DeleteAll(), GeneralDatabasePath);
        }

        #endregion
    }
}
