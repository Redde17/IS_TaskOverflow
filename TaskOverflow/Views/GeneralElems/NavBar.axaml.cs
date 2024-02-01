using Avalonia.Controls;
using Avalonia.Interactivity;

namespace TaskOverflow.Views.GeneralElems
{
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }

        private void clickHandlerTaskManagmentView(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false; //disable the button that was just pressed

            UserManagementViewButton.IsEnabled = true;

        }

        private void clickHandlerUserManagmentView(object sender, RoutedEventArgs e)
        {
            ((Button)sender).IsEnabled = false; //disable the button that was just pressed

            TaskManagementViewButton.IsEnabled = true;
        }
    }
}
