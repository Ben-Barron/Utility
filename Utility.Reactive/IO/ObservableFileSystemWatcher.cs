using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Reactive.IO
{
    /*
     * NOTE: Uses FileSystemWatcher which is known to have issues:
     * - if too many events to fire at once (eg if you create 1000s of files at once) it can
     *   causes a buffer overflow. Possible solution would be to poll the file system every
     *   x seconds looking for changes (or possibly only do this on FileSystemWatcher.Error)
     * - the LastWriteTime attribute not changing (which is possible) would be filtered out
     *   in the where clause. Possible solution could be to MD5 Hash the contents of the file
     *   but this will burn alot of cpu if there are frequent changes.
     */
    public class ObservableFileSystemWatcher : IObservableFileSystemWatcher
    {
    }
}
