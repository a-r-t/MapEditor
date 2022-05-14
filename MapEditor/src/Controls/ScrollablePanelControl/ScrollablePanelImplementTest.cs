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
            Bitmap cropped = pikaballoon.Clone(new Rectangle(hScrollBar.HScrollOffset, vScrollBar.VScrollOffset, imagePanel.Width, imagePanel.Height), pikaballoon.PixelFormat);
            e.Graphics.DrawImage(cropped, new Point(0, 0));
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
            int vScrollAmountRequired = pikaballoon.Height - imagePanel.Height;
            int vScrollBarSize = (vScrollBar.Height - 36) - vScrollAmountRequired;

            vScrollBar.VScrollBarHeight = vScrollBarSize;

            int hScrollAmountRequired = pikaballoon.Width - imagePanel.Width;
            int hScrollBarSize = (hScrollBar.Width - 36) - hScrollAmountRequired;

            hScrollBar.HScrollBarWidth = hScrollBarSize;
        }
    }
}
