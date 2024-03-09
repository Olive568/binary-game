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

    public partial class MainWindow : Window
    {
        //:\Users\22-0042c\source\repos\binary-game\binary game
        //@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\BuySound.wav"
        private SoundPlayer player;
        public MainWindow()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\Theme.wav");
            player.Play();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Difficulty w1 = new Difficulty();
            w1.Show();
            this.Close();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Leaderboards ld = new Leaderboards();
            ld.Show();
            this.Close();
        }
    }
}
