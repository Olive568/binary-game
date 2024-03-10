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
using System.Windows.Shapes;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for Tutorial.xaml
    /// </summary>
    /// 
    public partial class Tutorial : Window
    {
        string Answer = "01111011";
        public Tutorial()
        {
            InitializeComponent();
            Switch128.IsEnabled = false;
            Switch64.IsEnabled = false;
            Switch32.IsEnabled = false;
            Switch16.IsEnabled = false;
            Switch8.IsEnabled = false;
            Switch4.IsEnabled = false;
            Switch2.IsEnabled = false;
            Switch1.IsEnabled = false;
            p64();
        }
        private void p64()
        {
            Switch64.IsEnabled = true;
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
            p32();
        }
        private void p32()
        {
            Switch64.IsEnabled = false;
            Switch32.IsEnabled = true;
        }
        private void p16()
        {
            Switch32.IsEnabled = false;
            Switch16.IsEnabled = true;
        }
        private void p8()
        {
            Switch16.IsEnabled = false;
            Switch8.IsEnabled = true;
        }
        private void p2()
        {
            Switch8.IsEnabled = false;
            Switch2.IsEnabled = true;
        }
        private void p1()
        {
            Switch2.IsEnabled = false;
            Switch1.IsEnabled = true;
        }
        private void pSubmit()
        {
            Switch1.IsEnabled = false;
            SubmitBtn.IsEnabled = true;
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
            p16();
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
            p8();
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
            p2();
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
            p1();
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
            pSubmit();
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
                MessageBox.Show("");
            }
            else
            {
                MessageBox.Show("wrong");
            }
        }
    }
}
