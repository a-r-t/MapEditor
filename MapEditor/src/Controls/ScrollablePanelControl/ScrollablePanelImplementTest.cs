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

        public ScrollablePanelImplementTest()
        {
            InitializeComponent();
            //vScrollBar.VScrollBarHeight = 
        }

        protected override void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            Bitmap cropped = pikaballoon.Clone(new Rectangle(hScrollBar.HScrollOffset, vScrollBar.VScrollOffset, imagePanel.Width, imagePanel.Height), pikaballoon.PixelFormat);
            e.Graphics.DrawImage(cropped, new Point(0, 0));
        }


    }
}
