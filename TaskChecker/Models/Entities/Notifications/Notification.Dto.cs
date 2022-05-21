using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskChecker.Models
{
    public class NotificationDto
    {
        public int Id;
        public User Reaciever;
        public string Title;
        public string Text;
        public string Link;
        public NotificationType Type;
        public bool Read;
    }
}
