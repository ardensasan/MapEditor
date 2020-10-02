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
using System.Diagnostics;

namespace MapEditor
{
    class PanelParser
    {
        List<Panel> pList = new List<Panel>();
        form_MapEditor mE;
        TileParser tp;
        private int[] coordinates = { 0, 0 };
        private int counter = 0;
        private string[] numbers;
        public List<Panel> ParsePanel(form_MapEditor mapEditorForm,int xDimension, int yDimension)
        {
            Panel panel;
            int xLocation = 12, yLocation = 98;
            for (int x = 0; x < xDimension; x++)
            {
                if (x > 0)
                {
                    xLocation += 32;
                }
                yLocation = 98;
                for (int y = 0; y < yDimension; y++)
                {
                    if (y > 0)
                    {
                        yLocation += 32;
                    }
                    panel = new Panel();
                    panel.Size = new Size(32, 32);
                    panel.Location = new Point(xLocation, yLocation);
                    panel.BackColor = Color.Gray;
                    panel.Name = "panel_" + x.ToString() + "_" + y.ToString();
                    panel.Click += map_Panel_Click;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    mapEditorForm.Controls.Add(panel);
                    pList.Add(panel);
                }
            }
            return pList;
        }

        public List<Panel> ParsePanel(form_previewForm previewForm, int xDimension, int yDimension)
        {
            Panel panel;
            int edge = 12;
            int xLocation = 0, yLocation = 0;
            for (int x = 0; x < xDimension; x++)
            {
                if (x > 0)
                {
                    xLocation += edge;
                }
                yLocation = 0;
                for (int y = 0; y < yDimension; y++)
                {
                    if (y > 0)
                    {
                        yLocation += edge;
                    }
                    panel = new Panel();
                    panel.Size = new Size(edge, edge);
                    panel.Location = new Point(xLocation, yLocation);
                    panel.BackColor = Color.Gray;
                    panel.Name = "panel_" + x.ToString() + "_" + y.ToString();
                    panel.Click += map_Panel_Click;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    previewForm.Controls.Add(panel);
                    pList.Add(panel);
                }
            }
            return pList;
        }

        private void DisplayPanelTiles(int hScrollValue,int vScrollValue)
        {
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
                //tp.IntToTile(panel, coordinates[0] + hScrollValue, coordinates[1] + vScrollValue, map, this);
            }
        }

        private void map_Panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.Gray;
            panel.BackgroundImage = mE.panel_currentTile.BackgroundImage;
            panel.BackgroundImageLayout = ImageLayout.Stretch;
            numbers = Regex.Split(panel.Name, @"\D+");
            counter = 0;
            foreach (string value in numbers)
            {
                if (!string.IsNullOrEmpty(value))
                {
                    coordinates[counter] = int.Parse(value);
                    counter++;
                }
            }
            mE.updateArray(coordinates[0], coordinates[1]);
        }
    }
}
