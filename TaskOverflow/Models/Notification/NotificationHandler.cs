using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TaskOverflow.Models.Notification;

public class NotificationHandler
{
    public ObservableCollection<Notification> showableNotifications { get; set; } //Questa è una coda (push in coda, pop a [0]) in cui mettere le notifiche che saranno mostrate come pop-up
    private Collection<TaskNotification> _tasksBeingChecked { get; set; } //Questa Collection contiene le task che devono ancora scadere e su cui quindi dover effettuare il controllo della scadenza

    public NotificationHandler() //builder
    {
        showableNotifications = new ObservableCollection<Notification>();
        _tasksBeingChecked = new Collection<TaskNotification>();

        CheckExpiringTasks();
    }

    public void pushNotification(Notification notification)
    {
        if (notification.GetType() == typeof(TaskNotification))
        {
            _tasksBeingChecked.Add((TaskNotification)notification);
            _tasksBeingChecked.OrderBy(taskNotification => taskNotification.getReferredTask().date);
            showableNotifications.Add(new SystemNotification(generateID(), "Notifica creata correttamente", "TaskOverflow ti avviserà quando il tuo task sarà in scadenza", SystemNotification.NotificationType.Confirm));
        }
        else
        {
            showableNotifications.Add(notification); //Add aggiunge in coda   
        }
    }
    
    public Notification popNotification()
    {
        Notification poppedNotification; //Salva temporaneamente la notifica in cima

        poppedNotification = showableNotifications[0];
        showableNotifications.RemoveAt(0);
        return poppedNotification;
    }

    public int generateID()
    {
        if (showableNotifications.Any() == false)
        {
            return 0;
        }

        return (showableNotifications[0].id + 1);
    }
    
    
    async Task CheckExpiringTasks()
    {
        var periodicTimer = new PeriodicTimer(TimeSpan.FromSeconds(60));
        while (await periodicTimer.WaitForNextTickAsync())
        {
            TaskManagement.Task referredTask = _tasksBeingChecked[0].getReferredTask();
            if (referredTask.date == DateTime.Now)
            {
                showableNotifications.Add(new TaskNotification(generateID(), referredTask.name, referredTask.description, referredTask));
            }
        }
    }
    
}