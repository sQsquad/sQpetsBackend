using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sQpets_Backend.Notifications
{
    public class Notification
    {
        public Notification(string message, string property)
        {
            Message = message;
            Property = property;
        }

        public string Message { get; private set; }
        public string Property { get; private set; }
    }
}