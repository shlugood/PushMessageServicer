using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;

namespace PushMessageService
{
    public class PushMessageManagement
    {
        private static PushMessageManagement managment;
        public static PushMessageManagement GetManagment()
        {
            if (managment == null)
                managment = new PushMessageManagement();
            return managment;
        }
        private PushMessageManagement() { }

        public void Init()
        {
            RegisteRemoting();
        }

        public void RegisteRemoting()
        {
            TcpServerChannel channel = new TcpServerChannel(10397);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(PushMessageAngency), "PushMessageService", WellKnownObjectMode.SingleCall);
        }

        public void Stop()
        {

        }
    }
}
