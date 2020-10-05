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

        public form_previewForm(int[,] M)
        {
            InitializeComponent();
            map = M;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Down)
                {
                    if (vscroll_preview.Value < vscroll_preview.Maximum)
                    {
                        vscroll_preview.Value++;
                        scroll_preview(null, null);
                    }
                }
                if (keyData == Keys.Down)
                {
                    if (vscroll_preview.Value < vscroll_preview.Maximum)
                    {
                        vscroll_preview.Value++;
                        scroll_preview(null, null);
                    }
                }
                if (keyData == Keys.Left)
                {
                    if (hscroll_preview.Value > 0)
                    {
                        hscroll_preview.Value--;
                        scroll_preview(null, null);
                    }
                }
                if (keyData == Keys.Right)
                {
                    if (hscroll_preview.Value < hscroll_preview.Maximum)
                    {
                        hscroll_preview.Value++;
                        scroll_preview(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }

        private void scroll_preview(object sender, ScrollEventArgs e)
        {
            x = hscroll_preview.Value;
            y = vscroll_preview.Value;
            pp.UpdatePanels(x, y, map, pList);
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
