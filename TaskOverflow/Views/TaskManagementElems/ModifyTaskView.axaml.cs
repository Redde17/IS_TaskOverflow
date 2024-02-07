using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace TaskOverflow.Views
{
    public partial class ModifyTaskView : UserControl
    {
        public ModifyTaskView()
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
    }
}
