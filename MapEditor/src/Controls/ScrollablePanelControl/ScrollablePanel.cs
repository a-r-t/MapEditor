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
    public partial class ScrollablePanel : UserControl, VScrollBarListener, HScrollBarListener
    {
        public readonly VScrollBar vScrollBar;
        public readonly HScrollBar hScrollBar;

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
            hScrollBar.AddListener(this);
        }

        public virtual void onVScroll(int scrollAmount)
        {
            // Console.WriteLine("You scrolled : " + scrollAmount); 
            imagePanel.Refresh();
        }

        public virtual void onHScroll(int scrollAmount)
        {
            // Console.WriteLine("You scrolled : " + scrollAmount); 
            imagePanel.Refresh();
        }

        protected virtual void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            // TODO: Override me
        }

        protected virtual void imagePanel_Resize(object sender, EventArgs e)
        {
            //imagePanel.Refresh();
        }

        protected virtual void ScrollablePanel_Resize(object sender, EventArgs e)
        {
            imagePanel.Refresh();
        }
    }
}
