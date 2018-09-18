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
        DirectoryMonitor monitor = new DirectoryMonitor(@"C:\Users\Cyberadmin\Desktop\TestingArea");

        public NotificationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        { 
            // COMMENTED OUT WORKING CODE sw.WriteLine("Program Started: " + DateTime.Now.ToString());

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
                monitor.Watch();
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
                                dirDestination = lineParse[1].Trim().('"');
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
