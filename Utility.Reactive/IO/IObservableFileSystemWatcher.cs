using System;
using System.IO;

namespace Utility.Reactive.IO
{
    public interface IObservableFileSystemWatcher
    {
        IObservable<FileSystemEventArgs> Changed { get; }
        IObservable<RenamedEventArgs> Renamed { get; }
        IObservable<FileSystemEventArgs> Deleted { get; }
        IObservable<ErrorEventArgs> Errors { get; }
        IObservable<FileSystemEventArgs> Created { get; }

        void Start();
        void Stop();
    }
}
