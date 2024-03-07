﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace binary_game
{
    internal class Database
    {
        public List<string[]> Read_File()
        {
            List<string[]> db = new List<string[]>();
            using (StreamReader sr = new StreamReader(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\Scores.csv"))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] splitter = new string[3];
                    splitter = line.Split(',');
                    db.Add(splitter);
                }
            }
            return db;
        }
        public void Add_Ranking(List<string[]> db)
        {
            if (db.Count > 2)
            {
                // Sort the list based on the scores
                for (int x = 0; x < db.Count - 1; x++)
                {
                    for (int y = 0; y < db.Count - x - 1; y++)
                    {
                        if (int.Parse(db[y][2]) < int.Parse(db[y + 1][2]))
                        {
                            string[] temp = db[y];
                            db[y] = db[y + 1];
                            db[y + 1] = temp;
                        }
                    }
                }

                // Update the ranks based on the sorted position
                for (int i = 0; i < db.Count; i++)
                {
                    db[i][0] = (i + 1).ToString(); // Update rank
                }
            }

            while (db.Count > 11)
            {
                db.RemoveAt(10);
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Luis Oliver\source\repos\binary-game\binary game\Scores.csv"))
            {
                //clearing the contents first 
                //placing the content 
                //overwriting 
                for(int i = 0; i < db.Count; i++) 
                {
                    sw.WriteLine(string.Join(",", db[i]));
                }

            }
        }
    }
}
