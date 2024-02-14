using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskOverflow.Models.UserManagement;
using TaskOverflow.ViewModels;

namespace TaskOverflow_Test.CS_Testing
{
    [TestClass]
    public class SystemTesting
    {
        //Test Case ID: TC_CU1.1
        //Test frame: LEN_N1
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_CreateUser1()
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string nome = "Profilo per la gestione dei miei task personali che mi vengono assegnati in universitá";

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            MainWindowVM.UserManagerVM.CreationUser.name = nome;

            int UserAmountActualDB;
            int UserAmountActualLocal;
            int UserAmountExpected = 0;

            //Act
            MainWindowVM.UserManagerVM.AddUser();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<User>("user");
                UserAmountActualDB = collection.Count();
            }

            UserAmountActualLocal = MainWindowVM.UserManagerVM.UH.users.Count();

            Assert.AreEqual(
                UserAmountExpected,
                UserAmountActualDB,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({UserAmountExpected} != {UserAmountActualDB})"
                );
            Assert.AreEqual(
                UserAmountExpected,
                UserAmountActualLocal,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({UserAmountExpected}  !=  {UserAmountActualDB})"
                );

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }

        //Test Case ID: TC_CU1.2
        //Test frame: LEN_N2
        //Esito previsto: OK
        [TestMethod]
        public void TestCase_CreateUser2()
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            const string nome = "Profilo universitario";

            MainWindowViewModel MainWindowVM = new MainWindowViewModel();
            MainWindowVM.UserManagerVM.CreationUser.name = nome;

            int UserAmountActualDB;
            int UserAmountActualLocal;
            int UserAmountExpected = 1;

            //Act
            MainWindowVM.UserManagerVM.AddUser();

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<User>("user");
                UserAmountActualDB = collection.Count();
            }

            UserAmountActualLocal = MainWindowVM.UserManagerVM.UH.users.Count();

            Assert.AreEqual(
                UserAmountExpected,
                UserAmountActualDB,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({UserAmountExpected} != {UserAmountActualDB})"
                );
            Assert.AreEqual(
                UserAmountExpected,
                UserAmountActualLocal,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({UserAmountExpected}  !=  {UserAmountActualDB})"
                );

            //clean 
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");
        }
    }
}
