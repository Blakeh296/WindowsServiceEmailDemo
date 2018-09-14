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
using  WindowServiceDemo.Properties;
using System.Web;

namespace WindowServiceDemo
{
    partial class NotificationService : ServiceBase
    {
        //Creates a text file for errors and status messages. 
        //This will probably be in C:\Windows\SYSWOW64.
        StreamWriter sw = new StreamWriter(@"G:\C#\WindowsServiceEmailDemo\WindowServiceDemo\\NotifyServiceLog.txt", true);
        //Queue to store email messages before sending , incase there is no internet on,
        //Computer start up
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
    }
}
