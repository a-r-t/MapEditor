﻿
namespace MapEditor.src.MapTilesetEditor
{
    partial class TilesetEditor
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
            this.tilesetLabel = new System.Windows.Forms.Label();
            this.scaleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tilesetLabel
            // 
            this.tilesetLabel.AutoSize = true;
            this.tilesetLabel.Location = new System.Drawing.Point(3, 7);
            this.tilesetLabel.Name = "tilesetLabel";
            this.tilesetLabel.Size = new System.Drawing.Size(41, 13);
            this.tilesetLabel.TabIndex = 0;
            this.tilesetLabel.Text = "Tileset:";
            // 
            // scaleLabel
            // 
            this.scaleLabel.AutoSize = true;
            this.scaleLabel.Location = new System.Drawing.Point(3, 29);
            this.scaleLabel.Name = "scaleLabel";
            this.scaleLabel.Size = new System.Drawing.Size(37, 13);
            this.scaleLabel.TabIndex = 1;
            this.scaleLabel.Text = "Scale:";
            // 
            // TilesetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scaleLabel);
            this.Controls.Add(this.tilesetLabel);
            this.Name = "TilesetEditor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label tilesetLabel;
        private System.Windows.Forms.Label scaleLabel;
    }
}
