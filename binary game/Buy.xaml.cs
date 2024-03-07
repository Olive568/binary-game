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
using System.Media;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for Buy.xaml
    /// </summary>
    
    public partial class Buy : Window
    {
        //1 Pistol
        //2 kevlar
        //3 jammer
        //4 laptop
        //5 kit
        //6 helmet
        private SoundPlayer player;
        int money = 800;
        bool[] equipment = new bool[6];
        string diff = "";
        public Buy(string dificulty)
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\BuySound.wav");
            player.Play();
            diff =dificulty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1(diff,equipment);
            w1.Show();
            this.Close();
        }
        private void Pistol_Click(object sender, RoutedEventArgs e)
        {
            if(money >= 200)
            {
                equipment[0] = true;
                money -= 200;
                Cash.Text = money.ToString();
            }
            Pistol.IsEnabled = false;

        }

        private void Kevlar_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 600)
            {
                equipment[1] = true;
                money -= 600;
                Cash.Text = money.ToString();
            }
            Kevlar.IsEnabled = false;

        }

        private void ECM_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 200)
            {
                equipment[2] = true;
                money -= 200;
                Cash.Text = money.ToString();
            }
            ECM.IsEnabled = false;
        }

        private void Laptop_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 200)
            {
                equipment[3] = true;
                money -= 200;
                Cash.Text = money.ToString();
            }
            Laptop.IsEnabled = false;
        }

        private void Kit_Click(object sender, RoutedEventArgs e)
        {
            if (money >= 200)
            {
                equipment[4] = true;
                money -= 200;
                Cash.Text = money.ToString();
            }
            Kit.IsEnabled = false;
        }

        private void Helmet_Click(object sender, RoutedEventArgs e)
        {
            if(money >= 400)
            {
                equipment[5] = true;
                money -= 400;
                Cash.Text = money.ToString();
            }
            Helmet.IsEnabled = false;
        }
    }
}
