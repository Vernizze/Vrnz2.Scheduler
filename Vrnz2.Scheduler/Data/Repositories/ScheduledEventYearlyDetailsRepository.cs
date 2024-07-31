using Vrnz2.Scheduler.Data.Contexts;
using Vrnz2.Scheduler.Data.Repositories.Base;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Data.Repositories
{
    public class ScheduledEventYearlyDetailsRepository()
        : BaseRepository<DataEntity.ScheduledEventYearlyDetails>(DbContextHelper.Instance.DefaultContext)
    {
        #region Attributes

        public override TRepository RepositoryType => TRepository.ScheduledEventMountlyDetails;

        public override string CollectionName => "scheduled_event_yearly_details";

        #endregion

        #region Methods

        public DataEntity.ScheduledEventYearlyDetails? FindByScheduledEventId(Guid? id)
        {
            DataEntity.ScheduledEventYearlyDetails? result = default;

            _dbContext.Exec((db) => result = db.GetCollection<DataEntity.ScheduledEventYearlyDetails>(CollectionName)
                                                .FindOne(f => f.ScheduledEventId == id), GeneralDatabasePath);

            return result;
        }

        protected override DataEntity.ScheduledEventYearlyDetails UpdateHandler(DataEntity.ScheduledEventYearlyDetails persistedEntity, DataEntity.ScheduledEventYearlyDetails newEntity)
        {
            persistedEntity.ScheduledEventId = newEntity.ScheduledEventId;

            persistedEntity.ExecutionDate = newEntity.ExecutionDate;

            persistedEntity.UpdatedAt = DateTimeOffset.Now;

            return persistedEntity;
        }

        #endregion
    }
}
