using Microsoft.Extensions.DependencyInjection;
using Vrnz2.Scheduler.Data.Repositories;

namespace Vrnz2.Scheduler.Data
{
    public class UnitOfWork
    {
        #region Variables

        private static readonly Lazy<UnitOfWork> _instance = new(() => new UnitOfWork());

        private readonly ServiceProvider _serviceProvider;

        #endregion

        #region Constructors

        private UnitOfWork()
        {
            _serviceProvider = new ServiceCollection()
                                .AddSingleton<ScheduledEventRepository>()
                                .AddSingleton<ScheduledEventWeeklyDetailsRepository>()
                                .AddSingleton<ScheduledEventMonthlyDetailsRepository>()
                                .AddSingleton<ScheduledEventYearlyDetailsRepository>()
                                    .BuildServiceProvider();

            ScheduledEvent = _serviceProvider.GetService<ScheduledEventRepository>() ?? throw new NullReferenceException();
            ScheduledEventWeeklyDetails = _serviceProvider.GetService<ScheduledEventWeeklyDetailsRepository>() ?? throw new NullReferenceException();
            ScheduledEventMonthlyDetails = _serviceProvider.GetService<ScheduledEventMonthlyDetailsRepository>() ?? throw new NullReferenceException();
            ScheduledEventYearlyDetails = _serviceProvider.GetService<ScheduledEventYearlyDetailsRepository>() ?? throw new NullReferenceException();
        }

        #endregion

        #region Attributes

        public static UnitOfWork Instance => _instance.Value;

        public ScheduledEventRepository ScheduledEvent { get; }
        public ScheduledEventWeeklyDetailsRepository ScheduledEventWeeklyDetails { get; }
        public ScheduledEventMonthlyDetailsRepository ScheduledEventMonthlyDetails { get; }
        public ScheduledEventYearlyDetailsRepository ScheduledEventYearlyDetails { get; }

        #endregion
    }
}