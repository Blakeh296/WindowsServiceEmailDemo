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
        private string dirPath;

        public DirectoryMonitor(string dirpath)
        {
            FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
            fileSystemWatcher.Path = dirpath;
            fileSystemWatcher.EnableRaisingEvents = true;
        }

        private static void DirectoryMonitored_Created(object sender, FileSystemEventArgs e)
        {

        }

        private static void DirectoryMonitored_Renamed(object sender, FileSystemEventArgs e)
        {

        }

        private static void DirectoryMonitored_Deleted(object sender, FileSystemEventArgs e)
        {

        }
    }
}
