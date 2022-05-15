using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.src.Controls.ScrollablePanelControl
{
    public partial class ScrollablePanelImplementTest : ScrollablePanel
    {
        Bitmap pikaballoon = new Bitmap(@"E:/Documents/pikaballoon.png");
        //Bitmap pikaballoon = new Bitmap(@"E:/Documents/redbox.png");
        public ScrollablePanelImplementTest()
        {
            InitializeComponent();
        }

        protected override void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Bitmap cropped = pikaballoon.Clone(new Rectangle(hScrollBar.HScrollOffset, vScrollBar.VScrollOffset, imagePanel.Width, imagePanel.Height), pikaballoon.PixelFormat);
                e.Graphics.DrawImage(cropped, new Point(0, 0));
            }
            catch (Exception ex)
            {

            }
        }

        private void ScrollablePanelImplementTest_Load(object sender, EventArgs e)
        {
            updateScrollBarSize();
        }

        protected override void imagePanel_Resize(object sender, EventArgs e)
        {
            updateScrollBarSize();
            base.imagePanel_Resize(sender, e);
        }

        private void updateScrollBarSize()
        {
            // v scroll
            int vScrollAmountRequired = pikaballoon.Height - imagePanel.Height;
            int vScrollBarSize = (vScrollBar.Height - 36) - vScrollAmountRequired;

            if (vScrollBarSize < 20)
            {
                int difference = 20 - vScrollBarSize;
                double dragScrollOffset = vScrollAmountRequired / (double)(vScrollAmountRequired - difference);
                vScrollBar.MouseDragScrollOffset = dragScrollOffset;
                vScrollBarSize = 20;
            }
            else
            {
                vScrollBar.MouseDragScrollOffset = 1;
            }
            vScrollBar.VScrollBarHeight = vScrollBarSize;

            // h scroll
            int hScrollAmountRequired = pikaballoon.Width - imagePanel.Width;
            int hScrollBarSize = (hScrollBar.Width - 36) - hScrollAmountRequired;
            if (hScrollBarSize < 20)
            {
                int difference = 20 - hScrollBarSize;
                double dragScrollOffset = hScrollAmountRequired / (double)(hScrollAmountRequired - difference);
                hScrollBar.MouseDragScrollOffset = dragScrollOffset;
                hScrollBarSize = 20;
            }
            else
            {
                hScrollBar.MouseDragScrollOffset = 1;
            }

            hScrollBar.HScrollBarWidth = hScrollBarSize;
        }
    }
}
