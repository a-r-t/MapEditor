using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.MapBuilder;
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.TilePicker
{
    public partial class TilePicker : ObservableUserControl<TilePickerListener>
    {
        private Tileset tileset;
        public bool TilePickerRepaint { get; set; }
        public bool isHoveringTile = false;

        public TilePicker()
        {
            InitializeComponent();
            this.tileset = new Tileset($"./Resources/Tilesets/CommonTileset.png", 16, 16, 3);
            SetupTilePicker();
            DrawTiles();
        }

        public void SetupTilePicker()
        {
            Console.WriteLine("setup: " + tilePickerPanel.Width);

            int tileSpacing = 5;
            int numberOfColumns = Math.Max((tilePickerPanel.ClientSize.Width - tileSpacing) / (tileset.TilesetScaledWidth + tileSpacing), 1);
            int numberOfRows = (int)Math.Ceiling(tileset.NumberOfTiles / (float)numberOfColumns);
            tilePickerPictureBox.Location = new Point(0, 0);
            tilePickerPictureBox.Image = new Bitmap(tilePickerPanel.ClientSize.Width, numberOfRows * tileset.TilesetScaledHeight + (numberOfRows * tileSpacing) + tileSpacing);
            tilePickerPictureBox.Size = new Size(numberOfColumns * tileset.TilesetScaledWidth + (numberOfColumns * tileSpacing) + tileSpacing, tilePickerPictureBox.Image.Height);
            for (int i = 0; i < tileset.Tiles.Length; i++)
            {
                Tile tile = tileset.Tiles[i];
                int row = i / numberOfColumns;
                int column = i % numberOfColumns;
                tile.SetLocation(column * tileset.TilesetScaledWidth + (column * tileSpacing) + tileSpacing, row * tileset.TilesetScaledHeight + (row * tileSpacing) + tileSpacing);
                tile.SetDimensions(tileset.TilesetScaledWidth, tileset.TilesetScaledHeight);
            }
            if (tilePickerPanel.HorizontalScroll.Visible)
            {
                tilePickerPictureBox.Size = new Size(tilePickerPictureBox.Width - 1, tilePickerPictureBox.Height);
            }
        }

        private void DrawTiles()
        {
            using (Graphics graphics = Graphics.FromImage(tilePickerPictureBox.Image))
            {
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

                for (int i = 0; i < tileset.Tiles.Length; i++)
                {
                    Tile tile = tileset.Tiles[i];
                    tile.Paint(graphics);
                }
            }
        }

        private void tilePickerPictureBox_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            for (int i = 0; i < tileset.Tiles.Length; i++)
            {
                Tile tile = tileset.Tiles[i];
                tile.Paint(e.Graphics);
            }
        }

        private void tilePickerPictureBox_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void tilePickerPictureBox_MouseLeave(object sender, EventArgs e)
        {

        }

        private void tilePickerPanel_Resize(object sender, EventArgs e)
        {
            Console.WriteLine("RESIZE: " + tilePickerPanel.Width);

            SetupTilePicker();
            tilePickerPictureBox.Invalidate();
        }
    }
}
