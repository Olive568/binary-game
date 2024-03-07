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
            using (StreamReader sr = new StreamReader(@"C:\Users\22-0042c\source\repos\binary-game\binary game\Scores.csv"))
            {
                string line = sr.ReadLine();
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
                for (int x = 1; x < db.Count; x++)
                {
                    for (int y = 1; y < db.Count - 1; y++)
                    {
                        string[] temp = db[y];
                        if (int.Parse(db[y][2]) < int.Parse(db[y + 1][2]))
                        {
                            db[y] = db[y + 1];
                            db[y + 1] = temp;
                        }
                    }
                }
            }
            while(db.Count > 11)
            {
                db.RemoveAt(10);
            }
            using(StreamWriter sw = new StreamWriter(@"C:\Users\22-0042c\source\repos\binary-game\binary game\Scores.csv"))
            {
                //clearing the contents first 
                //placing the content 
                //overwriting 
                foreach (string[] user in db)
                {
                    sw.WriteLine(string.Join(",", user));
                    sw.WriteLine();
                }
            }
        }
    }
}
