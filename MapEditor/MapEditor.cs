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
        private MapArray mp;
        private TileParser tp;
        private PanelParser pp;
        private int x, y,panelValue = 0;
        private int[,] map;
        private string[] numbers;
        private int[] coordinates = { 0, 0 };
        private int counter = 0;
        private int currentTileNum = 0;
        private int hscrollValue;
        private int vscrollValue;
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
            tp = new TileParser();
            pList = pp.ParsePanel(this);
        }

        private void panel_tile_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel_currentTile.BackgroundImage = panel.BackgroundImage;
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

        private void cmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                mp = new MapArray();
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                map = mp.GenerateMapArray(x,y);
                hscroll_map.Maximum = x - 23;
                vscroll_map.Maximum = y - 13;
                scroll_Map(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void updateArray(int i,int j)
        {
            i += hscroll_map.Value;
            map[i,j] = currentTileNum;
        }

        private void scroll_Map(object sender, EventArgs e)
        {
            hscrollValue = Int32.Parse(hscroll_map.Value.ToString());
            vscrollValue = Int32.Parse(vscroll_map.Value.ToString());
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
                tp.IntToTile(panel, coordinates[0] + hscrollValue, coordinates[1] + vscrollValue, map, this);
            }
        }

    }
}
