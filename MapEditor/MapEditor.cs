using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class form_MapEditor : Form
    {
        private List<Panel> pList = new List<Panel>();
        private int xElements = 22,yElements = 13;
        private MapArray mp;
        private TileParser tp;
        private PanelParser pp;
        private int x, y,panelValue = 0;
        private int[,] map;
        private string[] numbers;
        private int[] coordinates = { 0, 0 };
        private int counter = 0;
        public form_MapEditor()
        {
            InitializeComponent();
            cmbox_xDimension.SelectedIndex = 0;
            cmbox_yDimension.SelectedIndex = 0;

        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            pList.Clear();
            pp = new PanelParser();
            pList = pp.ParsePanel(this);
        }

        //private void panel_Click(object sender,EventArgs e)
        //{
        //    Panel panel = sender as Panel;
        //    panel.BackColor = Color.Black;
        //    panel.BackgroundImage = panel_currentTile.BackgroundImage;
        //    panel.BackgroundImageLayout = ImageLayout.Stretch;
        //    Console.WriteLine(panel.BackgroundImage.ToString());
        //    numbers = Regex.Split(panel.Name, @"\D+");
        //    counter = 0;
        //    foreach (string value in numbers)
        //    {
        //        if (!string.IsNullOrEmpty(value))
        //        {
        //            int i = int.Parse(value);
        //            coordinates[counter] = i;
        //            counter++;
        //        }
        //    }
        //    updateArray(coordinates[0], coordinates[1]);
        //}
        private void panel_tile_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel_currentTile.BackgroundImage = panel.BackgroundImage;
            tp = new TileParser();
            panelValue = tp.TileToInt(panel);
        }

        private void cmbox_xDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mp = new MapArray();
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                map = mp.GenerateMapArray(x,y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbox_yDimension_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void updateArray(int i,int j)
        {
            i += hscroll_map.Value;
            map[i,j] = 1;
        }
        private void hscroll_map_Scroll(object sender, ScrollEventArgs e)
        {
            int hscrollValue = Int32.Parse(hscroll_map.Value.ToString());
            string[] numbers;
            int[] coordinates = { 0, 0 };
            int number,counter = 0;
            foreach (Panel panel in pList)
            {
                  Console.WriteLine(panel.Name);
                counter = 0;
                numbers = Regex.Split(panel.Name, @"\D+");
                foreach (string value in numbers)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        number = int.Parse(value);
                        coordinates[counter] = number;
                        counter++;
                    }
                }
                counter = 0;
                if (map[coordinates[0]+ hscrollValue, coordinates[1]] == 0)
                {
                    Console.WriteLine("{0},{0}", coordinates[0], coordinates[1]);
                    panel.BackColor = Color.Black;
                    panel.BackgroundImage = null;
                }
                else if (map[coordinates[0] + hscrollValue, coordinates[1]] == 1)
                {
                    panel.BackColor = Color.White;
                }
            }
            label1.Text = hscroll_map.Value.ToString();
        }
    }
}
