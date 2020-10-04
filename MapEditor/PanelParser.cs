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
using System.Timers;

namespace MapEditor
{
    class PanelParser
    {
        List<Panel> pList = new List<Panel>();
        form_MapEditor mE;
        TileParser tp;
        private int x, y;
        private int[] coordinates = { 0, 0 };
        private int counter = 0;
        private string[] numbers;
        private bool dragMode = false;
        public List<Panel> ParsePanel(form_MapEditor mapEditorForm,int xDimension, int yDimension)
        {
            mE = mapEditorForm;
            Panel panel;
            int xLocation = 12, yLocation = 98;
            for (x = 0; x < xDimension; x++)
            {
                if (x > 0)
                {
                    xLocation += 32;
                }
                yLocation = 98;
                for (y = 0; y < yDimension; y++)
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
                    panel.MouseEnter += new EventHandler(wiew);
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
            tp = new TileParser();
            const int EDGE = 12;
            const int LOCATION = 2;
            int xLocation = LOCATION, yLocation = LOCATION;
            for (int x = 0; x < xDimension; x++)
            {
                if (x > 0)
                {
                    xLocation += EDGE;
                }
                yLocation = LOCATION;
                for (int y = 0; y < yDimension; y++)
                {
                    if (y > 0)
                    {
                        yLocation += EDGE;
                    }
                    panel = new Panel();
                    panel.Size = new Size(EDGE, EDGE);
                    panel.Location = new Point(xLocation, yLocation);
                    panel.BackColor = Color.Gray;
                    panel.Name = "panel_" + x.ToString() + "_" + y.ToString();
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    previewForm.Controls.Add(panel);
                    pList.Add(panel);
                }
            }
            return pList;
        }

        public void UpdatePanels(int hScrollValue,int vScrollValue,int[,] m,List<Panel> formPanels)
        {
            tp = new TileParser();
            x = hScrollValue;
            y = vScrollValue;
            try
            {
                int[] coordinates = { 0, 0 };
                string[] numbers;
                int counter = 0;
                foreach (Panel panel in formPanels)
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
                    tp.IntToTile(panel, coordinates[0] + x, coordinates[1] + y, m);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void SetMode(int mode)
        {
            dragMode = Convert.ToBoolean(mode);
        }

        private void wiew(object sender, EventArgs e)
        {
            if (dragMode)
            {
                map_Panel_Click(sender, e);
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
