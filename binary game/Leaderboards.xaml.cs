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
    /// Interaction logic for Leaderboards.xaml
    /// </summary>
    public partial class Leaderboards : Window
    {
        List<string[]> db = new List<string[]>();
        public Leaderboards()
        {
            InitializeComponent();
            Database DB = new Database();
            db = DB.Read_File();
            LstBox.Items.Add(db[0][0] + "         "  + db[0][1] + "              " + db[0][2]);
            for(int x = 1; x < db.Count; x++)
            {
                string person = "";
                for(int y = 0; y < db[x].Length; y++)
                {
                    if (y == 0 && db[x][y].Length > 6)
                    {
                        person += db[x][y] + "\t";
                    }
                    else
                    {
                        person += db[x][y] + "\t" + "    ";
                    }
                    
                    
                }
                LstBox.Items.Add($"{person}");
            }
 
        }
    }
}
