using System;
using System.Collections.Generic;
using System.Linq;
using DevEK.Business.Interfaces;

namespace DevEK.Business.Notifications
{
    public class Notify : INotify
    {
        private List<Notification> _notifications;

        public Notify()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public List<Notification> GetNotifications()
        {
            return  _notifications;
        }

        public bool ThereIsNotification()
        {
            return _notifications.Any();
        }
      
    }
}
