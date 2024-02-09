using Avalonia.Controls;

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
            //show normale user box
            UserInformationPanel.IsVisible = true;
            //hide modify user box
            ModifyUserInformationPanel.IsVisible = false;
        }
    }
}
