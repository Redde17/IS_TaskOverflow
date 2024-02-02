using System.Transactions;
using TaskOverflow.Models.TaskManagement;

namespace TaskOverflow.Models.Notification;

public class TaskNotification : Notification
{
    private Task _referredTask {get; set;}

    public TaskNotification(int id, string title, string description, Task task) : base(id, title, description)
    {
        _referredTask = task;
    }

    public Task getReferredTask()
    {
        return _referredTask;
    }

    public void setReferredTask(Task task)
    {
        _referredTask = task;
    }
    
}