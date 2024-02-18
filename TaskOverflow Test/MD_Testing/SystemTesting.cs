using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskOverflow.ViewModels;

namespace TaskOverflow_Test.MD_Testing
{
    [TestClass]
    public class SystemTesting
    {
        //Test Case ID: TC_CT1.1
        //Test frame: LEN_T1, LEN_D2, VAL_D2
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_CreateTask1() 
        {
            //prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string NomeUtente = "Test User";
            const string Titolo = "Consegna esercitazione molto importante al professore della materia per la quale devo dare l'esame a questo appello.";
            const string Descrizione = "Devo consegnare l’esercizio in orario.";

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = NomeUtente;
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            //imposta i dati di creazione del task
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = Titolo;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = Descrizione;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;            //Data valida, ovvero al momento del test
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;  //Tempo valido, ovvero al momento del test

            int TaskAmountActualDB;
            int TaskAmountActualLocal;
            int TaskAmountExpected = 0;


            //Act
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                TaskAmountActualDB = collection.Count();
            }

            TaskAmountActualLocal = MainWindowVM.TaskManagerVM.TH.tasks.Count();

            Assert.AreEqual(
                TaskAmountExpected, 
                TaskAmountActualDB, 
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualDB})");
            Assert.AreEqual(
                TaskAmountExpected, 
                TaskAmountActualLocal, 
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualLocal})");

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }

        //Test Case ID: TC_CT1.2
        //Test frame: LEN_T2, LEN_D1, VAL_D2
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_CreateTask2() 
        {
            //prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string NomeUtente = "Test User";
            const string Titolo = "Consegna esercitazione.";
            //Forse andrebbe trovato un modo migliore per salvare questo testo
            const string Descrizione = 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed vitae vestibulum nisl. Donec vitae enim metus. " +
                "Aenean consequat suscipit dui quis varius. Sed a faucibus orci, non tempor ante. Vestibulum rutrum luctus sem " +
                "non commodo. Donec maximus eros ante. Quisque convallis condimentum ante quis elementum. Cras ac erat et tellus " +
                "posuere faucibus non vel ante. Interdum et malesuada fames ac ante ipsum primis in faucibus. Cras mollis sapien ut " +
                "euismod tincidunt. Quisque interdum mi eget orci fermentum euismod. Vestibulum a porta massa, consequat bibendum eros. " +
                "Praesent facilisis ante sed sem porta, congue consectetur nibh sagittis. Aenean eget lectus at ligula lobortis porta. " +
                "Nulla mattis suscipit tortor, sit amet faucibus risus tincidunt nec. Aenean interdum ligula vulputate mollis finibus." +
                "\r\nNam dignissim commodo erat, eu mattis ipsum bibendum a. Fusce velit quam, hendrerit eu vehicula non, dapibus sed felis. " +
                "Aliquam erat volutpat. Cras congue sodales ante, in lobortis odio vehicula ac. Nam gravida vitae dui a mollis. " +
                "Suspendisse potenti. Donec volutpat est ante, non ultrices ligula semper eu. Proin ornare, lacus vitae commodo porttitor, " +
                "lacus diam lacinia magna, euismod imperdiet magna lacus at dui. Vestibulum ante ipsum primis in faucibus orci luctus et " +
                "ultrices posuere cubilia curae; Nunc orci mauris, fermentum maximus elementum non, ultrices ut mauris. Vestibulum varius " +
                "elit vel lorem commodo faucibus elementum sed libero. Proin eleifend, metus sed ultrices finibus, enim tortor dictum erat, " +
                "ut lacinia erat odio nec sapien. Vestibulum in sollicitudin sem, vitae lacinia nisi. Sed vulputate dignissim lobortis. " +
                "Nam rhoncus gravida lorem. Cras rhoncus quam dui.\r\n\r\n";

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = NomeUtente;
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            //imposta i dati di creazione del task
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = Titolo;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = Descrizione;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now;            //Data valida, ovvero al momento del test
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay;  //Tempo valido, ovvero al momento del test

            int TaskAmountActualDB;
            int TaskAmountActualLocal;
            int TaskAmountExpected = 0;

            //Act
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                TaskAmountActualDB = collection.Count();
            }

            TaskAmountActualLocal = MainWindowVM.TaskManagerVM.TH.tasks.Count();

            //Assert DB
            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualDB,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualDB})");
            //Assert running local data
            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualLocal,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualLocal})");

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }

        //Test Case ID: TC_CT1.3
        //Test frame: LEN_T2, LEN_D2, VAL_D1
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_CreateTask3() 
        {
            //prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string NomeUtente = "Test User";
            const string Titolo = "Consegna esercitazione";
            const string Descrizione = "Da consegnare l’esercitazione su richiesta del professore dove devo fare certe cose.";
            DateTime Date = DateTime.ParseExact("11-02-2024 16:00", "dd-MM-yyyy HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = NomeUtente;
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            //imposta i dati di creazione del task
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = Titolo;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = Descrizione;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = Date;            
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = Date.TimeOfDay;  

            int TaskAmountActualDB;
            int TaskAmountActualLocal;
            int TaskAmountExpected = 0;


            //Act
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                TaskAmountActualDB = collection.Count();
            }

            TaskAmountActualLocal = MainWindowVM.TaskManagerVM.TH.tasks.Count();

            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualDB,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualDB})");
            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualLocal,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualLocal})");

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }

        //Test Case ID: TC_CT1.4
        //Test frame: LEN_T2, LEN_D2, VAL_D2
        //Esito previsto: OK
        [TestMethod]
        public void TestCase_CreateTask4() 
        {
            //prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string NomeUtente = "Test User";
            const string Titolo = "Consegna esercitazione.";
            const string Descrizione = "Da consegnare l’esercitazione su richiesta del professore dove devo fare certe cose.";

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();

            //Imposta l'utente attivo al quale aggiungere il task
            MainWindowVM.UserManagerVM.CreationUser.name = NomeUtente;
            MainWindowVM.UserManagerVM.AddUser();
            MainWindowVM.ChangeSelectedUser(0);

            //imposta i dati di creazione del task
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.name = Titolo;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.CreationTask.description = Descrizione;
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Date = DateTime.Now.Date;                                   //Data valida, ovvero al momento del test
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.Time = DateTime.Now.TimeOfDay.Add(new TimeSpan(1, 0, 0));   //Tempo valido, ovvero al momento del test

            int TaskAmountActualDB;
            int TaskAmountActualLocal;
            int TaskAmountExpected = 1;


            //Act
            MainWindowVM.TaskManagerVM.TaskVM.AddTaskVM.createTask();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                TaskAmountActualDB = collection.Count();
            }

            TaskAmountActualLocal = MainWindowVM.TaskManagerVM.TH.tasks.Count();

            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualDB,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualDB})");
            Assert.AreEqual(
                TaskAmountExpected,
                TaskAmountActualLocal,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({TaskAmountExpected} != {TaskAmountActualLocal})");

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }
    }
}
