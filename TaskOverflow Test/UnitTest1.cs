using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Models.UserManagement;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow_Test
{
    //La classe di unit testing, create una vostra classe per eseguire i vostri testing, cosi cerchiamo di separare i file tra di noi
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        //funziona di prova per una piccola dimostrazione del testing
        //Imoportante per far partire il testing bisogna avviare il progetto del testing, non TaskOverflow
        public void TestProva1()
        {
            //Visto che il testing agisce direttamente sul progetto, esso usa anche il DB che usa il programma
            //Quindi ad ogni avvio di Test fate attenzione che verrá utilizzato il DB standard.
            //Vista questa ragione l'if sottostante serve a cancellare automaticamente il DB, a seconda della situzione
            //vedete se vi serve o meno
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            //Generalmente ci atteniamo al fatto che la funzione di test si divide in 3 parti
            //Arrange: Dove vengono formulati i dati da usare
            //Act: Dove viene eseguita la funziona da testare
            //Assert: Dove viene controllato il risultato della funzione per vedere che si attiene ad un valore atteso.


            //Arrange
            UserHandler UH = new UserHandler();
            TasksHandler TH = new TasksHandler(UH);
            
            User newUser = new User("TestName");
            UH.addUser(newUser);
            UH.chooseActiveUser(UH.users[0], TH);
            Task testTask = new Task();
            
            //Act
            TH.addTask(testTask);

            //Assert
            Assert.AreEqual(1, TH.tasks.Count, "Andato tutto male");
        }
    }
}