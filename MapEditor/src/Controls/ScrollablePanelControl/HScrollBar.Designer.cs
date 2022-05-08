namespace MapEditor.src.Controls.ScrollablePanelControl
{
    partial class HScrollBar
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
            this.hScrollBarPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // hScrollBarPanel
            // 
            this.hScrollBarPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hScrollBarPanel.Location = new System.Drawing.Point(0, 0);
            this.hScrollBarPanel.Name = "hScrollBarPanel";
            this.hScrollBarPanel.Size = new System.Drawing.Size(293, 17);
            this.hScrollBarPanel.TabIndex = 0;
            this.hScrollBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hScrollBarPanel_Paint);
            this.hScrollBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseDown);
            this.hScrollBarPanel.MouseEnter += new System.EventHandler(this.hScrollBarPanel_MouseEnter);
            this.hScrollBarPanel.MouseLeave += new System.EventHandler(this.hScrollBarPanel_MouseLeave);
            this.hScrollBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseMove);
            this.hScrollBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseUp);
            // 
            // HScrollBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.Controls.Add(this.hScrollBarPanel);
            this.Name = "HScrollBar";
            this.Size = new System.Drawing.Size(293, 17);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel hScrollBarPanel;
    }
}
