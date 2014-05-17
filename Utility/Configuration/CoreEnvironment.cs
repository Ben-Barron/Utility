using System;
using System.IO;

namespace Utility.Configuration
{
    public class CoreEnvironment : ICoreEnvironment
    {
        public readonly string _appDataPath;

        public CoreEnvironment(string applicationName)
        {
            _appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), applicationName);
        }

        public string AppDataFolder { get; set; }

        public string GetAppDataFolderPath(string folder)
        {
            return string.IsNullOrWhiteSpace(AppDataFolder)
                ? Path.Combine(_appDataPath, folder)
                : Path.Combine(_appDataPath, AppDataFolder, folder);
        }
    }
}
