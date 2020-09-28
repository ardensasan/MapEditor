using System;
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
    public partial class MapEditor : Form
    {
        public MapEditor()
        {
            InitializeComponent();
            //Panel panel = new Panel();
            //panel.Size = new Size(32, 32);
            //panel.Location = new Point(22, 66);
            //panel.BackColor = Color.Black;
            //panel1.Controls.Add(panel);
           
        }

        private void MapEditor_Load(object sender, EventArgs e)
        {
            Panel panel;
            int x = 0, y = 0, xLocation = 12, yLocation = 66;
            for (x = 0; x < 23; x++)
            {
                if (x > 0)
                {
                    xLocation += 32;
                }
                yLocation = 66;
                for (y = 0; y < 14; y++)
                {
                    if (y > 0)
                    {
                        yLocation += 32;
                    }
                    panel = new Panel();
                    panel.Size = new Size(32, 32);
                    panel.Location = new Point(xLocation, yLocation);
                    panel.BackColor = Color.Black;
                    panel.Tag = "panel_" + x.ToString() + "_" + y.ToString();
                    panel.Click += panel_Click;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                    this.Controls.Add(panel);
                }
            }
        }
        void panel_Click(object sender,EventArgs e)
        {
            Panel p = sender as Panel;
            label1.Text = p.Tag.ToString();
            p.BackgroundImage = panel_currentTile.BackgroundImage;
            p.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void panel_tile13_Click(object sender, EventArgs e)
        {

        }

        private void panel_tile_Click(object sender, EventArgs e)
        {
            Panel p = sender as Panel;
            panel_currentTile.BackgroundImage = p.BackgroundImage;
        }
    }
}
