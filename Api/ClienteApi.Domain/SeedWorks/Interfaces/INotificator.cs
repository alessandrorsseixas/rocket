using ClienteApi.Domain.SeedWorks.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClienteApi.Domain.SeedWorks.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
