using System;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using DesktopNotifications;
using DesktopNotifications.FreeDesktop;
using DesktopNotifications.Windows;
using TaskOverflow.Models.Notification;
using Tmds.DBus;

namespace TaskOverflow.Models.SystemAlert;

public class AlertHandler
{
    private INotificationManager _manager;
    private static INotificationManager CreateManager()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return new FreeDesktopNotificationManager();
        }

        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return new WindowsNotificationManager();
        }
        
        throw new PlatformNotSupportedException();
    }

    public AlertHandler()
    {
        _manager = CreateManager();
    }

    public async void initHandler()
    {
        await _manager.Initialize();
        _manager.NotificationActivated += ManagerOnNotificationActivated;
        _manager.NotificationDismissed += ManagerOnNotificationDismissed;

    }

    public async void showAlert(TaskOverflow.Models.Notification.Notification notification)
    {
        await _manager.ShowNotification(new DesktopNotifications.Notification
        {
            Title = notification.title,
            Body = notification.description
        });
    }
    
    
    
    private void ManagerOnNotificationDismissed(object? sender, NotificationDismissedEventArgs e)
    {
        Console.WriteLine($"Notification dismissed: {e.Reason}");
        System.Diagnostics.Debug.WriteLine($"Notification dismissed: {e.Reason}");
    }

    private void ManagerOnNotificationActivated(object? sender, NotificationActivatedEventArgs e)
    {
        Console.WriteLine($"Notification activated: {e.ActionId}");
        System.Diagnostics.Debug.WriteLine($"Notification activated: {e.ActionId}");
    }
}