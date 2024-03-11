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
using System.Media;
using System.Windows.Media;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for Cutscene.xaml
    /// </summary>
    
    public partial class Cutscene : Window
    {
        private SoundPlayer player;
        public Cutscene()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\Briefing.wav");
            cut();
        }
        async private void cut()
        {
            player.Play();   
        }

        private void Diff_Click(object sender, RoutedEventArgs e)
        {
            player.Stop();
            Difficulty df = new Difficulty();
            this.Close();
            df.Show();
        }
    }
}
