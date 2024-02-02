using System;

namespace TaskOverflow.Models.Notification;

public class SystemNotification : Notification
{
    public enum NotificationType
    {   Error,
        Alert,
        Confirm
    }

    public DateTime date { get; set; }

    public NotificationType type { get; set; }
    
    public SystemNotification(int id, string title, string description, NotificationType type) : base(id, title, description)
    {
        this.date = date;
        this.type = type;
    }
    
}