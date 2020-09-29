using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    class TileParser
    {
        private int panelValue;
        public int TileToInt(Panel panel)
        {
            if (panel.Name == "panel_bg")
            {
                panelValue = 0;
            }
            else if (panel.Name == "panel_tile01")
            {
                panelValue = 1;
            }
            else if (panel.Name == "panel_tile02")
            {
                panelValue = 2;
            }
            else if (panel.Name == "panel_tile03")
            {
                panelValue = 3;
            }
            else if (panel.Name == "panel_tile04")
            {
                panelValue = 4;
            }
            else if (panel.Name == "panel_tile05")
            {
                panelValue = 5;
            }
            else if (panel.Name == "panel_tile06")
            {
                panelValue = 6;
            }
            else if (panel.Name == "panel_tile07")
            {
                panelValue = 7;
            }
            else if (panel.Name == "panel_tile08")
            {
                panelValue = 8;
            }
            else if (panel.Name == "panel_tile09")
            {
                panelValue = 9;
            }
            else if (panel.Name == "panel_tile10")
            {
                panelValue = 10;
            }
            else if (panel.Name == "panel_tile11")
            {
                panelValue = 11;
            }
            else if (panel.Name == "panel_tile12")
            {
                panelValue = 12;
            }
            else if (panel.Name == "panel_tile13")
            {
                panelValue = 13;
            }
            return panelValue;
        }
    }
}
