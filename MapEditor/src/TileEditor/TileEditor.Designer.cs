namespace MapEditor.src.TileEditor
{
    partial class TileEditor
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
            this.mapPictureBox = new System.Windows.Forms.PictureBox();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.selectedTileIndexLabel = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tilePickerPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).BeginInit();
            this.mapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mapPictureBox
            // 
            this.mapPictureBox.BackColor = System.Drawing.Color.Black;
            this.mapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.mapPictureBox.Name = "mapPictureBox";
            this.mapPictureBox.Size = new System.Drawing.Size(571, 378);
            this.mapPictureBox.TabIndex = 0;
            this.mapPictureBox.TabStop = false;
            this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPictureBox_Paint);
            this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseDown);
            this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
            this.mapPictureBox.MouseLeave += new System.EventHandler(this.mapPictureBox_MouseLeave);
            this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseMove);
            this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseUp);
            // 
            // mapPanel
            // 
            this.mapPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapPanel.AutoScroll = true;
            this.mapPanel.BackColor = System.Drawing.Color.Black;
            this.mapPanel.Controls.Add(this.mapPictureBox);
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(550, 378);
            this.mapPanel.TabIndex = 1;
            // 
            // widthLabel
            // 
            this.widthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.widthLabel.AutoSize = true;
            this.widthLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.widthLabel.Location = new System.Drawing.Point(3, 383);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(41, 14);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Width:";
            // 
            // heightLabel
            // 
            this.heightLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.heightLabel.AutoSize = true;
            this.heightLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.heightLabel.Location = new System.Drawing.Point(47, 383);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(45, 14);
            this.heightLabel.TabIndex = 3;
            this.heightLabel.Text = "Height:";
            // 
            // selectedTileIndexLabel
            // 
            this.selectedTileIndexLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectedTileIndexLabel.AutoSize = true;
            this.selectedTileIndexLabel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedTileIndexLabel.Location = new System.Drawing.Point(98, 383);
            this.selectedTileIndexLabel.Name = "selectedTileIndexLabel";
            this.selectedTileIndexLabel.Size = new System.Drawing.Size(35, 14);
            this.selectedTileIndexLabel.TabIndex = 4;
            this.selectedTileIndexLabel.Text = "X: , Y:";
            this.selectedTileIndexLabel.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.selectedTileIndexLabel);
            this.splitContainer1.Panel1.Controls.Add(this.widthLabel);
            this.splitContainer1.Panel1.Controls.Add(this.heightLabel);
            this.splitContainer1.Panel1.Controls.Add(this.mapPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tilePickerPanel);
            this.splitContainer1.Size = new System.Drawing.Size(728, 400);
            this.splitContainer1.SplitterDistance = 552;
            this.splitContainer1.TabIndex = 5;
            // 
            // tilePickerPanel
            // 
            this.tilePickerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tilePickerPanel.Location = new System.Drawing.Point(0, 0);
            this.tilePickerPanel.Name = "tilePickerPanel";
            this.tilePickerPanel.Size = new System.Drawing.Size(172, 400);
            this.tilePickerPanel.TabIndex = 0;
            // 
            // TileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TileEditor";
            this.Size = new System.Drawing.Size(728, 400);
            this.Load += new System.EventHandler(this.MapBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapPictureBox)).EndInit();
            this.mapPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox mapPictureBox;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label selectedTileIndexLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel tilePickerPanel;
    }
}
