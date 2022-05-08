using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.Controls.ScrollablePanelControl
{
    public partial class ScrollablePanel : UserControl, VScrollBarListener
    {
        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;

        public ScrollablePanel()
        {
            InitializeComponent();
            imagePanel.DoubleBuffered(true);
            
            imagePanel.BackColor = Color.White;

            vScrollBar = new VScrollBar();
            vScrollBarContainer.Controls.Add(vScrollBar);
            vScrollBar.Location = new Point(0, 0);
            vScrollBar.Dock = DockStyle.Fill;
            vScrollBar.AddListener(this);

            hScrollBar = new HScrollBar();
            hScrollBarContainer.Controls.Add(hScrollBar);
            hScrollBar.Location = new Point(0, 0);
            hScrollBar.Dock = DockStyle.Fill;

        }

        public void onVScroll(int scrollAmount)
        {
            // Console.WriteLine("You scrolled : " + scrollAmount); 
        }

        protected virtual void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            // TODO: Override me
        }

        

        
    }
}
