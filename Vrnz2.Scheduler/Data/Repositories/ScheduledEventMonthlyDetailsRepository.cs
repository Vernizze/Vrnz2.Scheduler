using Vrnz2.Scheduler.Data.Contexts;
using Vrnz2.Scheduler.Data.Repositories.Base;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Data.Repositories
{
    public class ScheduledEventMonthlyDetailsRepository()
        : BaseRepository<DataEntity.ScheduledEventMonthlyDetails>(DbContextHelper.Instance.DefaultContext)
    {
        #region Attributes

        public override TRepository RepositoryType => TRepository.ScheduledEventMountlyDetails;

        public override string CollectionName => "scheduled_event_mountly_details";

        #endregion

        #region Methods

        public DataEntity.ScheduledEventMonthlyDetails? FindByScheduledEventId(Guid? id)
        {
            DataEntity.ScheduledEventMonthlyDetails? result = default;

            _dbContext.Exec((db) => result = db.GetCollection<DataEntity.ScheduledEventMonthlyDetails>(CollectionName)
                                                .FindOne(f => f.ScheduledEventId == id), GeneralDatabasePath);

            return result;
        }

        protected override DataEntity.ScheduledEventMonthlyDetails UpdateHandler(DataEntity.ScheduledEventMonthlyDetails persistedEntity, DataEntity.ScheduledEventMonthlyDetails newEntity)
        {
            persistedEntity.ScheduledEventId = newEntity.ScheduledEventId;

            persistedEntity.ExecutionDay = newEntity.ExecutionDay;

            persistedEntity.UpdatedAt = DateTimeOffset.Now;

            return persistedEntity;
        }

        #endregion
    }
}
