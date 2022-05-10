using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.src.Controls.ScrollablePanelControl
{
    public partial class ScrollablePanelTest : Form
    {
        ScrollablePanelImplementTest scrollablePanelImplementTest;

        public ScrollablePanelTest()
        {
            InitializeComponent();
            scrollablePanelImplementTest = new ScrollablePanelImplementTest();
            this.Controls.Add(scrollablePanelImplementTest);
            scrollablePanelImplementTest.Dock = DockStyle.Fill;
        }
    }
}
