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

namespace WindowServiceDemo
{
    partial class NotificationService : ServiceBase
    {
        //Creates a text file for errors and status messages. 
        //This will probably be in C:\Windows\SYSWOW64.
        StreamWriter swErrorWrite = new StreamWriter(Settings.Default.LogLocation, true);
        //Queue to store email messages before sending , incase there is no internet on,
        //Computer start up
        Queue<MailMessage> notificationMessage = new Queue<MailMessage>();

        public NotificationService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SendStartupEmail();
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
            SendStartupEmail();
        }

        public void SendStartupEmail()
        {
            //Create a new e-mail stating that the system has been started
            //and add it to the message Queue

            MailMessage msg = new MailMessage();

            try
            {
                //set MailMessage From: Project -> <WindowsServiceDemo> properties -> settings
                msg.From = new MailAddress(Settings.Default.fromEmail);
                //Set who the email is going to from the Project -> <WindowsServiceDemo> properties -> settings
                msg.To.Add(Settings.Default.toEmail);
                //Give the email a subject
                msg.Subject = "Windows Service Demo Notify Mail";
                //Give the email a body
                msg.Body = "The system was started at " + DateTime.Now.ToString();
                //Add the email to the Queue
                notificationMessage.Enqueue(msg);
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
                foreach (string msgLine in message)
                {
                    //Write to system log.
                    swErrorWrite.WriteLine(msgLine);
                }
            }
            catch (Exception ex)
            {
                //Just dispose of it for now
                Console.WriteLine(ex.Message);
            }
        }

        internal void TestStartandStop(string[] args)
        {
            //if started from Visual Studio, run through the events.
            this.OnStart(args);

            //Let the timer event play
            while (serverTimer.Enabled)
            {
                Console.ReadLine();
            }

            this.OnStop();
        }


        private void serverTimer_Tick(object sender, EventArgs e)
        {
            //Create a new SMTP client from the application settings, log in and
            //send whatever mails have been enqueued.
            //BE SURE TO ENTER THE CORRECT SETTINGS IN THE APPLICATION SETTINGS FILE

            SmtpClient smtpClient = new SmtpClient(Settings.Default.server, 587);
            NetworkCredential emailCredentials = new NetworkCredential(Settings.Default.fromEmail, Settings.Default.password);
            MailMessage currentMsg;

            try
            {
                if (notificationMessage.Count > 0)
                {
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = emailCredentials;
                    //Do not dequeue the message untill it is successfully sent.
                    currentMsg = notificationMessage.Peek();
                    smtpClient.Send(currentMsg);
                    currentMsg = notificationMessage.Dequeue();
                    //Log success
                    LogAction(new string[] { DateTime.Now.ToString(), "Email was sent successfully" });
                }
            }
            catch (Exception ex)
            {
                LogAction(new string[] { DateTime.Now.ToString(), ex.Message });
            }
        }
    }
}
