using Avalonia;
using ReactiveUI;
using System;
using System.Collections.ObjectModel;
using TaskOverflow.Models.TaskManagement;
using TaskOverflow.Views.TaskManagementElems;

//Per evitare conflitti con il tipo Task della libreria System
using Task = TaskOverflow.Models.TaskManagement.Task;

namespace TaskOverflow.ViewModels
{
    public class TaskManagementViewModel : ViewModelBase
    {
        public TasksHandler TH { get; }

        private int _taskListComboBoxSelectedIndex;
        private int _comboBoxSelectedIndex;
        private TaskViewModel _taskVM;

        public int TaskListComboBoxSelectedIndex
        {
            get => _taskListComboBoxSelectedIndex;
            set
            {
                if (value >= 0)
                    TaskVM.ShowExistingTaskView(TH.tasks[value]);
                else
                    TaskVM.ShowNothing();

                _taskListComboBoxSelectedIndex = value;
            }
        }
        public int ComboBoxSelectedIndex
        {
            get => _comboBoxSelectedIndex;
            set
            {
                SortingSelector(value);
                _comboBoxSelectedIndex = value;
            }
        }
        public TaskViewModel TaskVM
        {
            get => _taskVM;
            private set => _taskVM = value;
        }

        public TaskManagementViewModel(TasksHandler TH)
        {
            this.TH = TH;     
            ComboBoxSelectedIndex = 0; // application start with task list sorted by priority up
            TaskVM = new(this.TH);
        }


        //functional functions
        public void CreateTask()
        {
            TaskVM.AddTaskVM.createTask();
            TaskVM.ShowNothing();
        }

        public void DeleteSelectedTask()
        {
            TaskVM.ExistingTaskVM.deleteSelectedTask(TH.tasks[TaskListComboBoxSelectedIndex]);
        }

        public void StartModificationOfSelectedTask()
        {
            TaskVM.ModifyTaskVM.SetModifySelectedTask(TH.tasks[TaskListComboBoxSelectedIndex]);
            TaskVM.ShowModifyTaskView();
        }

        public void ModifySelectedTask()
        {
            TaskVM.ModifyTaskVM.ModifyTask();
            TaskVM.ShowNothing();
        }

        public void SortingSelector(int selectedIndex)
        {
            System.Diagnostics.Debug.WriteLine(
                "DEBUG\n" +
                $"Selected index: {selectedIndex}\n"
            );

            //Index mapping
            //By prioriy up:    0
            //By prioriy down:  1
            //By date due up:   2
            //By date due down: 3
            //Invalid:          0 > selectedIndex > 3

            switch (selectedIndex)
            {
                case 0:
                    //By prioriy up
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by prioriy up\n"
                    );
                    //do the sorting 
                    break;
                case 1:
                    //By prioriy down
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by prioriy down\n"
                    );
                    //do the sorting 
                    break;
                case 2:
                    //By date due up
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by date due up\n"
                    );
                    //do the sorting 
                    break;
                case 3:
                    //By date due down
                    System.Diagnostics.Debug.WriteLine(
                        "index action: sorting by date due down\n"
                    );
                    //do the sorting 
                    break;
                default:
                    //invalid index
                    System.Diagnostics.Debug.WriteLine(
                        "Error in index action parsing\n"
                    );
                    //send error
                    break;
            }

        }


        #region debug functions
        //DEBUG functions
        private void PrintTaskList()
        {
            System.Diagnostics.Debug.WriteLine("ViewModel TaskManagerVM task list");
            foreach (Task Task in TH.tasks)
            {
                System.Diagnostics.Debug.WriteLine(
                string.Format(
                    $"id = {Task.id}\n" +
                    $"nome = {Task.name}\n" +
                    $"descrizione = {Task.description}\n" +
                    $"Data = {Task.date}\n"
                    )
                );
            }
        }

        public void DebugFunc()
        {
            System.Diagnostics.Debug.WriteLine("\ndebugFunc stream start: \n");

            System.Diagnostics.Debug.WriteLine("Hello :) \n");

            System.Diagnostics.Debug.WriteLine("\ndebugFunc stream end: \n");
        }
        #endregion
    }
}