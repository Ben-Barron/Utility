using System.Reactive.Concurrency;

namespace Utility.Reactive.Schedulers
{
    public class SchedulerService : ISchedulerService
    {
        public SchedulerService()
        {
            Async = TaskPoolScheduler.Default;
            Immediate = ImmediateScheduler.Instance;
            LongRunning = NewThreadScheduler.Default;
            Ui = DispatcherScheduler.Current;
        }

        public IScheduler Async { get; private set; }
        public IScheduler Immediate { get; private set; }
        public IScheduler LongRunning { get; private set; }
        public IScheduler Ui { get; private set; }
    }
}
