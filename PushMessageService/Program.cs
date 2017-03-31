using System;
using System.Collections.Generic;
using System.ServiceProcess;
using System.Text;

namespace PushMessageService
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            string command = "1";
            if (!string.IsNullOrEmpty(System.Configuration.ConfigurationManager.AppSettings["IsWindowsService"]))
            {
                command = System.Configuration.ConfigurationManager.AppSettings["IsWindowsService"];
            }
            if (command.Trim() == "0")
            {
                PushMessageManagement pushManager = PushMessageManagement.GetManagment();
                Console.WriteLine("服务器正在初始化.......");
                pushManager.Init();
                Console.WriteLine("服务器已启动");
                Run();
            }
            else
            {
                try
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[] { new PushService() };
                    ServiceBase.Run(ServicesToRun);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private static void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine().ToLower();
                if(string.Equals("exit", cmd))
                {
                    break;
                }
            }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //LogTool.LogWriter.WriteError("未捕获异常。", (Exception)e.ExceptionObject);
        }
    }
}
