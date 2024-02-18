using Avalonia.Controls;
using Avalonia.Media;
using TaskOverflow.ViewModels;
using Tmds.DBus.Protocol;

namespace TaskOverflow.Views
{
    public partial class UserManagementView : UserControl
    {
        public UserManagementView()
        {
            InitializeComponent();
        }

        private void AddNewUserButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            SetDefaultUserInputBox();
            AddNewUserInputPanel.IsVisible = true;
            AddNewUserButtonPanel.IsVisible = false;
        }
        private void AddNewUserDone_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var mainWindowViewModel = (MainWindowViewModel)DataContext;

            //check for input fields
            if (string.IsNullOrEmpty(UserNameInputBox.Text))
            {
                SetErrorUserInputBox();
                return;
            }

            //execute command
            mainWindowViewModel.UserManagerVM.AddUser();

            //change panel
            AddNewUserInputPanel.IsVisible = false;
            AddNewUserButtonPanel.IsVisible = true;
        }

        private void AddNewUserReverseButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddNewUserInputPanel.IsVisible = false;
            AddNewUserButtonPanel.IsVisible = true;
        }

        private void SetErrorUserInputBox()
        {
            UserNameInputBox.Watermark = "Il nome del profilo non puó essere vuoto";
            //UserNameInputBox.BorderBrush = (IBrush?)this.FindResource("HighPrioritySelectedBrush");
            UserNameInputBox.Classes.Add("ErrorTextBox");
        }

        private void SetDefaultUserInputBox()
        {
            UserNameInputBox.Watermark = "Inserire il nome del profilo";
            //UserNameInputBox.BorderBrush = (IBrush?)this.FindResource("LightTextBrush");
            UserNameInputBox.Classes.Remove("ErrorTextBox");
        }
    }
}
