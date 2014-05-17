
namespace Utility.Configuration
{
    public interface ICoreEnvironment
    {
        string AppDataFolder { get; }

        string GetAppDataFolderPath(string folder);
    }
}
