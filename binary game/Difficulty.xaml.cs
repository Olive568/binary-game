using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for Difficulty.xaml
    /// </summary>
    public partial class Difficulty : Window
    {
        private SoundPlayer player;
        public Difficulty()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\DiffTheme.wav");
            player.Play();
        }

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            string easy = "easy";
            Buy w1 = new Buy(easy);
            w1.Show();
            this.Close();
        }

        private void Medium_Click(object sender, RoutedEventArgs e)
        {
            string easy = "medium";
            Buy w1 = new Buy(easy);
            w1.Show();
            this.Close();
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            string easy = "hard";
            Buy w1 = new Buy(easy);
            w1.Show();
            this.Close();
        }

        private void Insane_Click(object sender, RoutedEventArgs e)
        {
            string easy = "insane";
            Buy w1 = new Buy(easy);
            w1.Show();
            this.Close();
        }
    }
}
