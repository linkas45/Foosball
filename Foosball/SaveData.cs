﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Foosball
{
    public class SaveData
    {
    
        public static void SaveDataToFile(string team1Name, string team2Name, int team1Score, int team2Score)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\Leaderboards.txt");

            if (!File.Exists(path))
                File.WriteAllText(path, String.Empty);

            string team1Data = team1Name + " " + team1Score.ToString() + " " + Environment.NewLine;
            string team2Data = team2Name + " " + team2Score.ToString() + " " + Environment.NewLine;

            try
            {
                File.AppendAllText(path, team1Data);
                File.AppendAllText(path, team2Data);
            }
            catch(InvalidOperationException ReadOnly)
            {
                MessageBox.Show("File is read only");
            }

        }

    }
}

