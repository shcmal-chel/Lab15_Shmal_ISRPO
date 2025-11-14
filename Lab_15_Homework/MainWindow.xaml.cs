using System;
using System.Media;
using System.Windows;
using System.Windows.Threading;

namespace Lab_15_Homework
{
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan timeLeft;
        private bool isRunning = false;
        public MainWindow()
        {
            InitializeComponent();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            DurationComboBox.Items.Add(15);
            DurationComboBox.Items.Add(25);
            DurationComboBox.Items.Add(45);
            DurationComboBox.SelectedItem = 25;

            ResetTimer();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft.TotalSeconds > 0)
            {
                timeLeft = timeLeft.Subtract(TimeSpan.FromSeconds(1));
                TimeDisplay.Text = $"{timeLeft:mm\\:ss}";
            }
            else
            {
                timer.Stop();
                isRunning = false;
                StartButton.Content = "Старт";
                SystemSounds.Beep.Play();
                MessageBox.Show("Время вышло!");
            }
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRunning)
            {
                timer.Start();
                isRunning = true;
                StartButton.Content = "Пауза";
            }
            else
            {
                timer.Stop();
                isRunning = false;
                StartButton.Content = "Старт";
            }
        }
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            isRunning = false;
            StartButton.Content = "Старт";
            ResetTimer();
        }
        private void DurationComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (!isRunning)
            {
                ResetTimer();
            }
        }
        private void ResetTimer()
        {
            if (DurationComboBox.SelectedItem != null)
            {
                int minutes = (int)DurationComboBox.SelectedItem;
                timeLeft = TimeSpan.FromMinutes(minutes);
                TimeDisplay.Text = $"{timeLeft:mm\\:ss}";
            }
        }
    }
}