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
using MapEditor.src.MapList;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, TilePickerListener, MapListListener
    {
        private Map map;
        private Point hoveredTileIndex;
        private Tile selectedTile;

        public MapBuilder()
        {
            InitializeComponent();        
        }

        private void MapBuilder_Load(object sender, EventArgs e)
        {
            mapPictureBox.ClientSize = new Size(0, 0);
        }

        private void mapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (map != null)
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
            }
        }

        private void mapPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (map != null)
            {
                hoveredTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                selectedTileIndexLabel.Text = $"X: {hoveredTileIndex.X}, Y: {hoveredTileIndex.Y}";
                selectedTileIndexLabel.Location = new Point(heightLabel.Location.X + heightLabel.Width + 10, selectedTileIndexLabel.Location.Y);

                if (e.Button == MouseButtons.Left)
                {
                    if (selectedTile != null)
                    {
                        Point selectedTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                        int convertedTileIndex = map.GetConvertedIndex(selectedTileIndex.X, selectedTileIndex.Y);
                        if (convertedTileIndex >= 0 && convertedTileIndex < map.Width * map.Height)
                        {
                            Tile tileToReplace = map.GetMapTile(selectedTileIndex.X, selectedTileIndex.Y);
                            tileToReplace.Index = selectedTile.Index;
                            tileToReplace.Image = (Bitmap)selectedTile.Image.Clone();
                        }
                    }
                }

                mapPictureBox.Invalidate();
            }
        }

        private void mapPictureBox_MouseLeave(object sender, EventArgs e)
        {
            selectedTileIndexLabel.Visible = false;
            hoveredTileIndex = new Point(-1, -1);

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
            if (e.Button == MouseButtons.Left)
            {
                if (selectedTile != null)
                {
                    Point selectedTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                    int convertedTileIndex = map.GetConvertedIndex(selectedTileIndex.X, selectedTileIndex.Y);

                    if (convertedTileIndex >= 0 && convertedTileIndex < map.Width * map.Height)
                    {
                        Tile tileToReplace = map.GetMapTile(selectedTileIndex.X, selectedTileIndex.Y);
                        tileToReplace.Index = selectedTile.Index;
                        tileToReplace.Image = selectedTile.Image;

                        mapPictureBox.Invalidate();
                    }
                }
            }
        }

        private void mapPictureBox_MouseUp(object sender, MouseEventArgs e)
        {

        }

        public void OnMapSelected(string mapName)
        {
            Console.WriteLine(mapName);
            map = new Map($"./Resources/MapFiles/testmaps/{mapName}.map");
            mapPictureBox.Image = new Bitmap(map.WidthInPixels, map.HeightInPixels);
            mapPictureBox.ClientSize = mapPictureBox.Image.Size;
            widthLabel.Text = $"Width: {map.Width}";
            heightLabel.Text = $"Height: {map.Height}";
            heightLabel.Location = new Point(widthLabel.Location.X + widthLabel.Width + 10, heightLabel.Location.Y);
            mapPictureBox.Invalidate();
        }
    }
}
