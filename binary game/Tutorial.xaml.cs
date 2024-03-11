using System.Windows;
using System.Windows.Controls;

namespace binary_game
{
    public partial class Tutorial : Window
    {
        string Answer = "01111011";

        public Tutorial()
        {
            InitializeComponent();
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
        }

        private void Button_Click_Switch32(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label32);
            EnableNextSwitch(Switch16);
        }

        private void Button_Click_Switch16(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label16);
            EnableNextSwitch(Switch8);
        }

        private void Button_Click_Switch8(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label8);
            EnableNextSwitch(Switch2);
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
        }

        private void Button_Click_Switch1(object sender, RoutedEventArgs e)
        {
            ToggleSwitch(Label1);
            EnableSubmitButton();
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
                MessageBox.Show("Correct!");
            }
            else
            {
                MessageBox.Show("Wrong answer. Try again!");
            }
        }
    }
}
