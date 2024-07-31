using Vrnz2.Scheduler.Data.Contexts;
using Vrnz2.Scheduler.Data.Repositories.Base;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Data.Repositories
{
    public class ScheduledEventWeeklyDetailsRepository()
        : BaseRepository<DataEntity.ScheduledEventWeeklyDetails>(DbContextHelper.Instance.DefaultContext)
    {
        #region Attributes

        public override TRepository RepositoryType => TRepository.ScheduledEventMountlyDetails;

        public override string CollectionName => "scheduled_event_weekly_details";

        #endregion

        #region Methods

        public DataEntity.ScheduledEventWeeklyDetails? FindByScheduledEventId(Guid? id)
        {
            DataEntity.ScheduledEventWeeklyDetails? result = default;

            _dbContext.Exec((db) => result = db.GetCollection<DataEntity.ScheduledEventWeeklyDetails>(CollectionName)
                                                .FindOne(f => f.ScheduledEventId == id), GeneralDatabasePath);

            return result;
        }

        protected override DataEntity.ScheduledEventWeeklyDetails UpdateHandler(DataEntity.ScheduledEventWeeklyDetails persistedEntity, DataEntity.ScheduledEventWeeklyDetails newEntity)
        {
            persistedEntity.ScheduledEventId = newEntity.ScheduledEventId;

            persistedEntity.OccurrOnSunday = newEntity.OccurrOnSunday;
            persistedEntity.OccurrOnMonday = newEntity.OccurrOnMonday;
            persistedEntity.OccurrOnTuesday = newEntity.OccurrOnTuesday;
            persistedEntity.OccurrOnWednesday = newEntity.OccurrOnWednesday;
            persistedEntity.OccurrOnThursday = newEntity.OccurrOnThursday;
            persistedEntity.OccurrOnFriday = newEntity.OccurrOnFriday;
            persistedEntity.OccurrOnSaturday = newEntity.OccurrOnSaturday;

            persistedEntity.UpdatedAt = DateTimeOffset.Now;

            return persistedEntity;
        }

        #endregion
    }
}
