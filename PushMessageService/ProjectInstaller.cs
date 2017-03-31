using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;

namespace PushMessageService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            this.serviceInstaller1.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.serviceProcessInstaller1.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceInstaller1.Description = "推送消息服务。";
            this.serviceInstaller1.DisplayName = "PushMessageService";
        }


        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
