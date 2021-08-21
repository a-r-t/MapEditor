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
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, TilePickerListener
    {
        private Map map;
        private bool mapRepaint = false;
        private Point hoveredTileIndex;
        private Tile selectedTile;

        public MapBuilder()
        {
            InitializeComponent();
            //mapPanel.DoubleBuffered(true);
            
            map = new Map();
            map.LoadMap("./Resources/MapFiles/test_map.txt");
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
            if (mapRepaint)
            {
                map.Paint(e.Graphics);
                if (hoveredTileIndex.X != -1 && hoveredTileIndex.Y != -1)
                {
                    Pen pen = new Pen(Color.Yellow, 5);
                    e.Graphics.DrawRectangle(
                        pen,
                        new Rectangle(
                            hoveredTileIndex.X * map.MapTileWidth + 3,
                            hoveredTileIndex.Y * map.MapTileHeight + 3,
                            map.MapTileWidth - 5,
                            map.MapTileHeight - 5
                        )
                    );
                }

                mapRepaint = false;
            }

        }

        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            hoveredTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
            selectedTileIndexLabel.Text = $"X: {hoveredTileIndex.X}, Y: {hoveredTileIndex.Y}";
            selectedTileIndexLabel.Location = new Point(heightLabel.Location.X + heightLabel.Width + 10, selectedTileIndexLabel.Location.Y);

            mapRepaint = true;
            mapPictureBox.Invalidate();
        }

        private void mapPictureBox_MouseLeave(object sender, EventArgs e)
        {
            selectedTileIndexLabel.Visible = false;
            hoveredTileIndex = new Point(-1, -1);

            mapRepaint = true;
            mapPictureBox.Invalidate();
        }

        private void mapPictureBox_MouseEnter(object sender, EventArgs e)
        {
            selectedTileIndexLabel.Visible = true;
        }

        public void OnTileSelect(Tile tile)
        {
            selectedTile = tile;
        }

        private void mapPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedTile != null)
            {

            }
        }
    }
}
