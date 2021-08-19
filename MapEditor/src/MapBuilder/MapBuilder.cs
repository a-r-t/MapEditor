using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.TilePicker;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>
    {
        private Map map;

        public MapBuilder()
        {
            InitializeComponent();
            map = new Map();
            map.LoadMap("./Resources/MapFiles/test_map.txt", new Tileset("./Resources/Tilesets/CommonTileset.png", 16, 16, 3));
        }

        private void MapBuilder_Paint(object sender, PaintEventArgs e)
        {
            //map.Paint(e.Graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            map.Paint(e.Graphics);
        }
    }
}
