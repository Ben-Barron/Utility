
namespace Utility.Logging
{
    public interface ILogFactory
    {
        ILogger GetLogger<T>();
    }
}
