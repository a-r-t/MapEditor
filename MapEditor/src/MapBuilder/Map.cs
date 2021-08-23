﻿using MapEditor.src.ExtensionMethods;
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
        public Tile[] MapTiles { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        
        public int WidthInPixels
        {
            get
            {
                return Width * Tileset.TilesetScaledWidth;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return Height * Tileset.TilesetScaledHeight;
            }
        }

        public Tileset Tileset { get; private set; }

        public int MapTileWidth
        {
            get
            {
                return Tileset.TilesetScaledWidth;
            }
        }

        public int MapTileHeight
        {
            get
            {
                return Tileset.TilesetScaledHeight;
            }
        }

        public Map(string mapFileName)
        {
            LoadMap(mapFileName);
        }

        public void LoadMap(string mapFileName)
        {
            using (StreamReader sr = File.OpenText(mapFileName))
            {
                string[] dimensions = sr.ReadLine().Split(' ');
                Width = int.Parse(dimensions[0]);
                Height = int.Parse(dimensions[1]);

                string[] tilesetInfo = sr.ReadLine().Split(' ');
                string tilesetName = tilesetInfo[0];
                int tilesetTileWidth = int.Parse(tilesetInfo[1]);
                int tilesetTileHeight = int.Parse(tilesetInfo[2]);
                int mapTileScale = int.Parse(tilesetInfo[3]);

                this.Tileset = new Tileset($"./Resources/Tilesets/{tilesetName}.png", tilesetTileWidth, tilesetTileHeight, mapTileScale);
                
                MapTiles = new Tile[Width * Height];
                string indexes = "";
                int heightCounter = 0;
                while ((indexes = sr.ReadLine()) != null)
                {
                    string[] mapTileIndexes = indexes.Split(' ');
                    for (int i = 0; i < mapTileIndexes.Length; i++)
                    {
                        int tileIndex = int.Parse(mapTileIndexes[i]);
                        int row = heightCounter;
                        int column = i % Width;
                        int tileX = column * Tileset.TilesetScaledWidth;
                        int tileY = row * Tileset.TilesetScaledHeight;
                        int tileWidth = Tileset.TilesetScaledWidth;
                        int tileHeight = Tileset.TilesetScaledHeight;

                        Tile tile = new Tile(tileIndex, Tileset.GetTileSubImage(tileIndex));
                        tile.SetLocation(tileX, tileY);
                        tile.SetDimensions(tileWidth, tileHeight);
                        SetMapTile(i, heightCounter, tile);
                    }
                    heightCounter++;
                }
            }
            PrintMap();
        }

        public int GetConvertedIndex(int x, int y)
        {
            return x + Width * y;
        }

        public Tile GetMapTile(int x, int y)
        {
            return MapTiles[GetConvertedIndex(x, y)];
        }

        public Point GetTileIndexByPosition(float xPosition, float yPosition)
        {
            int xIndex = (xPosition / (float)Tileset.TilesetScaledWidth).Round();
            int yIndex = (yPosition / (float)Tileset.TilesetScaledHeight).Round();
            return new Point(xIndex, yIndex);
        }

        public void SetMapTile(int x, int y, Tile tile)
        {
            MapTiles[GetConvertedIndex(x, y)] = tile;
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
            graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            
            for (int i = 0; i < MapTiles.Length; i++)
            {
                Tile tile = MapTiles[i];
                tile.Paint(graphics);
            }
        }

      
    }
}
