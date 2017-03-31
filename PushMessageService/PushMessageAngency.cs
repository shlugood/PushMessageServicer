using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PushMessageService
{
    public class PushMessageAngency : MarshalByRefObject, wxtools.IPushMessageAngency
    {

        private volatile static PushMessageAngency _instance = null;
        private static readonly object lockHelper = new object();

        private PushMessageHelper.PushMessageAngency pushAngency;
        private PushMessageAngency()
        {
            pushAngency = PushMessageHelper.PushMessageAngency.CreateInstance();
        }
        public static PushMessageAngency CreateInstance()
        {
            if (_instance == null)
            {
                lock (lockHelper)
                {
                    if (_instance == null)
                        _instance = new PushMessageAngency();
                }
            }
            return _instance;
        }

        public string Notification2Store(string CustomerID, string Title, string text, string content) 
        {
            return pushAngency.Notification2Store(CustomerID, Title, text,content);
        }

        public string Transmission2Store(string CustomerID, string content)
        {
            return pushAngency.Transmission2Store(CustomerID,  content);
        }
    }
}
