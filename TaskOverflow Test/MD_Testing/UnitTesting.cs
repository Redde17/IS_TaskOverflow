using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskOverflow.Models.DataPersistency;
using TaskOverflow.Models.TaskManagement;
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow_Test.MD_Testing
{
    [TestClass]
    public class UnitTesting
    {
        //Test Case ID: TC_IT1.1
        //Test frame: VAL_D1
        //Esito previsto: HANDLED ERROR
        [TestMethod]
        public void TestCase_InsertTask1() 
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            TaskDAO taskDAO = new TaskDAO();

            int DBtaskAmount;
            int DBtaskExpectedAmount = 0;

            //Act
            taskDAO.insertTask(null);

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                DBtaskAmount = collection.Count();
            }

            Assert.AreEqual(
                DBtaskExpectedAmount,
                DBtaskAmount,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({DBtaskExpectedAmount} != {DBtaskAmount})"
                );
        }

        //Test Case ID: TC_IT1.2
        //Test frame: VAL_D2
        //Esito previsto: OK
        [TestMethod]
        public void TestCase_InsertTask2() 
        {
            //Prepare
            if (File.Exists(@"C:\Temp\database.db"))
                File.Delete(@"C:\Temp\database.db");

            TaskDAO taskDAO = new TaskDAO();
            Task task = new Task();

            int DBtaskAmount;
            int DBtaskExpectedAmount = 1;

            //Act
            taskDAO.insertTask(task);

            //Assert
            using (var db = new LiteDatabase(@"C:\Temp\database.db"))
            {
                var collection = db.GetCollection<Task>("task");
                DBtaskAmount = collection.Count();
            }

            Assert.AreEqual(
                DBtaskExpectedAmount,
                DBtaskAmount,
                $"TEST FAILED: Il valore atteso non corrisponde a quello previsto: ({DBtaskExpectedAmount} != {DBtaskAmount})"
                );
        }
    }
}
