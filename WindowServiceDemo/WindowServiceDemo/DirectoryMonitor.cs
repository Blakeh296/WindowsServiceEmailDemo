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

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Modified: " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Created: " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File Deleted: " + DateTime.Now.ToString());
            sw.Close();
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
            sw.WriteLine("File renamed" + DateTime.Now.ToString());
            sw.Close();
        }
    }
}
