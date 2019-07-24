using System;
using System.Collections.Generic;

namespace SmartRefrigerator
{
    public class NotificationFactory 
    {
        public static INotificationChannel GetNotificationChannel(string channelName)
        {
            switch(channelName)
            {
                case "email":
                    return new EmailNotification();
                case "mobile":
                    throw new NotImplementedException();
                default:
                    throw new NotSupportedException();
            }
        }

    }
}


