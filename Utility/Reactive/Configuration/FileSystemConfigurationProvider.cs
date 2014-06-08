using System;
using System.IO;
using Utility.Logging;
using Utility.Reactive.IO;
using Utility.Serialization;

namespace Utility.Reactive.Configuration
{
    public class FileSystemConfigurationProvider
    {
        private readonly ISerializationService _serializationService;
        private readonly ILogger _logger;
        private readonly string _directory;

        public FileSystemConfigurationProvider(
            ISerializationService serializationService,
            ILogFactory logFactory,
            string directory)
        {
            _serializationService = serializationService;
            _logger = logFactory.GetLogger<FileSystemConfigurationProvider>();
            _directory = directory;
        }

        private T DeserializeFile<T>(string filepath, Type type) where T : class, IConfiguration
        {
            try
            {
                return _serializationService.DeserializeFromFile<T>(filepath);
            }
            catch (Exception ex)
            {
                _logger.Error(
                    string.Format("Unable to deserialize file '{0}' to an instance of '{1}' and cast to '{2}'.",
                        filepath,
                        type.FullName,
                        typeof(T).FullName),
                    ex);
            }

            return null;
        }

        private string GetFilePath<T>(string name)
        {
            return Path.Combine(_directory, string.Format("{0}-{1}.xml", typeof(T).FullName, name));
        }

        private void Save<T>(T instance, string name) where T : class, IConfiguration
        {
            var filepath = GetFilePath<T>(name);

            try
            {
                _serializationService.SerializeToFile(instance, filepath);
            }
            catch (Exception ex)
            {
                _logger.Error(
                    string.Format("Unable to serialize config of type '{0}' to file '{1}'.", typeof(T).FullName, filepath),
                    ex);
            }
        }
    }
    /*
    public class FileSystemConfigProvider : DisposableBase, IConfigProvider
    {
        private readonly ConcurrentDictionary<string, BehaviorSubject<IConfig>> _cachedConfigs;
        private readonly ILogger _log;
        private readonly string _directory;

        public FileSystemConfigProvider(IFileSystemWatcherService fileSystemWatcherService, ILogFactory logFactory, string directory)
        {
            _directory = directory;
            _cachedConfigs = new ConcurrentDictionary<string, BehaviorSubject<IConfig>>();
            _log = logFactory.GetLogger<FileSystemConfigProvider>();

            // stream messages are raised on the thread pool by default
            fileSystemWatcherService.FileChanged.Subscribe(
                    filepath =>
                    {
                        BehaviorSubject<IConfig> config;

                        if (_cachedConfigs.TryGetValue(filepath, out config))
                        {
                            var current = config.Value;
                            var newConfig = DeserializeFile<IConfig>(filepath, current.GetType());

                            if (newConfig == null)
                            {
                                _log.WarnFormat("Changes to config file '{0}' ignored.", filepath);
                                return;
                            }

                            config.OnNext(newConfig);
                            _log.InfoFormat("Changes to config file '{0}' read and pushed to subscribers.", filepath);

                            DisposeNow(current);
                        }
                    })
                .DisposeWith(this);
        }

        public T Get<T>(string name = null) where T : class, IConfig
        {
            return GetBehaviorSubject<T>(name).Value as T;
        }

        public IObservable<T> GetStream<T>(string name = null) where T : class, IConfig
        {
            return GetBehaviorSubject<T>(name).Cast<T>().AsObservable();
        }

        private BehaviorSubject<IConfig> GetBehaviorSubject<T>(string name = null) where T : class, IConfig
        {
            var filepath = GetFilePath<T>(name);

            return _cachedConfigs.GetOrAdd(filepath,
                key =>
                {
                    T config = null;
                    var type = typeof(T);

                    if (File.Exists(key))
                    {
                        config = DeserializeFile<T>(key, type);
                    }

                    if (config == null)
                    {
                        _log.InfoFormat("Creating new instance of '{0}'.", type.FullName);

                        config = Activator.CreateInstance<T>();
                        Save(config, name);
                    }

                    config.SaveRequested.Subscribe(_ => Save(config, name)).DisposeWith(this);
                    config.DisposeWith(this);

                    var subject = new BehaviorSubject<IConfig>(config);
                    subject.DisposeWith(this);

                    return subject;
                });
        }


    }
    */
}
