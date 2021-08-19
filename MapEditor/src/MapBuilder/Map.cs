using MapEditor.src.ExtensionMethods;
using MapEditor.src.TilePicker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.MapBuilder
{
    public class Map
    {
        public int[] MapTiles { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        public int WidthInPixels
        {
            get
            {
                return Width * tileset.TilesetScaledWidth;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return Height * tileset.TilesetScaledHeight;
            }
        }

        private Tileset tileset;

        public int MapTileWidth
        {
            get
            {
                return tileset.TilesetScaledWidth;
            }
        }

        public int MapTileHeight
        {
            get
            {
                return tileset.TilesetScaledHeight;
            }
        }

        public Map()
        {

        }

        public void LoadMap(string mapFileName, Tileset tileset)
        {
            this.tileset = tileset;

            using (StreamReader sr = File.OpenText(mapFileName))
            {
                string[] dimensions = sr.ReadLine().Split(' ');
                Width = int.Parse(dimensions[0]);
                Height = int.Parse(dimensions[1]);

                MapTiles = new int[Width * Height];
                string indexes = String.Empty;
                int heightCounter = 0;
                while ((indexes = sr.ReadLine()) != null)
                {
                    string[] mapTileIndexes = indexes.Split(' ');
                    for (int i = 0; i < mapTileIndexes.Length; i++)
                    {
                        SetMapTile(i, heightCounter, int.Parse(mapTileIndexes[i]));
                    }
                    heightCounter++;
                }
            }
            PrintMap();
        }

        private int GetConvertedIndex(int x, int y)
        {
            return x + Width * y;
        }

        public int GetMapTile(int x, int y)
        {
            return MapTiles[GetConvertedIndex(x, y)];
        }

        public Point GetTileIndexByPosition(float xPosition, float yPosition)
        {
            int xIndex = (xPosition / (float)tileset.TilesetScaledWidth).Round();
            int yIndex = (yPosition / (float)tileset.TilesetScaledHeight).Round();
            return new Point(xIndex, yIndex);
        }

        public void SetMapTile(int x, int y, int tileIndex)
        {
            MapTiles[GetConvertedIndex(x, y)] = tileIndex;
        }

        public void PrintMap()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"{GetMapTile(j, i)} ");
                }
                Console.Write("\n");
            }
        }

        public void Paint(Graphics graphics)
        {
            
            Bitmap tilesetImage = new Bitmap("./Resources/Tilesets/CommonTileset.png");
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            

            for (int i = 0; i < MapTiles.Length; i++)
            {
                int tileIndex = MapTiles[i];
                int row = i / Width;
                int column = i % Width;
                Rectangle tileSubImageRect = tileset.GetTileSubImageRectangle(tileIndex);
                //Console.WriteLine($"Tile sub image: {tileSubImageRect}");
                Bitmap tilesetSubImage = tilesetImage.Clone(tileSubImageRect, tilesetImage.PixelFormat);
                //Console.WriteLine($"Tile Index: {i}");
                //Console.WriteLine($"Column: {column}, Row: {row}, Tileset Scale: {tileset.TileScale}");
                //Console.WriteLine($"Location: {column * tileset.TilesetScaledWidth},{row * tileset.TilesetScaledHeight}");
                graphics.DrawImage(tilesetSubImage, column * tileset.TilesetScaledWidth, row * tileset.TilesetScaledHeight, tileset.TilesetScaledWidth, tileset.TilesetScaledHeight);
                //graphics.DrawImage(tilesetSubImage, new Rectangle(column * tileset.TilesetScaledWidth, row * tileset.TilesetScaledHeight, tileset.TilesetScaledWidth, tileset.TilesetScaledHeight), new Rectangle(0,0, tilesetSubImage.Width, tilesetSubImage.Height), GraphicsUnit.Pixel);

            }
        }

      
    }
}
