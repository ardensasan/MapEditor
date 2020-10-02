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
        private int x,y;
        private List<Panel> pList;
        private PanelParser pp = new PanelParser();
        private TileParser tp = new TileParser();

        private void hscroll_preview_Scroll(object sender, ScrollEventArgs e)
        {
            x = hscroll_preview.Value;
            pp.UpdatePanels(x, y, map, pList);
        }

        private void vscroll_preview_Scroll(object sender, ScrollEventArgs e)
        {
            y = vscroll_preview.Value;
            pp.UpdatePanels(x, y, map, pList);
        }
        public form_previewForm(int[,] M)
        {
            InitializeComponent();
            map = M;
        }

        private void Preview_Load(object sender, EventArgs e)
        {
            pList = pp.ParsePanel(this, 50, 50);
            hscroll_preview.Maximum = map.GetLength(0) - 50;
            x = hscroll_preview.Value = 0;
            vscroll_preview.Maximum = map.GetLength(1) - 50;
            y = vscroll_preview.Value = 0;
            pp.UpdatePanels(x, y, map, pList);
        }
    }
}
