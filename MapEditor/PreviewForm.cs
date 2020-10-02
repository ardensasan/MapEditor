using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class form_previewForm : Form
    {
        private int[,] map;
        private int x,y, xLocation = 0,yLocation = 0;
        private int edge = 12;
        private List<Panel> pList;
        private TileParser tp = new TileParser();
        private PanelParser pp = new PanelParser();
        public form_previewForm(int[,] M)
        {
            InitializeComponent();
            map = M;
            pList = pp.ParsePanel(this, 50, 50);
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            Panel p;
            pList = new List<Panel>();
            try
            {
                //int[] coordinates = { 0, 0 };
                //string[] numbers;
                //int counter = 0;
                //foreach (Panel panel in pList)
                //{
                //    counter = 0;
                //    numbers = Regex.Split(panel.Name, @"\D+");
                //    foreach (string value in numbers)
                //    {
                //        if (!string.IsNullOrEmpty(value))
                //        {
                //            coordinates[counter] = int.Parse(value);
                //            counter++;
                //        }
                //    }
                //    counter = 0;
                //    tp.IntToTile(panel, coordinates[0], coordinates[1], map);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
