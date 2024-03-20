using System.Media;
using System.Windows;
using System.Windows.Controls;

namespace binary_game
{
    public partial class Tutorial : Window
    {
        string Answer = "01111011";
        private SoundPlayer player;
        public Tutorial()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\22-0042c\source\repos\binary-game\binary game\TutorialVoice.wav");
            player.Play();
            DisableAllSwitchesExcept64();
        }

        private void DisableAllSwitchesExcept64()
        {
            Switch64.IsEnabled = true;
            Switch128.IsEnabled = false;
            Switch32.IsEnabled = false;
            Switch16.IsEnabled = false;
            Switch8.IsEnabled = false;
            Switch4.IsEnabled = false;
            Switch2.IsEnabled = false;
            Switch1.IsEnabled = false;
        }

        private void EnableNextSwitch(Button switchButton)
        {
            switchButton.IsEnabled = true;
        }

        private void Button_Click_Switch128(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label128);
        }

        private void Button_Click_Switch64(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label64);
            EnableNextSwitch(Switch32);
            Switch64.IsEnabled = false;
        }

        private void Button_Click_Switch32(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label32);
            EnableNextSwitch(Switch16);
            Switch64.IsEnabled = false;
        }

        private void Button_Click_Switch16(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label16);
            EnableNextSwitch(Switch8);
            Switch64.IsEnabled = false;
        }

        private void Button_Click_Switch8(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label8);
            EnableNextSwitch(Switch2);
            Switch64.IsEnabled = false;
        }

        private void Button_Click_Switch4(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label4);
            EnableNextSwitch(Switch2);
        }

        private void Button_Click_Switch2(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label2);
            EnableNextSwitch(Switch1);
            Switch64.IsEnabled = false;
        }

        private void Button_Click_Switch1(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label1);
            EnableSubmitButton();
            Switch64.IsEnabled = false;
        }

        private void ToggleSwitch(Label label)
        {
            label.Content = (label.Content.ToString() == "0") ? "1" : "0";
        }

        private void EnableSubmitButton()
        {
            SubmitBtn.IsEnabled = true;
            SubmitBtn.Opacity = 100;
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            string binarystring = $"{Label128.Content}{Label64.Content}{Label32.Content}{Label16.Content}{Label8.Content}{Label4.Content}{Label2.Content}{Label1.Content}";
            if (binarystring == Answer)
            {
                MessageBox.Show("Good job Lieutenant. Get ready for the field");
                Cutscene ct = new Cutscene();
                ct.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong answer. Try again Lieutenant!");
                Label128.Content = 0;
                Label64.Content = 0;
                Label32.Content = 0;
                Label16.Content = 0;
                Label8.Content = 0;
                Label4.Content = 0;
                Label2.Content = 0;
                Label1.Content = 0;
                DisableAllSwitchesExcept64();
            }
        }
    }
}
