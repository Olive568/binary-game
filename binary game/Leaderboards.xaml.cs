﻿using System;
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
            string fontFilePath = Path.Combine(Environment.CurrentDirectory, "Tech.ttf");

            // Read data from the database
            Database DB = new Database();
            db = DB.Read_File();

            // Add data to the ListBox
            LstBox.Items.Add($"{db[0][0]}         {db[0][1]}              {db[0][2]}");
            for (int x = 1; x < db.Count; x++)
            {
                string person = "";
                for (int y = 0; y < db[x].Length; y++)
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

            // Load and apply the font to the ListBox
            if (File.Exists(fontFilePath))
            {
                FontFamily font = new FontFamily(new Uri("file:///" + fontFilePath).AbsoluteUri);
                foreach (var item in LstBox.Items)
                {
                    if (item is TextBlock textBlock)
                    {
                        textBlock.FontFamily = font;
                    }
                }
            }
            else
            {
                MessageBox.Show("Font file not found!");
            }
        }
    }
}
