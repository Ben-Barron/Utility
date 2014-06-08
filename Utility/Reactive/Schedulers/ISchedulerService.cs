using System.Reactive.Concurrency;

namespace Utility.Reactive.Schedulers
{
    public interface ISchedulerService
    {
        IScheduler Async { get; }
        IScheduler Immediate { get; }
        IScheduler LongRunning { get; }
        IScheduler Ui { get; }
    }
}
