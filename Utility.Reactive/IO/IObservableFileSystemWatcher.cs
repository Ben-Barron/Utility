using System;
using System.IO;

namespace Utility.Reactive.IO
{
    public interface IObservableFileSystemWatcher
    {
        IObservable<FileSystemEventArgs> Changed { get; }
        IObservable<FileSystemEventArgs> Created { get; }
        IObservable<FileSystemEventArgs> Deleted { get; }
        IObservable<ErrorEventArgs> Errors { get; }
        IObservable<RenamedEventArgs> Renamed { get; }
        bool IsWatching { get; }

        void Start();
        void Stop();
    }
}
