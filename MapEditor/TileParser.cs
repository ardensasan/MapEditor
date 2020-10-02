using System;
using System.Collections.Generic;
using System.Drawing;
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
        Bitmap bg = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\bg.png");
        Bitmap tile01 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile01.png");
        Bitmap tile02 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile02.png");
        Bitmap tile03 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile03.png");
        Bitmap tile04 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile04.png");
        Bitmap tile05 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile05.png");
        Bitmap tile06 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile06.png");
        Bitmap tile07 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile07.png");
        Bitmap tile08 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile08.png");
        Bitmap tile09 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile09.png");
        Bitmap tile10 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile10.png");
        Bitmap tile11 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile11.png");
        Bitmap tile12 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile12.png");
        Bitmap tile13 = new Bitmap(Application.StartupPath + "\\assets\\TinyRooms\\tile13.png");
        public void IntToTile(Panel panel,int x,int y,int[,] map)
        {
            panel.BackgroundImage = null;
            if (map[x, y] == 0)
            {
                panel.BackgroundImage = bg;
            }
            else if (map[x, y] == 1)
            {
                panel.BackgroundImage = tile01;
            }
            else if (map[x, y] == 2)
            {
                panel.BackgroundImage = tile02;
            }
            else if (map[x, y] == 3)
            {
                panel.BackgroundImage = tile03;
            }
            else if (map[x, y] == 4)
            {
                panel.BackgroundImage = tile04;
            }
            else if (map[x, y] == 5)
            {
                panel.BackgroundImage = tile05;
            }
            else if (map[x, y] == 6)
            {
                panel.BackgroundImage = tile06;
            }
            else if (map[x, y] == 7)
            {
                panel.BackgroundImage = tile07;
            }
            else if (map[x, y] == 8)
            {
                panel.BackgroundImage = tile08;
            }
            else if (map[x, y] == 9)
            {
                panel.BackgroundImage = tile09;
            }
            else if (map[x, y] == 10)
            {
                panel.BackgroundImage = tile10;
            }
            else if (map[x, y] == 11)
            {
                panel.BackgroundImage = tile11;
            }
            else if (map[x, y] == 12)
            {
                panel.BackgroundImage = tile12;
            }
            else if (map[x, y] == 13)
            {
                panel.BackgroundImage = tile13;
            }
            panel.BackgroundImageLayout = ImageLayout.Stretch;
        }

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
