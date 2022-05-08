namespace MapEditor.src.Controls.ScrollablePanelControl
{
    partial class ScrollablePanelTest
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
            this.scrollablePanel1 = new MapEditor.src.Controls.ScrollablePanelControl.ScrollablePanel();
            this.SuspendLayout();
            // 
            // scrollablePanel1
            // 
            this.scrollablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollablePanel1.Location = new System.Drawing.Point(0, 0);
            this.scrollablePanel1.Name = "scrollablePanel1";
            this.scrollablePanel1.Size = new System.Drawing.Size(800, 450);
            this.scrollablePanel1.TabIndex = 0;
            // 
            // ScrollablePanelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scrollablePanel1);
            this.Name = "ScrollablePanelTest";
            this.Text = "ScrollablePanelTest";
            this.ResumeLayout(false);

        }

        #endregion

        private ScrollablePanel scrollablePanel1;
    }
}