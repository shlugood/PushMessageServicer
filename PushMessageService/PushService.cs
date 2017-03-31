using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace PushMessageService
{
    partial class PushService : ServiceBase
    {
        public PushService()
        {
            InitializeComponent();
            CanPauseAndContinue = false;
        }

        protected override void OnStart(string[] args)
        {
            PushMessageManagement.GetManagment().Init();
            Console.WriteLine("服务器已启动");
        }

        protected override void OnStop()
        {
            PushMessageManagement.GetManagment().Stop();
        }
    }
}
