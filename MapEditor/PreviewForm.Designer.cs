namespace MapEditor
{
    partial class form_previewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.hscroll_preview = new System.Windows.Forms.HScrollBar();
            this.vscroll_preview = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // hscroll_preview
            // 
            this.hscroll_preview.LargeChange = 1;
            this.hscroll_preview.Location = new System.Drawing.Point(0, 605);
            this.hscroll_preview.Maximum = 1000;
            this.hscroll_preview.Name = "hscroll_preview";
            this.hscroll_preview.Size = new System.Drawing.Size(620, 20);
            this.hscroll_preview.TabIndex = 2;
            this.hscroll_preview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_preview);
            // 
            // vscroll_preview
            // 
            this.vscroll_preview.LargeChange = 1;
            this.vscroll_preview.Location = new System.Drawing.Point(605, 0);
            this.vscroll_preview.Name = "vscroll_preview";
            this.vscroll_preview.Size = new System.Drawing.Size(20, 600);
            this.vscroll_preview.TabIndex = 3;
            this.vscroll_preview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scroll_preview);
            // 
            // form_previewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(634, 631);
            this.Controls.Add(this.vscroll_preview);
            this.Controls.Add(this.hscroll_preview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "form_previewForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Preview";
            this.Load += new System.EventHandler(this.Preview_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.HScrollBar hscroll_preview;
        private System.Windows.Forms.VScrollBar vscroll_preview;
    }
}