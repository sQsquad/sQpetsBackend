using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sQpets_Backend.Notifications;
using sQpets_Backend.Validations;

namespace sQpets_Backend.Models
{
    public class BaseEntity
    {
        List<Notification> _notifications;
        public BaseEntity()
        {
            this._notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}