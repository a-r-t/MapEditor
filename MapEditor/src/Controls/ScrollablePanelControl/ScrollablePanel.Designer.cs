﻿namespace MapEditor.src.Controls.ScrollablePanelControl
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
            this.hScrollBarPanel = new System.Windows.Forms.Panel();
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
            // hScrollBarPanel
            // 
            this.hScrollBarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBarPanel.BackColor = System.Drawing.Color.Gray;
            this.hScrollBarPanel.Location = new System.Drawing.Point(0, 293);
            this.hScrollBarPanel.Name = "hScrollBarPanel";
            this.hScrollBarPanel.Size = new System.Drawing.Size(364, 17);
            this.hScrollBarPanel.TabIndex = 1;
            this.hScrollBarPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hScrollBarPanel_Paint);
            this.hScrollBarPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseDown);
            this.hScrollBarPanel.MouseEnter += new System.EventHandler(this.hScrollBarPanel_MouseEnter);
            this.hScrollBarPanel.MouseLeave += new System.EventHandler(this.hScrollBarPanel_MouseLeave);
            this.hScrollBarPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseMove);
            this.hScrollBarPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hScrollBarPanel_MouseUp);
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
            this.Controls.Add(this.hScrollBarPanel);
            this.Controls.Add(this.imagePanel);
            this.Name = "ScrollablePanel";
            this.Size = new System.Drawing.Size(380, 310);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Panel hScrollBarPanel;
        private System.Windows.Forms.Panel vScrollBarContainer;
    }
}