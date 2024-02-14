using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskOverflow.Models.DataPersistency;
using TaskOverflow.Models.UserManagement;

namespace TaskOverflow_Test.CS_Testing
{
    [TestClass]
    public class UnitTesting
    {
        //Test Case ID: TC_IU1.1
        //Test frame: VAL_D1
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_InsertUser1()
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            UserDAO userDAO = new UserDAO();

            int DBuserAmount;
            int DBuserExpectedAmount = 0;

            //Act
            userDAO.insertUser(null);

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<User>("user");
                DBuserAmount = collection.Count();
            }

            Assert.AreEqual(
                DBuserExpectedAmount,
                DBuserAmount,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({DBuserExpectedAmount} != {DBuserAmount})"
                );
        }

        //Test Case ID: TC_IU1.2
        //Test frame: VAL_D2
        //Esito previsto: OK
        [TestMethod]
        public void TestCase_InsertUser2()
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            UserDAO userDAO = new UserDAO();
            User user = new User();

            int DBuserAmount;
            int DBuserExpectedAmount = 1;

            //Act
            userDAO.insertUser(user);

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<User>("user");
                DBuserAmount = collection.Count();
            }

            Assert.AreEqual(
                DBuserExpectedAmount,
                DBuserAmount,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({DBuserExpectedAmount} != {DBuserAmount})"
                );
        }
    }
}
