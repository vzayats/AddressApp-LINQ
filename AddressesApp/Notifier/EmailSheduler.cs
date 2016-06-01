using Quartz;
using Quartz.Impl;

namespace AddressesApp.Notifier
{
    public class EmailSheduler
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<BirthdayNotifier>().Build();

            //Запускаємо кожного дня о 10.00 год
            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(24)
                    .OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(10, 00)) 
                  )
                .Build();

            //початок виконання роботи
            scheduler.ScheduleJob(job, trigger); 
        }
    }
}
