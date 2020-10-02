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
using System.IO;

namespace MapEditor
{
    public partial class form_MapEditor : Form
    {
        private List<Panel> pList = new List<Panel>();
        private MapArray mp;
        private form_previewForm pF;
        private TileParser tp;
        private PanelParser pp;
        private FileParser fp;
        private int x=50, y=50,panelValue = 0;
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
            pF = new form_previewForm(map);
            cmbox_yDimension.SelectedIndex = 0;
            cmbox_xDimension.SelectedIndex = 0;
            cmbox_xDimension.SelectedItem = 50;
            cmbox_yDimension.SelectedItem = 50;
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            try
            {
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_yDimension.SelectedItem.ToString());
                pList.Clear();
                pp = new PanelParser();
                tp = new TileParser();
                fp = new FileParser();
                pList = pp.ParsePanel(this,23,13);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel_tile_Click(object sender, EventArgs e)
        {
            try
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
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void cmbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_yDimension.SelectedItem.ToString());
                mp = new MapArray();
                map = mp.GenerateMapArray(x, y);
                hscroll_map.Maximum = x - 23;
                vscroll_map.Maximum = y - 13;
                vscroll_map.Value = 0;
                hscroll_map.Value = 0;
                scroll_Map(sender,e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_saveFile_Click(object sender, EventArgs e)
        {
            try
            {
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_yDimension.SelectedItem.ToString());
                SaveFileDialog saveFile = new SaveFileDialog();
                fp.SaveToFile(saveFile, x, y, map);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_openFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                int[,] tempMap = fp.OpenFile(openFileDialog);
                cmbox_xDimension.SelectedItem = tempMap.GetLength(0).ToString();
                cmbox_yDimension.SelectedItem = tempMap.GetLength(1).ToString();
                x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                y = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
                map = mp.GenerateMapArray(x, y);
                map = tempMap;
                hscroll_map.Value = 0;
                vscroll_map.Value = 0;
                scroll_Map(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbox_xDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = Int32.Parse(cmbox_xDimension.SelectedItem.ToString());
            try
            {
                mp = new MapArray();
                map = mp.GenerateMapArray(x, y);
                hscroll_map.Maximum = x - 23;
                vscroll_map.Maximum = y - 13;
                scroll_Map(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_preview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Map preview may take some time");
            pF.ShowDialog();
        }

        private void yDimension_SelectedIndexChanged(object sender, EventArgs e)
        {
            y = Int32.Parse(cmbox_yDimension.SelectedItem.ToString());
            try
            {
                mp = new MapArray();
                map = mp.GenerateMapArray(x, y);
                hscroll_map.Maximum = x - 23;
                vscroll_map.Maximum = y - 13;
                scroll_Map(sender, e);
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
            try
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
                    tp.IntToTile(panel, coordinates[0] + hscrollValue, coordinates[1] + vscrollValue, map);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
