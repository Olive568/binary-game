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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string difficulty;
        string point = "";
        int minutes = 0;
        int seconds = 0;
        public Window2(string score, string diff,int time)
        {
            InitializeComponent();
            difficulty = diff;
            point = score;
            seconds = time;
            if (difficulty == "medium")
            {
                int scoring = int.Parse(point);
                scoring *= 2;
                point = scoring.ToString();
            }
            else if (difficulty == "hard")
            {
                int scoring = int.Parse(point);
                scoring *= 3;
                point = scoring.ToString();
            }
            else if (difficulty == "insane")
            {
                int scoring = int.Parse(point);
                scoring *= 4;
                point = scoring.ToString();
            }
            ScoreDisplay.Text = point;
            minutes = seconds / 60;
            seconds %= 60;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {  
            string time = minutes +": " + seconds.ToString();
            Database DB = new Database();
            List <string[]> db = DB.Read_File();
            string[] array = new string[3];
            array[0] = name.Text;
            array[1] = point;
            array[2] = time;
            db.Add(array);
            DB.Add_Ranking(db);
            this.Close();

        }
    }
}
