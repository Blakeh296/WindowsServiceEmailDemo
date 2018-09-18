using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using WindowServiceDemo;
using  WindowServiceDemo.Properties;
using System.Web; 

namespace WindowServiceDemo
{
    partial class NotificationService : ServiceBase
    {
        //Creates a text file for errors and status messages. 
        StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
        //Queue to store email messages before sending , incase there is no internet on,
        //Program start up
        Queue<MailMessage> notificationMessage = new Queue<MailMessage>();
        //Create the DirectoryMonitor Class & feed it The directory path to monitor
        //Can easily be changed in Project -> Project Property -> settings

        public NotificationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            LoadDirectories();

            //Log actions to TxtFile
            LogAction(new string[] { DateTime.Now.ToString() + " Window Service Started." });
            SendStartupTxt();
        }

        protected override void OnStop()
        {    
            // TODO: Add code here to perform any tear-down necessary to stop your service.

            // COMMENTED OUT WORKING CODE sw.WriteLine("Program  Ended: " + DateTime.Now.ToString());
            SendStartupTxt();
            //Log actions to TxtFile
            LogAction(new string[] { DateTime.Now.ToString() + " Window Service Stopped." });
            
            // Program is over End Stream writer
            sw.Close();
        }
        
        public void SendStartupTxt()
        {
            //Create a new e-mail stating that the system has been started
            //and add it to the message Queue
            string recipient = Settings.Default.PhoneNumber + Settings.Default.serverVZ;
            MailMessage msg = new MailMessage(Settings.Default.fromEmail, recipient);

            SmtpClient smtpClient = new SmtpClient(Settings.Default.server, 587);
            NetworkCredential emailCredentials = new NetworkCredential(Settings.Default.fromEmail, Settings.Default.password);
            MailMessage currentMsg;

            try
            {
                msg.Body = "Windows Service Testing";
                //Add the email to the Queue
                notificationMessage.Enqueue(msg);

                smtpClient.EnableSsl = true;
                smtpClient.Credentials = emailCredentials;
                //Do not dequeue the message untill it is successfully sent.
                currentMsg = notificationMessage.Peek();
                smtpClient.Send(currentMsg);
                currentMsg = notificationMessage.Dequeue();
                //Log success
                LogAction(new string[] { DateTime.Now.ToString() + " Text sent successfully." });
            }
            catch (Exception ex)
            {
                //Log any errors
                LogAction(new string[] { DateTime.Now.ToString(), ex.Message });
            }
        }

        private void LogAction(string[] message)
        {
            try
            {
                //swErrorWrite.WriteLine(message);
                foreach (string msgLine in message)
                {
                    //Write to system log.
                    sw.WriteLine(msgLine);
                }
            }
            catch (Exception ex)
            {
                //Just dispose of it for now
                Console.WriteLine(ex.Message);
            }
        }
        //GET RID OF THIS
        internal void TestStartandStop(string[] args)
        {
            //if started from Visual Studio, run through the events.
            this.OnStart(args);

            while (timer.Enabled)
            {
                Console.ReadLine();
            }

            this.OnStop();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString(), ex.Message });
            }
        }

        private void LoadDirectories()
        {
            //Load all the directories from the CSV File
            //Initialize the StreamReader with the 'Stream to be read' which is the "File Name"
            StreamReader directories = new StreamReader("Directories.csv");
            // Create the Watcher object from our custom class
            FileSystemWatcherExtClass watcherClass;
            // 3 string variables
            string currentLine, dirSource = "", dirDestination = "";
            bool directoryActive = false, validLine = false, dirIncludeSubdirs = false;
            string[] lineParse;

            try
            {
                while (!directories.EndOfStream) //While the StreamReader is not @ End of Stream
                {
                    //Read the next line
                    currentLine = directories.ReadLine();
                    //Set Bool to false
                    validLine = false;

                    //Does the Line being Currently Read start with "#"?
                    if (currentLine.StartsWith("#"))
                    {
                        // Delimit current line with (0, 1) Starting from the left and removing the # 
                        lineParse = currentLine.Remove(0, 1).Split(',');
                        //Make sure there are four fields in the lines accrossed
                        if(lineParse.Length == 4)
                        {
                            //If the if statement Evaluates True
                            //if Directory is active if != 0
                            directoryActive = (lineParse[3].Trim() != "0");

                            //If directory Active == True
                            if (directoryActive)
                            {
                                //Grab source and destination Directories
                                validLine = true;
                                //Trime off quotation marks from Source Path
                                dirSource = lineParse[0].Trim().Trim('"');
                                //Grab Destination directory, next to Source Directory
                                dirDestination = lineParse[1].Trim().Trim('"');
                                //Set Boolean true if Path is active
                                dirIncludeSubdirs = (lineParse[2].Trim() != "0");
                            }
                        }
                    }

                    //If the line was valid, create a new FileWatcher and add it to the list
                    if (validLine)
                    {
                        watcherClass = GenerateFileWatcher(dirSource, dirIncludeSubdirs, dirDestination);

                        if (watcherClass != null)
                        {
                            watcherClass.EnableRaisingEvents = true;
                            watcherClass.Changed += fileSystemWatcher_Changed;
                            watcherClass.Created += fileSystemWatcher_Created;
                            watcherClass.Deleted += fileSystemWatcher_Deleted;
                            watcherClass.Renamed += fileSystemWatcher_Renamed;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString() + ex.Message });
            }
        }

        private FileSystemWatcherExtClass GenerateFileWatcher(string FileSource, bool IncludeSubDirs, string Destination)
        {
            FileSystemWatcherExtClass fwExt = new FileSystemWatcherExtClass(Destination);
            string filePath = "";
            int charPlace;

            try
            {
                if(Directory.Exists(FileSource))
                {
                    filePath = FileSource;
                }
                else
                {
                    //Char Place stores where the Directories end and the File name 
                    charPlace = FileSource.LastIndexOf(@"\");
                    filePath = FileSource.Substring(0);

                    if (Directory.Exists(filePath))
                    {
                        //FileSystemWatcherExtClass == FilePath
                        fwExt.Path = filePath;
                        fwExt.Filter = FileSource.Substring(charPlace + 1);
                    }
                }

                fwExt.IncludeSubdirectories = IncludeSubDirs;
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString() + "Error creating FileWatcher on "
                + FileSource + ". " + ex.Message});
            }

            //If the path was valid, return the file watcher
            if (fwExt.Path.Length > 0)
            {
                return fwExt;
            }
            else
                //Otherwise, return null
                return null;
        }

        public class FileSystemWatcherExtClass : System.IO.FileSystemWatcher
        {
            private string _destDirectroy;

            public string DestinationDirectory
            {
                //Stores Destination Directory for file changes
                get { return _destDirectroy; }
                set { _destDirectroy = value; }
            }

            public FileSystemWatcherExtClass(string DestinationDirectory)
            {
                //Constructor to initialize _destDirectory Data member
                _destDirectroy = DestinationDirectory;
            }
        }

        private void CopyChangedFile(FileSystemWatcherExtClass FileWatcher, string SourceFilePath)
        {
            string destinationPath = "";

            try
            {
                //Get the destination path
                destinationPath = SourceFilePath.Replace(FileWatcher.Path, FileWatcher.DestinationDirectory)
                    .Replace("\\\\", "\\");

                //If it douesnt exist already, create it
                if (!Directory.Exists(Directory.GetParent(destinationPath).ToString()))
                    Directory.CreateDirectory(destinationPath);

                //If the directory does exist, create the corresponding Directory
                //Otherwise just copy the file
                if (Directory.Exists(SourceFilePath))
                    Directory.CreateDirectory(destinationPath);
                else
                    File.Copy(SourceFilePath, destinationPath, true);
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString() + " Error copying file from " + SourceFilePath + " to " +
                    destinationPath + ". " + ex.Message});
            }
        }

        private void RenameBackupFile(FileSystemWatcherExtClass FileWatcher, string oldFile, string newFile)
        {
            string originPath = "", newPath = "";

            try
            {
                //Get the full path of the original file
                originPath = oldFile.Replace(FileWatcher.Path, FileWatcher.DestinationDirectory)
                    .Replace("\\\\", "\\");

                newPath = newFile.Replace(FileWatcher.Path, FileWatcher.DestinationDirectory)
                    .Replace("\\\\", "\\");

                //If its a directory, rename it
                if (Directory.Exists(originPath))
                                                         Directory.Move(originPath, newPath);
                else
                                                         File.Move(originPath, newPath);
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString() + " Error copying file from " + originPath + " to "
                + newPath + ".", ex.Message});
            }
        }

        private void DeleteFile(FileSystemWatcherExtClass FileWatcher, string sourceFilePath)
        {
            string destinationPath;
            try
            {
                //Get the destination path
                destinationPath = sourceFilePath.Replace(FileWatcher.Path, FileWatcher.DestinationDirectory)
                    .Replace("\\\\", "\\");

                //If the file or directory exists, delete it 
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);
                else if (Directory.Exists(destinationPath))
                    Directory.Delete(destinationPath, true);
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString() + " Error Deleting file from " +
                    sourceFilePath + ". " + ex.Message});
            }
        }

        private void fileSystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                //Revert the generic object into a FileSystemWatcher
                FileSystemWatcherExtClass fwExtended = (FileSystemWatcherExtClass)sender;

                //Copy the file
                CopyChangedFile(fwExtended, e.FullPath);

                //Log changes
                LogAction(new string[] { DateTime.Now.ToString() + " File Modified: " + e.Name });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void fileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            //Revert the generic object into a FileSystemWatcher
            FileSystemWatcherExtClass fwExtended = (FileSystemWatcherExtClass)sender;

            //Copy the file
            CopyChangedFile(fwExtended, e.FullPath);

            //Log changes
            LogAction(new string[] { DateTime.Now.ToString() + " File Created: " + e.Name });
        }

        private void fileSystemWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            FileSystemWatcherExtClass fwExtended = (FileSystemWatcherExtClass)sender;
        }

        private void fileSystemWatcher_Renamed(object sender, RenamedEventArgs e)
        {
            FileSystemWatcherExtClass fwExtended = (FileSystemWatcherExtClass)sender;

            RenameBackupFile(fwExtended, e.OldFullPath, e.FullPath);

            LogAction(new string[] { DateTime.Now.ToString() + " File Renamed: " + e.Name });
        }
    }
}
