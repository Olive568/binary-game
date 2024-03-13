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
        private MediaPlayer Music = new MediaPlayer();
        private SoundPlayer player;
        public Cutscene()
        {
            InitializeComponent();
            player = new SoundPlayer(@"C:\Users\22-0042c\source\repos\binary-game\binary game\Briefing.wav");
            Music.Open(new Uri(@"C:\Users\22-0042c\source\repos\binary-game\binary game\CutMusic.wav"));
       
            cut();
        }
        async private void cut()
        {
            Music.Volume = 0.25;
            Music.Play();
            player.Play();   
        }

        private void Diff_Click(object sender, RoutedEventArgs e)
        {
            Music.Stop();
            player.Stop();
            Difficulty df = new Difficulty();
            this.Close();
            df.Show();
        }
    }
}
