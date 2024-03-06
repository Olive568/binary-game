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
using System.IO;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int score = 0;
        int Total_Time = 0;
        private SoundPlayer player;
        private MediaPlayer Blow = new MediaPlayer();
        int seconds = 0;
        int timer = 0;
        string diff = "";
        string Answer = "";
        bool _timerStatus = false;
        DispatcherTimer _dt = null;
        public Window1(string difficulty)
        {
            InitializeComponent();
            diff = difficulty;
            if (difficulty == "easy")
                seconds = 60;
            else if (difficulty == "medium")
                seconds = 45;
            else if (difficulty == "hard")
                seconds = 30;
            timer = seconds;
            Blow.Open(new Uri(@"C:\Users\22-0042c\source\repos\binary-game\binary game\blow.wav"));
            player = new SoundPlayer(@"C:\Users\22-0042c\source\repos\binary-game\binary game\GameStart.wav");
            player.Play();
            player = new SoundPlayer(@"C:\Users\22-0042c\source\repos\binary-game\binary game\beep.wav");
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }
        private void _dt_Tick(object sender, EventArgs e)
        {
            
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            timer--;
            score++;
            Total_Time ++;
            player.Play();
            if(diff == "medium" ||  diff == "hard")
            {
                Random rnd = new Random();
                int chance = rnd.Next(1, 101);
                Label128.Opacity = 100;
                Label64.Opacity = 100;
                Label32.Opacity = 100;
                Label16.Opacity = 100;
                Label8.Opacity = 100;
                Label4.Opacity = 100;
                Label2.Opacity = 100;
                Label1.Opacity = 100;
                if (chance > 66)
                {
                    Label128.Opacity = 0;
                    Label64.Opacity = 0;
                    Label32.Opacity = 0;
                    Label16.Opacity = 0;
                    Label8.Opacity = 0;
                    Label4.Opacity = 0;
                    Label2.Opacity = 0;
                    Label1.Opacity = 0;
                }
            }
            if(timer > 10)
                lblTimerDisplay.Foreground = Brushes.Black;
            if (timer == 10)
            {
                lblTimerDisplay.Foreground = Brushes.Red;
            }
            else if(timer == 6)
                Blow.Play();
            else if (timer == 0)
            {
                MessageBox.Show("You lose");
                this.Close();
            }
            lblTimerDisplay.Content = timer.ToString();
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
                if (timer != seconds /3)
                    timer -= 2;
                score += 30;
                Start();
            }
            else
            {
                MessageBox.Show("wrong");
                this.Close();
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
