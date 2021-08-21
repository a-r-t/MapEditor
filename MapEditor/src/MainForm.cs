using MapEditor.src.MapBuilder;
using MapEditor.src.MapList;
using MapEditor.src.TilePicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MainForm : Form
    {
        private MapBuilder mapBuilder;
        private MapList mapList;
        private TilePicker tilePicker;

        public MainForm()
        {
            InitializeComponent();
            mapBuilder = new MapBuilder();
            mapList = new MapList();
            tilePicker = new TilePicker();

            mapBuilderPanel.Controls.Add(mapBuilder);
            mapBuilder.Dock = DockStyle.Fill;

            mapListPanel.Controls.Add(mapList);
            mapList.Dock = DockStyle.Fill;

            tilePickerPanel.Controls.Add(tilePicker);
            tilePicker.Dock = DockStyle.Fill;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //tilePicker.SetupTilePicker();
            //tilePicker.TilePickerRepaint = true;
            //tilePicker.Invalidate();
        }
    }
}
