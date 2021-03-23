using System;
using System.Collections.Generic;
using System.Text;

namespace TDDOpgave2.Test.Fakes
{
    public class NotificationHelperFake : INotificationHelper
    {
        public string NotificationMessage { get; set; }

        public void Notify(string message)
        {
            NotificationMessage = message;
        }
    }
}
