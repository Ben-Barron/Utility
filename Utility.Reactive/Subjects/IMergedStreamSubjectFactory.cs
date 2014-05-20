using System;
using System.Reactive.Subjects;

namespace Utility.Reactive.Subjects
{
    public interface IMergedStreamSubjectFactory<T>
    {
        IObservable<T> MergedStream { get; }

        Subject<T> GetNewSubject();
    }
}
