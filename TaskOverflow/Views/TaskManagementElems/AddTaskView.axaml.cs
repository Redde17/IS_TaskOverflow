using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.LogicalTree;
using Avalonia.Media;
using System;
using TaskOverflow.ViewModels;

namespace TaskOverflow.Views
{
    public partial class AddTaskView : UserControl
    {
        public AddTaskView()
        {
            InitializeComponent();
        }

        private void clickHandlerLow(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = (IBrush?)this.FindResource("LowPrioritySelectedBrush");
            LowPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightTextBrush");

            MediumPriorityButton.Background = (IBrush?)this.FindResource("MediumPriorityUnselectedBrush");
            MediumPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");

            HighPriorityButton.Background = (IBrush?)this.FindResource("HighPriorityUnselectedBrush");
            HighPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");
        }

        private void clickHandlerMedium(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = (IBrush?)this.FindResource("MediumPrioritySelectedBrush");
            MediumPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightTextBrush");

            LowPriorityButton.Background = (IBrush?)this.FindResource("LowPriorityUnselectedBrush");
            LowPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");
            
            HighPriorityButton.Background = (IBrush?)this.FindResource("HighPriorityUnselectedBrush");
            HighPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");

        }

        private void clickHandlerHigh(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = (IBrush?)this.FindResource("HighPrioritySelectedBrush");
            HighPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightTextBrush");

            MediumPriorityButton.Background = (IBrush?)this.FindResource("MediumPriorityUnselectedBrush");
            MediumPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");

            LowPriorityButton.Background = (IBrush?)this.FindResource("LowPriorityUnselectedBrush");
            LowPriorityButtonText.Foreground = (IBrush?)this.FindResource("LightDisabledTextBrush");
        }

        private void CreateNewTaskButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            resetErrorMessages();
            var mainWindowViewModel = (MainWindowViewModel)DataContext;
            bool errorFlag = false;

            //checks
            //title null
            if (string.IsNullOrEmpty(TaskTitleTextBox.Text))
            {
                //display error
                TaskTitleTextBox.Classes.Add("ErrorTextBox");
                TaskTitleTextBox.Watermark = "Il titolo non puó essere vuoto";
                errorFlag = true;
            }

            //date checks
            DateTime newDate;

            newDate = ((DateTimeOffset)TaskDatePicker.SelectedDate).Date;
            newDate = newDate.Add(((TimeSpan)TaskTimePicker.SelectedTime));

            if (DateTime.Compare(newDate, DateTime.Now) < 0)
            {
                //error handling
                DateTimePickerErrorTextBlock.Text = "La scadenza non é valida";
                errorFlag = true;
            }

            if (errorFlag)
                return;


            //create if ok
            mainWindowViewModel.TaskManagerVM.CreateTask();
        }

        private void resetErrorMessages()
        {
            DateTimePickerErrorTextBlock.Text = "";
            TaskTitleTextBox.Classes.Remove("ErrorTextBox");
        }
    }
}
