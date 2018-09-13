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
        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();

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

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Modified: " + e.Name + " " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Created: " + e.Name + " " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Deleted: " + e.Name + " " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File renamed" + e.Name + " " + DateTime.Now.ToString());
            sw.Close();
        }
    }
}
