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
using PSA2.src.ExtentionMethods;
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>
    {
        private Map map;

        public MapBuilder()
        {
            InitializeComponent();
            //mapPanel.DoubleBuffered(true);
            
            map = new Map();
            map.LoadMap("./Resources/MapFiles/test_map.txt", new Tileset("./Resources/Tilesets/CommonTileset.png", 16, 16, 3));
            DrawMap();
            widthLabel.Text = $"Width: {map.Width}";
            heightLabel.Text = $"Height: {map.Height}";
            heightLabel.Location = new Point(widthLabel.Location.X + widthLabel.Width + 10, heightLabel.Location.Y);
        }

        private void DrawMap()
        {
            mapPictureBox.Image = new Bitmap(map.WidthInPixels, map.HeightInPixels);
            mapPictureBox.ClientSize = mapPictureBox.Image.Size;
            using (Graphics graphics = Graphics.FromImage(mapPictureBox.Image))
            {
                map.Paint(graphics);
            }
        }

        private void MapBuilder_Paint(object sender, PaintEventArgs e)
        {
            //map.Paint(e.Graphics);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
        }

        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            //map.Paint(e.Graphics);
        }

        private void mapPanel_Scroll(object sender, ScrollEventArgs e)
        {
            //mapPanel.Invalidate();
        }

        private void mapPictureBox_Paint(object sender, PaintEventArgs e)
        {

            //map.Paint(e.Graphics);

        }
    }
}
