using System.Collections.ObjectModel;
using System.Reactive;
using TaskOverflow.Models.Notification;
using TaskOverflow.Models.SystemAlert;
using Notification = TaskOverflow.Models.Notification.Notification;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow_Test.AMV_Testing{
    [TestClass]
    public class UnitTesting
    {
        [TestMethod]
        public void TestCase_PushNotification1()
        {
            //Test Case ID: TC_PN1.1
            //Test frame: IND_T1

            NotificationHandler testHandler = new NotificationHandler(new AlertHandler());
            try
            {
                
                testHandler.pushNotification(new TaskNotification(0, "Test", "Test", new Task()));

                List<TaskNotification> oracletask = new List<TaskNotification>();
                oracletask.Add(new TaskNotification(0, "Test", "Test", new Task()));
                ObservableCollection<Notification> oracleNotifications = new ObservableCollection<Notification>();
                oracleNotifications.Add(new SystemNotification(testHandler.generateID(), "Notifica creata correttamente", "TaskOverflow ti avviserà quando il tuo task sarà in scadenza", SystemNotification.NotificationType.Confirm));

                CollectionAssert.AreEquivalent(oracleNotifications, testHandler.showableNotifications, "Non è stata creata correttamente la notifica di sistema");
                CollectionAssert.AreEquivalent(oracletask, testHandler.getTaskNotificationList(), "La Task non è stata inserita in lista");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
        
        [TestMethod]
        public void TestCase_PushNotification2()
        {
            //Test Case ID: TC_PN1.2
            //Test frame: IND_T2

            NotificationHandler testHandler = new NotificationHandler(new AlertHandler());
            
            try
            {
                testHandler.pushNotification(new SystemNotification(0, "Test", "Test", SystemNotification.NotificationType.Alert));
                List<TaskNotification> oracletask = new List<TaskNotification>();
                ObservableCollection<Notification> oracleNotifications = new ObservableCollection<Notification>();
                oracleNotifications.Add(new SystemNotification(0, "Test", "Test", SystemNotification.NotificationType.Alert));

                CollectionAssert.AreEquivalent(oracletask, testHandler.getTaskNotificationList(), "La lista di notifiche di task non è vuota");
                CollectionAssert.AreEquivalent(oracleNotifications, testHandler.showableNotifications, "Non è stata creata correttamente la notifica");

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            }
        
        [TestMethod]
        public void TestCase_PushNotification3()
        {
            //Test Case ID: TC_PN1.3
            //Test frame: IND_T3

            NotificationHandler testHandler = new NotificationHandler(new AlertHandler());
            testHandler.pushNotification(new Notification(0, "Test", "Test"));

            List<TaskNotification> oracletask = new List<TaskNotification>();
            ObservableCollection<Notification> oracleNotifications = new ObservableCollection<Notification>();
            CollectionAssert.AreEquivalent(oracletask, testHandler.getTaskNotificationList(), "La lista di notifiche di task non è vuota");
            CollectionAssert.AreEquivalent(oracleNotifications, testHandler.showableNotifications, "La notifica è stata aggiunta");
        }
        
        
    }
}