using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowServiceDemo
{
    class DirectoryMonitor
    {
        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

        //Some info can be found at
        //https://www.infoworld.com/article/3185447/c-sharp/how-to-work-with-filesystemwatcher-in-c.html

        public DirectoryMonitor(string dirpath)
        {
            fileSystemWatcher.Path = dirpath;
        }

        public void Watch()
        {
            fileSystemWatcher.Created += fileSystemWatcher_Created;
            fileSystemWatcher.Renamed += fileSystemWatcher_Renamed;
            fileSystemWatcher.Deleted += fileSystemWatcher_Deleted;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        
    }
}
