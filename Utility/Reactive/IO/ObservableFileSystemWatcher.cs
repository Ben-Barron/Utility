using System;
using System.IO;
using System.Reactive.Linq;
using Utility.Reactive.Extensions;

namespace Utility.Reactive.IO
{
    /// <remarks>
    /// Uses FileSystemWatcher which is known to have issues:
    /// - if too many events to fire at once (e.g. if you create 1000s of files at once) it can
    ///   causes a buffer overflow. Possible solution would be to poll the file system every
    ///   x seconds looking for changes (or possibly only do this on FileSystemWatcher.Error)
    /// - the LastWriteTime attribute not changing. Possible solution could be to MD5 Hash the
    ///   contents of the file but this will burn alot of cpu if there are frequent changes.
    /// </remarks>
    public class ObservableFileSystemWatcher : DisposablesHandler, IObservableFileSystemWatcher
    {
        private readonly FileSystemWatcher _fileSystemWatcher;

        public ObservableFileSystemWatcher(string path, string filter = null)
        {
            _fileSystemWatcher = string.IsNullOrWhiteSpace(filter)
                ? new FileSystemWatcher(path)
                : new FileSystemWatcher(path, filter);

            Changed = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>
                (h => (s, e) => h(s, e),
                 h => _fileSystemWatcher.Changed += h,
                 h => _fileSystemWatcher.Changed -= h)
                .Select(e => e.EventArgs);

            Created = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>
                (h => (s, e) => h(s, e),
                 h => _fileSystemWatcher.Created += h,
                 h => _fileSystemWatcher.Created -= h)
                .Select(e => e.EventArgs);

            Deleted = Observable.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>
                (h => (s, e) => h(s, e),
                 h => _fileSystemWatcher.Deleted += h,
                 h => _fileSystemWatcher.Deleted -= h)
                .Select(e => e.EventArgs);

            Errors = Observable.FromEventPattern<ErrorEventHandler, ErrorEventArgs>
                (h => (s, e) => h(s, e),
                 h => _fileSystemWatcher.Error += h,
                 h => _fileSystemWatcher.Error -= h)
                .Select(e => e.EventArgs);

            Renamed = Observable.FromEventPattern<RenamedEventHandler, RenamedEventArgs>
                (h => (s, e) => h(s, e),
                 h => _fileSystemWatcher.Renamed += h,
                 h => _fileSystemWatcher.Renamed -= h)
                .Select(e => e.EventArgs);

            _fileSystemWatcher.DisposeWith(this);
        }

        public IObservable<FileSystemEventArgs> Changed { get; private set; }
        public IObservable<FileSystemEventArgs> Created { get; private set; }
        public IObservable<FileSystemEventArgs> Deleted { get; private set; }
        public IObservable<ErrorEventArgs> Errors { get; private set; }
        public IObservable<RenamedEventArgs> Renamed { get; private set; }
        
        public bool IsWatching
        {
            get { return _fileSystemWatcher.EnableRaisingEvents; }
        }

        public void Start()
        {
            _fileSystemWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _fileSystemWatcher.EnableRaisingEvents = false;
        }
    }
}
