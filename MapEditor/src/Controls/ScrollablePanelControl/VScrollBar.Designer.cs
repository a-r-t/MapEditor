namespace MapEditor.src.Controls.ScrollablePanelControl
{
    partial class VScrollBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vScrollBarPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // vScrollBarPanel
            // 
            this.vScrollBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vScrollBarPanel.Location = new System.Drawing.Point(0, 0);
            this.vScrollBarPanel.Name = "vScrollBarPanel";
            this.vScrollBarPanel.Size = new System.Drawing.Size(17, 293);
            this.vScrollBarPanel.TabIndex = 0;
            this.vScrollBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.vScrollBarPanel_Paint);
            this.vScrollBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.vScrollBarPanel_MouseDown);
            this.vScrollBarPanel.MouseEnter += new System.EventHandler(this.vScrollBarPanel_MouseEnter);
            this.vScrollBarPanel.MouseLeave += new System.EventHandler(this.vScrollBarPanel_MouseLeave);
            this.vScrollBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.vScrollBarPanel_MouseMove);
            this.vScrollBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.vScrollBarPanel_MouseUp);
            this.vScrollBarPanel.Resize += new System.EventHandler(this.vScrollBarPanel_Resize);
            // 
            // VScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.vScrollBarPanel);
            this.Name = "VScrollBar";
            this.Size = new System.Drawing.Size(17, 293);
            this.Load += new System.EventHandler(this.VScrollBar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel vScrollBarPanel;
    }
}
