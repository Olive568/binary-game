using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int seconds = 32;
        string Answer = "";
        bool _timerStatus = false;
        DispatcherTimer _dt = null;
        public MainWindow()
        {
            InitializeComponent();
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }
        private void _dt_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            sec--;
            if (sec == 0)
            {
                MessageBox.Show("You lose");
            }
            lblTimerDisplay.Content = sec.ToString();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            Start();
        }
        private void Start()
        {
            if (seconds != 10)
                seconds -= 2;
            Try.Text = "";
            lblTimerDisplay.Content = seconds;
            GenerateNumber();
            StartBtn.Visibility = Visibility.Hidden;
            //StartBtn.Visibility = Visibility.Visible;
            _dt.Start();
        }
        private void GenerateNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 256);
            string binary = Convert(number);
            Answer = binary;
            Game(number);
        }
        private string Convert(int number)
        {
            string ans = "";
            int StartingNumber = number;
            while (StartingNumber > 0)
            {
                int remainder = StartingNumber % 2;
                StartingNumber /= 2;
                ans += remainder.ToString();
            }
            while (ans.Length < 8)
            {
                ans += 0;
            }
            string ans2 = "";
            for(int i = ans.Length - 1; i >= 0; i--)
            {
                ans2 += ans[i];
            }
            return ans2;
        }
        private void Game(int number)
        {
            Question.Content = number;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string textboxcontent = Try.Text;
            string tryint = textboxcontent;
            if (tryint == Answer)
            {
                Start();
            }
            else
            {
                MessageBox.Show("wrong");
            }
        }
    }
}
