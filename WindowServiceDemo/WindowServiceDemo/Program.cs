using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowServiceDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            //IF this is being started in Visual Studio, run through the test routine.
            //Otherwise run as a normal service
            if (Environment.UserInteractive)
            {
                NotificationService service = new NotificationService();
                service.TestStartandStop(args);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                new NotificationService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }
    }
}
