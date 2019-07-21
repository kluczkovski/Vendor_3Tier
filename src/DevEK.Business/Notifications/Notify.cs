using System;
using System.Collections.Generic;
using DevEK.Business.Interfaces;

namespace DevEK.Business.Notification
{
    public class Notify : INotify
    {
        private List<Notification> _notifications;

        public Notify()
        {
        }

        public System.Collections.Generic.List<Notification> GetNotifications()
        {
            throw new NotImplementedException();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public bool ThereIsNotification()
        {
            throw new NotImplementedException();
        }

        List<Business.Notification> INotify.GetNotifications()
        {
            throw new NotImplementedException();
        }
    }
}
