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
using System.Media;


namespace binary_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private SoundPlayer player;
        private MediaPlayer Blow = new MediaPlayer();
        int seconds = 32;
        string Answer = "";
        bool _timerStatus = false;
        DispatcherTimer _dt = null;
        public Window1()
        {
            InitializeComponent();
            Blow.Open(new Uri(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\bin\Debug\blow.wav"));
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\bin\Debug\GameStart.wav");
            player.Play();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\bin\Debug\beep.wav");
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }
        private void _dt_Tick(object sender, EventArgs e)
        {
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            sec--;
            player.Play();
            if (sec == 10)
            {
                Blow.Play();
                lblTimerDisplay.Foreground = Brushes.Red;
            }
            else if (sec == 0)
            {
                MessageBox.Show("You lose");
            }
            lblTimerDisplay.Content = sec.ToString();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled = true;
            SubmitBtn.Visibility = Visibility.Visible;
            Start();
        }
        private void Start()
        {
            Label128.Content = "0";
            Label64.Content = "0";
            Label32.Content = "0";
            Label16.Content = "0";
            Label8.Content = "0";
            Label4.Content = "0";
            Label2.Content = "0";
            Label1.Content = "0";
            if (seconds != 10)
                seconds -= 2;
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
            for (int i = ans.Length - 1; i >= 0; i--)
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
            string binarystring = "";
            binarystring += Label128.Content;
            binarystring += Label64.Content;
            binarystring += Label32.Content;
            binarystring += Label16.Content;
            binarystring += Label8.Content;
            binarystring += Label4.Content;
            binarystring += Label2.Content;
            binarystring += Label1.Content;
            if (binarystring == Answer)
            {
                Start();
            }
            else
            {
                MessageBox.Show("wrong");
            }
        }

        private void Button_Click_Switch128(object sender, RoutedEventArgs e)
        {
            if (Label128.Content == "0")
            {
                Label128.Content = "1";
            }
            else if (Label128.Content == "1")
            {
                Label128.Content = "0";
            }
        }

        private void Button_Click_Switch64(object sender, RoutedEventArgs e)
        {
            if (Label64.Content == "0")
            {
                Label64.Content = "1";
            }
            else if (Label64.Content == "1")
            {
                Label64.Content = "0";
            }
        }

        private void Button_Click_Switch32(object sender, RoutedEventArgs e)
        {
            if (Label32.Content == "0")
            {
                Label32.Content = "1";
            }
            else if (Label32.Content == "1")
            {
                Label32.Content = "0";
            }
        }

        private void Button_Click_Switch16(object sender, RoutedEventArgs e)
        {
            if (Label16.Content == "0")
            {
                Label16.Content = "1";
            }
            else if (Label16.Content == "1")
            {
                Label16.Content = "0";
            }
        }

        private void Button_Click_Switch8(object sender, RoutedEventArgs e)
        {
            if (Label8.Content == "0")
            {
                Label8.Content = "1";
            }
            else if (Label8.Content == "1")
            {
                Label8.Content = "0";
            }
        }

        private void Button_Click_Switch4(object sender, RoutedEventArgs e)
        {
            if (Label4.Content == "0")
            {
                Label4.Content = "1";
            }
            else if (Label4.Content == "1")
            {
                Label4.Content = "0";
            }
        }

        private void Button_Click_Switch2(object sender, RoutedEventArgs e)
        {
            if (Label2.Content == "0")
            {
                Label2.Content = "1";
            }
            else if (Label2.Content == "1")
            {
                Label2.Content = "0";
            }
        }

        private void Button_Click_Switch1(object sender, RoutedEventArgs e)
        {
            if (Label1.Content == "0")
            {
                Label1.Content = "1";
            }
            else if (Label1.Content == "1")
            {
                Label1.Content = "0";
            }
        }
    }
}
