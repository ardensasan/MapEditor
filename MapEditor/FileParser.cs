using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Runtime.Remoting.Messaging;

namespace MapEditor
{
    class FileParser
    {
        private MapArray mp = new MapArray();
        private int x, y;
        private int[,] map;
        public void SaveToFile(SaveFileDialog saveFile,int xDimension,int yDimension,int[,] map)
        {
            saveFile.Title = "Save text Files";
            saveFile.DefaultExt = "txt";
            saveFile.Filter = "Text files (*.txt)|*.txt";
            saveFile.FilterIndex = 2;
            saveFile.FileName = "Map.txt";
            saveFile.RestoreDirectory = true;
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFile.OpenFile());
                for (y = 0; y < yDimension; y++)
                {
                    for (x = 0; x < xDimension; x++)
                    {
                        writer.Write(map[x, y].ToString() + "\t");
                    }
                    writer.Write("\n");
                }
                writer.Dispose();
                writer.Close();
            }
        }

        public int[,] OpenFile(OpenFileDialog openFileDialog)
        {
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            var fileContent = string.Empty;
            var filePath = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();
                string line = "";
                string[] numbers;
                x = 0;
                y = 0;
                bool xIsChecked = false;
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            if (!xIsChecked)
                            {
                                xIsChecked = true;
                                numbers = Regex.Split(line, @"\D+");
                                foreach (string value in numbers)
                                {
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        x++;
                                    }
                                }
                            }
                            y++;
                        }
                    }
                    map = mp.GenerateMapArray(x, y);
                }
                fileStream = openFileDialog.OpenFile();
                x = 0;
                y = 0;
                using (StreamReader sr = new StreamReader(fileStream))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        x = 0;
                        if (line != "")
                        {
                            numbers = Regex.Split(line, @"\D+");
                            foreach (string value in numbers)
                            {
                                if (!string.IsNullOrEmpty(value))
                                {
                                    map[x, y] = int.Parse(value);
                                    x++;
                                }
                            }
                            y++;
                        }
                    }
                }
            }
            return map;
        }
    }
}
