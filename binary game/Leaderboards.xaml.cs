using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media;


namespace binary_game
{
    public partial class Leaderboards : Window
    {
        List<string[]> db = new List<string[]>();

        public Leaderboards()
        {
            InitializeComponent();

            // Read data from the database
            Database DB = new Database();
            db = DB.Read_File();

            // Add data to the ListView
            foreach (string[] entry in db)
            {
                ListViewItem item = new ListViewItem();
                item.Content = new { Name = entry[0], Score = entry[1], Time = entry[2] };
                ListViewLeaderboard.Items.Add(item);
            }
        }
    }
}