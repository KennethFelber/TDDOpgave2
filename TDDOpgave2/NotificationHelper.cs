using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TDDOpgave2
{
    public class NotificationHelper : INotificationHelper
    {
        public void Notify(string message)
        {
            Trace.WriteLine(message);
        }
    }
}
