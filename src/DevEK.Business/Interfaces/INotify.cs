using System;
using System.Collections.Generic;
using DevEK.Business.Notifications;

namespace DevEK.Business.Interfaces
{
    public interface INotify
    {
        bool ThereIsNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);

    }
}
