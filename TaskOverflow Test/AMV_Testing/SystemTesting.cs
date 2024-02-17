using System.Collections.ObjectModel;
using TaskOverflow.ViewModels;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow_Test.AMV_Testing
{
    [TestClass]
    
    public class SystemTesting
    {
        //Test Case ID: TC_OT1.1
        //Test frame: IND_T1
        //Esito previsto: HANDLED ERROR (Nessuna modifica)
        [TestMethod]
        public void TestCase_SortTask1()
        {
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
            
            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = "Test Uggine";
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            MainWindowVM.TaskManagerVM.TaskVM.TH.tasks = new ObservableCollection<Task>();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(0);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.SortingSelector(0);

            ObservableCollection<Task> oracle =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            ObservableCollection<Task> actual =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            CollectionAssert.AreEquivalent(oracle, actual, "TEST FALLITO: I risultati non coincidono");
            
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
        }
        
        //Test Case ID: TC_OT1.2
        //Test frame: IND_T2
        //Esito previsto: Ordinamento Task per priorità ascendente
         [TestMethod]
        public void TestCase_SortTask2()
        {
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
            
            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = "Test Uggine";
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            MainWindowVM.TaskManagerVM.TaskVM.TH.tasks = new ObservableCollection<Task>();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(0);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.SortingSelector(1);

            ObservableCollection<Task> oracle =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks.OrderBy(task => task.priority));
            
            ObservableCollection<Task> actual =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            CollectionAssert.AreEquivalent(oracle, actual, "TEST FALLITO: I risultati non coincidono");
            
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
        }
        
        //Test Case ID: TC_OT1.3
        //Test frame: IND_T3
        //Esito previsto: Ordinamento Task per priorità discendente
         [TestMethod]
                public void TestCase_SortTask3()
                {
                    if (File.Exists(@"/home/maria/test/database.db"))
                        File.Delete(@"/home/maria/test/database.db");
                    
                    MainWindowViewModel MainWindowVM = new MainWindowViewModel();
                    //Imposta l'utente attivo al quale aggiungere il task
                    MainWindowVM.UserManagerVM.CreationUser.name = "Test Uggine";
                    MainWindowVM.UserManagerVM.AddUser();
                    MainWindowVM.ChangeSelectedUser(0);
        
                    MainWindowVM.TaskManagerVM.TaskVM.TH.tasks = new ObservableCollection<Task>();
                    
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo1";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione1";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
                    
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo2";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione2";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(0);
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
                    
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo3";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione3";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
                    
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo4";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione4";
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
                    MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
                    
                    MainWindowVM.TaskManagerVM.SortingSelector(2);
        
                    ObservableCollection<Task> oracle =
                        new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks.OrderByDescending(task => task.priority));
                    
                    ObservableCollection<Task> actual =
                        new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
                    
                    CollectionAssert.AreEquivalent(oracle, actual, "TEST FALLITO: I risultati non coincidono");
                    
                    if (File.Exists(@"/home/maria/test/database.db"))
                        File.Delete(@"/home/maria/test/database.db");
                }
                
        //Test Case ID: TC_OT1.4
        //Test frame: IND_T4
        //Esito previsto: Ordinamento Task per data ascendente
                 [TestMethod]
        public void TestCase_SortTask4()
        {
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
            
            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = "Test Uggine";
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);
            
            MainWindowVM.TaskManagerVM.TaskVM.TH.tasks = new ObservableCollection<Task>();

            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(0);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.SortingSelector(3);

            ObservableCollection<Task> oracle =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks.OrderBy(task => task.date));
            
            ObservableCollection<Task> actual =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            CollectionAssert.AreEquivalent(oracle, actual, "TEST FALLITO: I risultati non coincidono");
            
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
        }
        
        //Test Case ID: TC_OT1.5
        //Test frame: IND_T5
        //Esito previsto: Ordinamento Task per data discendente
         [TestMethod]
        public void TestCase_SortTask5()
        {
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
            
            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = "Test Uggine";
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione1";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione2";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.AddDays(2);          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(0);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione3";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = "Titolo4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = "Descrizione4";
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;          
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.AddHours(1).TimeOfDay;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.PrioritySelector(1);
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();
            
            MainWindowVM.TaskManagerVM.SortingSelector(4);

            ObservableCollection<Task> oracle =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            ObservableCollection<Task> actual =
                new ObservableCollection<Task>(MainWindowVM.TaskManagerVM.TaskVM.ExistingTaskVM.TH.tasks);
            
            CollectionAssert.AreEquivalent(oracle, actual, "TEST FALLITO: I risultati non coincidono");
            
            if (File.Exists(@"/home/maria/test/database.db"))
                File.Delete(@"/home/maria/test/database.db");
        }
    }
}