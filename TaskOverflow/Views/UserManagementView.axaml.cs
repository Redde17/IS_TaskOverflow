using Avalonia.Controls;

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
            AddNewUserInputPanel.IsVisible = true;
            AddNewUserButtonPanel.IsVisible = false;
        }
        private void AddNewUserDone_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            AddNewUserInputPanel.IsVisible = false;
            AddNewUserButtonPanel.IsVisible = true;
        }
    }
}
