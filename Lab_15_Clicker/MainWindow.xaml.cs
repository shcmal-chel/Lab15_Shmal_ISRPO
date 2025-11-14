using System.Windows;

namespace Lab_15_Clicker
{
    public partial class MainWindow : Window
    {
        private int _counter = 0;
        public MainWindow()
        {
            InitializeComponent();
            UpdateCounterText();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _counter++;
            UpdateCounterText();
        }
        private void UpdateCounterText()
        {
            CounterText.Text = $"Счетчик: {_counter}";
        }
    }
}