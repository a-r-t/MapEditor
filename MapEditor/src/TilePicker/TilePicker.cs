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
        private Tile selectedTile = null;

        public TilePicker()
        {
            InitializeComponent();
            this.tileset = new Tileset($"./Resources/Tilesets/CommonTileset.png", 16, 16, 3);
            SetupTilePicker();
            tilePickerPictureBox.Invalidate();
        }

        public void SetupTilePicker()
        {
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

            if (selectedTile != null)
            {
                Pen pen = new Pen(Color.Yellow, 5);
                e.Graphics.DrawRectangle(
                    pen,
                    new Rectangle(
                        selectedTile.X - 2,
                        selectedTile.Y - 2,
                        selectedTile.Width + 5,
                        selectedTile.Height + 5
                    )
                );
            }

        }

        private void tilePickerPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Tile tile in tileset.Tiles)
            {
                if (tile.IsPointInTile(e.Location))
                {
                    Cursor = Cursors.Hand;
                    return;
                }
            }
            Cursor = Cursors.Arrow;
        }

        private void tilePickerPictureBox_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void tilePickerPanel_Resize(object sender, EventArgs e)
        {
            SetupTilePicker();
            tilePickerPictureBox.Invalidate();
        }

        private void tilePickerPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (Tile tile in tileset.Tiles)
            {
                if (tile.IsPointInTile(e.Location))
                {
                    Cursor = Cursors.Hand;
                    selectedTile = tile;
                    return;
                }
            }
            Cursor = Cursors.Arrow;
        }

        private void tilePickerPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (Tile tile in tileset.Tiles)
                {
                    if (tile.IsPointInTile(e.Location))
                    {
                        selectedTile = tile;
                        tilePickerPictureBox.Invalidate();
                        return;
                    }
                }
            }
        }
    }
}
