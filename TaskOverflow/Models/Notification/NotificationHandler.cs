using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskOverflow.Models.SystemAlert;

namespace TaskOverflow.Models.Notification;

public class NotificationHandler
{
    public ObservableCollection<Notification> showableNotifications { get; set; } //Questa è una coda (push in coda, pop a [0]) in cui mettere le notifiche che saranno mostrate come pop-up
    private Collection<TaskNotification> _tasksBeingChecked { get; set; } //Questa Collection contiene le task che devono ancora scadere e su cui quindi dover effettuare il controllo della scadenza

    public NotificationHandler(AlertHandler alertHandler) //builder
    {
        showableNotifications = new ObservableCollection<Notification>();
        _tasksBeingChecked = new Collection<TaskNotification>();
        
        initNotification(alertHandler);
    }

    public async void initNotification(AlertHandler alertHandler)
    {
        
        showableNotifications.CollectionChanged += (sender, e) =>
        {
            Console.WriteLine($"{e.Action}");
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                alertHandler.showAlert(showableNotifications[0]);
            }
        };
        
        await CheckExpiringTasks();
    }

    public void pushNotification(Notification notification)
    {
        if (notification.GetType() == typeof(TaskNotification))
        {
            _tasksBeingChecked.Add((TaskNotification)notification);
            orderTasksByDate();
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

        if (showableNotifications.Any())
        {
            poppedNotification = showableNotifications[0];
            showableNotifications.RemoveAt(0);
            return poppedNotification;
        }
        else
        {
            throw new InvalidOperationException("Non sono presenti notifiche in coda.");
        }
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
            if (_tasksBeingChecked.Any())
            {
                TaskManagement.Task referredTask = _tasksBeingChecked[0].getReferredTask();
                Console.WriteLine("Tic tac");
                if ((referredTask.date.Date == DateTime.Now.Date) && (referredTask.date.Hour == DateTime.Now.Hour) && (referredTask.date.Minute == DateTime.Now.Minute))
                {
                    showableNotifications.Add(_tasksBeingChecked[0]);
                    _tasksBeingChecked.RemoveAt(0);
                }
            }
        }
    }
    
     public void orderTasksByDate() //letteralmente TasksHandler.ascSort() solo per le date
            {
                int i, j;
                for (i = 0; i < _tasksBeingChecked.Count - 1; i++) 
                {
                        int min = i;
                        for (j = i + 1; j < _tasksBeingChecked.Count; j++)
                        {
                            if (_tasksBeingChecked[j].getReferredTask().date < _tasksBeingChecked[min].getReferredTask().date)
                            {
                                min = j;
                                break;
                            }
                        }
                        if (min != i)
                        {
                            TaskNotification temp = _tasksBeingChecked[min];
                            _tasksBeingChecked[i] = _tasksBeingChecked[min];
                            _tasksBeingChecked[min] = temp;
                        }
                }
            }
    
}