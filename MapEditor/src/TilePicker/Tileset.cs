using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.TilePicker
{
    public class Tileset
    {
        public string TilesetImageFile { get; private set; }
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

        public Tileset(string tilesetImageFile, int tileWidth, int tileHeight, int tileScale)
        {
            TilesetImageFile = tilesetImageFile;
            Bitmap tilesetImage = new Bitmap(tilesetImageFile);
            TilesetImageWidth = tilesetImage.Width;
            TilesetImageHeight = tilesetImage.Height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            TileScale = tileScale;
            numberOfRows = TilesetImageHeight / TileHeight;
            numberOfColumns = TilesetImageWidth / TileWidth;
        }

        public Rectangle GetTileSubImageRectangle(int index)
        {
            int row = index / numberOfColumns;
            int column = index % numberOfColumns;
            return new Rectangle(column + (TileWidth * column), row + (TileHeight * row), TileWidth, TileHeight);
        }
    }
}
