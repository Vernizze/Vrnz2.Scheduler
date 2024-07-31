using Vrnz2.Scheduler.Data;
using Vrnz2.Scheduler.Enums.Types;
using Tmr = System.Timers;
using DataEntity = Vrnz2.Scheduler.Data.Entities;

namespace Vrnz2.Scheduler.Workers
{
    #region Delegates

    internal delegate void NotifyMessages(List<string?>? eventMessages);

    #endregion

    internal class ScheduleWorker
    {
        #region Events

        public event NotifyMessages? NotifyMessages;

        #endregion

        #region Variables

        private static readonly Lazy<ScheduleWorker> _instance = new(() => new ScheduleWorker());

        private Tmr.Timer? _scheduleTimer;

        private readonly UnitOfWork _unitOfWork;
        private readonly List<DataEntity.ScheduledEvent> _todayEvents;
        private readonly List<DataEntity.ScheduledEvent> _todayEventsAlreadyExecuted;

        private DateTime? _startTime;

        #endregion

        #region Constructors

        private ScheduleWorker()
        {
            _unitOfWork = UnitOfWork.Instance;

            _todayEvents = [];
            _todayEventsAlreadyExecuted = [];

            _scheduleTimer = new Tmr.Timer(60 * 1000);
            _scheduleTimer.Elapsed += OnVerifySchedule;

            Start();
        }

        #endregion

        #region Attributes

        public static ScheduleWorker Instance => _instance.Value;

        public List<DataEntity.ScheduledEvent> TodayEvents => _todayEvents;
        public List<DataEntity.ScheduledEvent> TodayEventsAlreadyExecuted => _todayEventsAlreadyExecuted;

        #endregion

        #region Methods

        private void Start()
        {
            List<DataEntity.ScheduledEvent> events = _unitOfWork.ScheduledEvent.ListAllActives();

            _todayEvents.Clear();

            events.ForEach(_event =>
            {
                TOccurrence occurrenceType = _event.OccurrenceType;

                switch (occurrenceType)
                {
                    case TOccurrence.Daily:
                        ScheduleDailyEvent(_event);
                        break;
                    case TOccurrence.Weekly:
                        ScheduleWeeklyEvent(_event);
                        break;
                    case TOccurrence.Monthly:
                        ScheduleMonthlyEvent(_event);
                        break;
                    case TOccurrence.Yearly:
                        ScheduleYearlyEvent(_event);
                        break;
                }
            });

            _startTime = DateTime.Now;

            _scheduleTimer?.Start();
        }

        public void Stop()
        {
            _scheduleTimer?.Stop();

            _startTime = default;
        }

        public void Restart()
        {
            Stop();
            Start();
        }

        private void OnVerifySchedule(object? sender, Tmr.ElapsedEventArgs e)
        {
            if (_startTime is not null && DateTime.Now.Subtract(_startTime.Value) >= new TimeSpan(1, 0, 0, 0))
            {
                Restart();

                return;
            }

            TimeOnly now = TimeOnly.FromDateTime(DateTime.Now);

            List<DataEntity.ScheduledEvent> runningEvents = [];
            List<string?>? eventMessages = default;

            _todayEvents.ForEach(_todayEvent => 
            {
                if (_todayEvent is not null)
                {
                    if (_todayEvent.ExecutionTime <= now)
                    {
                        if (!string.IsNullOrWhiteSpace(_todayEvent.Description))  
                        {
                            eventMessages ??= [];

                            eventMessages.Add(_todayEvent.Description);
                        }

                        runningEvents.Add(_todayEvent);
                    }
                }
            });

            runningEvents.ForEach(alreadyExecuted => 
            {
                alreadyExecuted.Active = false;
                _unitOfWork.ScheduledEvent.Update(alreadyExecuted);

                _todayEvents.Remove(alreadyExecuted);
                
                _todayEventsAlreadyExecuted.Remove(alreadyExecuted);
            });

            NotifyMessages?.Invoke(eventMessages);
        }

        private void ScheduleDailyEvent(DataEntity.ScheduledEvent dailyEvent)
        {
            if (dailyEvent.ExecutionTime > TimeOnly.FromDateTime(DateTime.Now))
                _todayEvents.Add(dailyEvent);
        }

        private void ScheduleWeeklyEvent(DataEntity.ScheduledEvent weeklyEvent)
        {
            DataEntity.ScheduledEventWeeklyDetails? weeklyEventFound = _unitOfWork.ScheduledEventWeeklyDetails.FindByScheduledEventId(weeklyEvent.Id);

            if (weeklyEventFound is null)
                return;

            switch (DateTime.Today.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    if (weeklyEventFound.OccurrOnSunday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Monday:
                    if (weeklyEventFound.OccurrOnMonday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Tuesday:
                    if (weeklyEventFound.OccurrOnTuesday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Wednesday:
                    if (weeklyEventFound.OccurrOnWednesday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Thursday:
                    if (weeklyEventFound.OccurrOnThursday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Friday:
                    if (weeklyEventFound.OccurrOnFriday)
                        _todayEvents.Add(weeklyEvent);
                    break;
                case DayOfWeek.Saturday:
                    if (weeklyEventFound.OccurrOnSaturday)
                        _todayEvents.Add(weeklyEvent);
                    break;
            }
        }

        private void ScheduleMonthlyEvent(DataEntity.ScheduledEvent monthlyEvent)
        {
            DataEntity.ScheduledEventMonthlyDetails? monthlyEventFound = _unitOfWork.ScheduledEventMonthlyDetails.FindByScheduledEventId(monthlyEvent.Id);

            if (monthlyEventFound is null)
                return;

            if (DateTime.Today.Day.Equals(monthlyEventFound.ExecutionDay))
                _todayEvents.Add(monthlyEvent);
        }

        private void ScheduleYearlyEvent(DataEntity.ScheduledEvent yearlyEvent)
        {
            DataEntity.ScheduledEventYearlyDetails? yearlyEventFound = _unitOfWork.ScheduledEventYearlyDetails.FindByScheduledEventId(yearlyEvent.Id);

            if (yearlyEventFound is null)
                return;

            if (DateTime.Today.Equals(yearlyEventFound.ExecutionDate))
                _todayEvents.Add(yearlyEvent);
        }

        #endregion
    }
}
