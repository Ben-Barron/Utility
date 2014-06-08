using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Utility.Reactive.Extensions;

namespace Utility.Reactive.Subjects
{
    public class MergedStreamSubjectFactory<T> : DisposablesHandler, IMergedStreamSubjectFactory<T>
    {
        private readonly Subject<Subject<T>> _streams;

        public MergedStreamSubjectFactory()
        {
            _streams = new Subject<Subject<T>>();
            _streams.DisposeWith(this);

            MergedStream = _streams.Merge();
        }

        public IObservable<T> MergedStream { get; private set; }

        public Subject<T> GetNewSubject()
        {
            var subject = new Subject<T>();
            _streams.OnNext(subject);

            return subject;
        }
    }
}
