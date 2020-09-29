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
    class PanelParser:Form
    {
        List<Panel> pList = new List<Panel>();
        MapEditor.form_MapEditor mE;
        private int[] coordinates = { 0, 0 };
        private int counter = 0;
        private string[] numbers;
        public List<Panel> ParsePanel(MapEditor.form_MapEditor mapEditorForm)
        {
            mE = mapEditorForm;
            Panel panel;
            int xLocation = 12, yLocation = 66;
            for (int x = 0; x < 23; x++)
            {
                if (x > 0)
                {
                    xLocation += 32;
                }
                yLocation = 66;
                for (int y = 0; y < 14; y++)
                {
                    if (y > 0)
                    {
                        yLocation += 32;
                    }
                    panel = new Panel();
                    panel.Size = new Size(32, 32);
                    panel.Location = new Point(xLocation, yLocation);
                    panel.BackColor = Color.White;
                    panel.Name = "panel_" + x.ToString() + "_" + y.ToString();
                    panel.Click += panel_Click;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    mapEditorForm.Controls.Add(panel);
                    pList.Add(panel);
                }
            }
            return pList;
        }
        private void panel_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = Color.Black;
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
