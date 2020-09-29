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
        Bitmap bg, tile01;
        private int counter = 0;
        private int currentTileNum = 0;
        public form_MapEditor()
        {
            InitializeComponent();
            cmbox_xDimension.SelectedIndex = 0;
            cmbox_yDimension.SelectedIndex = 0;
            bg = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\bg.png");
            tile01 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile01.png");
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
            numbers = Regex.Split(panel.Name, @"\D+");
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    currentTileNum = int.Parse(value);
                }
            }
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
                hscroll_map.Maximum = x - 23;
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
            map[i,j] = currentTileNum;
        }
        private void hscroll_map_Scroll(object sender, ScrollEventArgs e)
        {
            int hscrollValue = Int32.Parse(hscroll_map.Value.ToString());
            label1.Text = hscroll_map.Value.ToString();
            counter = 0;
            foreach (Panel panel in pList)
            {
                counter = 0;
                numbers = Regex.Split(panel.Name, @"\D+");
                foreach (string value in numbers)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        coordinates[counter] = int.Parse(value);
                        counter++;
                    }
                }
                counter = 0;
                tp.IntToTile(panel, coordinates[0]+hscrollValue, coordinates[1],map, this);
                //if (map[coordinates[0]+ hscrollValue, coordinates[1]] == 0)
                //{
                //    panel.BackgroundImage = bg;
                //    //panel.BackgroundImage = panel_bg.BackgroundImage;
                //}
                //else if (map[coordinates[0] + hscrollValue, coordinates[1]] == 1)
                //{
                //    panel.BackgroundImage = tile01;
                //}
            }
        }
    }
}
