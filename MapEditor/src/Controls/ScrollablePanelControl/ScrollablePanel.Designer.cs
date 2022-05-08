namespace MapEditor.src.Controls.ScrollablePanelControl
{
    partial class ScrollablePanel
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
            this.imagePanel = new System.Windows.Forms.Panel();
            this.hScrollBarContainer = new System.Windows.Forms.Panel();
            this.vScrollBarContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // imagePanel
            // 
            this.imagePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imagePanel.Location = new System.Drawing.Point(0, 0);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(364, 293);
            this.imagePanel.TabIndex = 0;
            this.imagePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.imagePanel_Paint);
            // 
            // hScrollBarContainer
            // 
            this.hScrollBarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBarContainer.BackColor = System.Drawing.SystemColors.Control;
            this.hScrollBarContainer.Location = new System.Drawing.Point(0, 293);
            this.hScrollBarContainer.Name = "hScrollBarContainer";
            this.hScrollBarContainer.Size = new System.Drawing.Size(364, 17);
            this.hScrollBarContainer.TabIndex = 1;
            // 
            // vScrollBarContainer
            // 
            this.vScrollBarContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBarContainer.Location = new System.Drawing.Point(364, 0);
            this.vScrollBarContainer.Name = "vScrollBarContainer";
            this.vScrollBarContainer.Size = new System.Drawing.Size(17, 310);
            this.vScrollBarContainer.TabIndex = 2;
            // 
            // ScrollablePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.vScrollBarContainer);
            this.Controls.Add(this.hScrollBarContainer);
            this.Controls.Add(this.imagePanel);
            this.Name = "ScrollablePanel";
            this.Size = new System.Drawing.Size(380, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel hScrollBarContainer;
        private System.Windows.Forms.Panel vScrollBarContainer;
    }
}
