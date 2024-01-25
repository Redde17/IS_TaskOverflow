using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using System.Drawing;
using Color = Avalonia.Media.Color;

namespace TaskOverflow.Views.HomeViewElems
{
    public partial class TaskView : UserControl
    {
        private SolidColorBrush lowSelectedColor        = new SolidColorBrush(Color.FromArgb(255, 118, 227, 108));
        private SolidColorBrush mediumSelectedColor     = new SolidColorBrush(Color.FromArgb(255, 239, 226, 111));
        private SolidColorBrush highSelectedColor       = new SolidColorBrush(Color.FromArgb(255, 235, 94, 94));
        private SolidColorBrush lowUnselectedColor      = new SolidColorBrush(Color.FromArgb(255, 72, 119, 71));
        private SolidColorBrush mediumUnselectedColor   = new SolidColorBrush(Color.FromArgb(255, 137, 131, 77));
        private SolidColorBrush highUnselectedColor     = new SolidColorBrush(Color.FromArgb(255, 135, 66, 69));

        
        public TaskView()
        {
            InitializeComponent();
        }

        private void clickHandlerLow(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = lowSelectedColor;

            mediumPriorityButton.Background = mediumUnselectedColor;
            highPriorityButton.Background = highUnselectedColor;
        }

        private void clickHandlerMedium(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = mediumSelectedColor;

            lowPriorityButton.Background = lowUnselectedColor;
            highPriorityButton.Background = highUnselectedColor;
        }

        private void clickHandlerHigh(object sender, RoutedEventArgs e)
        {
            ((Button)sender).Background = highSelectedColor;

            mediumPriorityButton.Background = mediumUnselectedColor;
            lowPriorityButton.Background = lowUnselectedColor;
        }
    }
}
