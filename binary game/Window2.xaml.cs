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
        string point = "";
        public Window2(string score)
        {
            InitializeComponent();
            point = score;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Database DB = new Database();
            List <string[]> db = DB.Read_File();
            string[] array = new string[3];
            array[0] = db.Count().ToString();
            array[1] = name.Text;
            array[2] = point;
            DB.Add_Ranking(db);

        }
    }
}
