using MapEditor.src.TileEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.TilePicker
{
    public class Tileset
    {
        public string TilesetImageFile { get; private set; }
        public Tile[] Tiles { get; private set; }
        public Bitmap TilesetImage { get; private set; }
        public int TilesetImageWidth { get; private set; }
        public int TilesetImageHeight { get; private set; }
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }
        public int TileScale { get; private set; }
        public int TilesetScaledWidth
        {
            get
            {
                return TileWidth * TileScale;
            }
        }
        public int TilesetScaledHeight
        {
            get
            {
                return TileHeight * TileScale;
            }
        }
        private int numberOfRows;
        private int numberOfColumns;
        public int NumberOfTiles
        {
            get
            {
                return numberOfRows * numberOfColumns;
            }
        }

        public string Name
        {
            get
            {
                return Path.GetFileNameWithoutExtension(TilesetImageFile);
            }
        }

        public Tileset(string tilesetImageFile, int tileWidth, int tileHeight, int tileScale)
        {
            TilesetImageFile = tilesetImageFile;
            TilesetImage = new Bitmap(tilesetImageFile);
            TilesetImageWidth = TilesetImage.Width;
            TilesetImageHeight = TilesetImage.Height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileScale = tileScale;
            numberOfRows = TilesetImageHeight / TileHeight;
            numberOfColumns = TilesetImageWidth / TileWidth;

            Tiles = new Tile[NumberOfTiles];
            for (int i = 0; i < NumberOfTiles; i++)
            {
                Tiles[i] = new Tile(i, GetTileSubImage(i));
            }
        }

        public Rectangle GetTileSubImageRectangle(int index)
        {
            int row = index / numberOfColumns;
            int column = index % numberOfColumns;
            return new Rectangle(column + (TileWidth * column), row + (TileHeight * row), TileWidth, TileHeight);
        }

        public Bitmap GetTileSubImage(int index)
        {
            Rectangle tileSubImageRect = GetTileSubImageRectangle(index);
            return TilesetImage.Clone(tileSubImageRect, TilesetImage.PixelFormat);
        }
    }
}
