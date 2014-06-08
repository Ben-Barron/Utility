using System;
using System.Reactive;
using System.Reactive.Subjects;
using Utility.Reactive.Extensions;

namespace Utility.Reactive.Configuration
{
    public abstract class Configuration : DisposablesHandler, IConfiguration
    {
        private readonly Subject<Unit> _saveConfig;

        public Configuration()
        {
            _saveConfig = new Subject<Unit>();
            _saveConfig.DisposeWith(this);
        }

        public IObservable<Unit> SaveRequested
        {
            get { return _saveConfig; }
        }

        public void Save()
        {
            _saveConfig.OnNext(Unit.Default);
        }
    }
}
