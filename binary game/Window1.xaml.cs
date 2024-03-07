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
        bool[] Equipment = new bool[6];
        int quest = 0;
        int score = 0;
        private SoundPlayer player;
        private MediaPlayer Blow = new MediaPlayer();
        private MediaPlayer Glock = new MediaPlayer();
        int seconds = 0;
        int seconds2 = 0;
        int timer = 0;
        string diff = "";
        string Answer = "";
        bool _timerStatus = false;
        DispatcherTimer _dt = null;
        int ECM = 0;
        int laptop = 0;
        int kit = 0;
        int helmet = 0;
        int kevlar = 0;
        int Pistol = 0;
        bool hit = false;
        public Window1(string difficulty, bool[] equip)
        {
            InitializeComponent();
            diff = difficulty;
            if (difficulty == "easy")
                seconds = 60;
            else if (difficulty == "medium")
                seconds = 45;
            else if (difficulty == "hard" || difficulty == "insane")
                seconds = 30;
            Equipment = equip;
            if (Equipment[1] == true)
                kevlar = 3;
            if (Equipment[2] == true)
                ECM = 11;
            if (Equipment[3] == true)
            {
                laptop = 11;
                Guide.Opacity = 100;
            }
            if (Equipment[4] == true)
            {
                kit = seconds / 10;
                seconds = seconds + kit;
            }
            seconds2 = seconds;
            if (Equipment[5] == true)
                helmet = 5;
            timer = seconds;
            Blow.Open(new Uri(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\blow.wav"));
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\GameStart.wav");
            player.Play();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\beep.wav");
            _dt = new DispatcherTimer();
            _dt.Tick += _dt_Tick;
            _dt.Interval = new TimeSpan(0, 0, 0, 1, 0);
        }
        private void _dt_Tick(object sender, EventArgs e)
        {
            
            int sec = int.Parse(lblTimerDisplay.Content.ToString());
            timer--;
            player.Play();
            Question.Content = quest;
            Label128.Opacity = 100;
            Label64.Opacity = 100;
            Label32.Opacity = 100;
            Label16.Opacity = 100;
            Label8.Opacity = 100;
            Label4.Opacity = 100;
            Label2.Opacity = 100;
            Label1.Opacity = 100;
            if (diff == "medium" ||  diff == "hard" || diff == "insane" && hit == false)
            {
                
                Random rnd = new Random();
                int chance = rnd.Next(1, 101) -ECM;

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
                if(diff == "hard" || diff == "insane")
                {
                    chance = rnd.Next(1, 101);
                    if(chance > 66)
                        Question.Content = "error";
                }
                if(diff == "insane")
                {
                    Bitwise();
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
                if (kevlar > 0)
                {
                    timer = seconds2;
                    kevlar--;
                    Start();
                }
                else
                {
                    player.Stop();
                    Window2 w2 = new Window2(score.ToString(),diff);
                    this.Close();
                    _dt.Stop();
                    MessageBox.Show("You lose");
                    w2.Show();        
                }
            }
            lblTimerDisplay.Content = timer.ToString();
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            SubmitBtn.IsEnabled = true;
            SubmitBtn.Visibility = Visibility.Visible;
            if (Equipment[0] == true)
            {
                Pistol = 4;
                Shooting.IsEnabled = true;
                Target.Opacity = 100;
            }
            Start();
        }
        private void Start()
        {
            hit = false;
            Label128.Content = "0";
            Label64.Content = "0";
            Label32.Content = "0";
            Label16.Content = "0";
            Label8.Content = "0";
            Label4.Content = "0";
            Label2.Content = "0";
            Label1.Content = "0";
            lblTimerDisplay.Content = timer;
            GenerateNumber();
            StartBtn.Visibility = Visibility.Hidden;
            //StartBtn.Visibility = Visibility.Visible;
            _dt.Start();
        }
        private void GenerateNumber()
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 256);
            quest = number;
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
                {
                    seconds2 -= 2;
                    timer = seconds2;
                    
                }
                score += 1;
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
        private void Bitwise()
        {
            Label[] labels = new Label[] { Label128, Label64, Label32, Label16, Label8, Label4, Label2, Label1 };
            Random rnd = new Random();
            int chance = rnd.Next(1, 101) - helmet;
            if(chance > 90)
            {
                int index = rnd.Next(0, labels.Length);
                if (labels[index].Content == "0")
                {
                    labels[index].Content = "1";
                }
                else if (labels[index].Content == "1")
                {
                    labels[index].Content = "0";
                }
            }

        }

        private void Button_Click_Shoot(object sender, RoutedEventArgs e)
        {
            if(Pistol > 0) 
            {
                Pistol -= 1;
                hit = true;
                timer += 6;
                Glock.Open(new Uri(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\Glock.wav"));
                Glock.Play();
            }
            if(Pistol == 0)
            {
                Target.Opacity = 0;
            }
        }
    }
}
