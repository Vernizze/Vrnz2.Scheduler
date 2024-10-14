using Vrnz2.Scheduler.Data.Contexts;
using Vrnz2.Scheduler.Data.Repositories.Base;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Data.Repositories
{
    public class ScheduledEventRepository()
        : BaseRepository<DataEntity.ScheduledEvent>(DbContextHelper.Instance.DefaultContext)
    {
        #region Attributes

        public override TRepository RepositoryType => TRepository.ScheduledEvent;

        public override string CollectionName => "scheduled_event";

        #endregion

        #region Methods

        public void SetPlaySound(Guid Id, bool playSound) 
        {
            DataEntity.ScheduledEvent? scheduledEvent = FindById(Id);

            if (scheduledEvent is null)
                return;

            scheduledEvent.PlaySound = playSound;

            Update(scheduledEvent);
        }

        protected override DataEntity.ScheduledEvent UpdateHandler(DataEntity.ScheduledEvent persistedEntity, DataEntity.ScheduledEvent newEntity)
        {
            persistedEntity.OccurrenceType = newEntity.OccurrenceType;
            persistedEntity.Description = newEntity.Description;

            persistedEntity.UpdatedAt = DateTimeOffset.Now;

            return persistedEntity;
        }

        #endregion
    }
}
