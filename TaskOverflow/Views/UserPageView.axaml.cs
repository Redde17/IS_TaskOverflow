using Avalonia.Controls;
using TaskOverflow.ViewModels;

namespace TaskOverflow.Views
{
    public partial class UserPageView : UserControl
    {
        public UserPageView()
        {
            InitializeComponent();
        }

        private void ModifyUserButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            //hide normale user box
            UserInformationPanel.IsVisible = false;
            //show modify user box
            ModifyUserInformationPanel.IsVisible = true;
        }

        private void EndModifyUserButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var mainWindowViewModel = (MainWindowViewModel)DataContext;

            UserNameTextBox.Classes.Remove("ErrorTextBox");
            UserNameTextBox.Watermark = "Inserisci il nome profilo";

            //check for input fields
            if (string.IsNullOrEmpty(UserNameTextBox.Text))
            {
                UserNameTextBox.Classes.Add("ErrorTextBox");
                UserNameTextBox.Watermark = "Il nome non puó essere vuoto";
                return;
            }

            mainWindowViewModel.UserPageVM.EndModifyUser();

            HideUserChangeBox();
        }

        private void CancelModifyUserButtonClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            HideUserChangeBox();
        }

        private void HideUserChangeBox()
        {
            //show normale user box
            UserInformationPanel.IsVisible = true;
            //hide modify user box
            ModifyUserInformationPanel.IsVisible = false;
        }
    }
}
