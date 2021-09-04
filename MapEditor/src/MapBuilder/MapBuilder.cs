using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.MapList;
using MapEditor.src.MapDimensionsEditor;
using MapEditor.src.MapTilesetEditor;
using MapEditor.src.Models;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, 
        MapListListener, 
        DimensionsEditorHandlerListener,
        TilesetEditorHandlerListener
    {
        private Map map;
        private TileEditor.TileEditor tileEditor;
        private DimensionsEditorHandler dimensionsEditorHandler;
        private TilesetEditorHandler tilesetEditorHandler;

        public MapBuilder()
        {
            InitializeComponent();

            tileEditor = new TileEditor.TileEditor();
            tileEditorTab.Controls.Add(tileEditor);
            tileEditor.Dock = DockStyle.Fill;

            dimensionsEditorHandler = new DimensionsEditorHandler();
            dimensionsTab.Controls.Add(dimensionsEditorHandler);
            dimensionsEditorHandler.Dock = DockStyle.Fill;
            dimensionsEditorHandler.AddListener(this);

            tilesetEditorHandler = new TilesetEditorHandler();
            tilesetTab.Controls.Add(tilesetEditorHandler);
            tilesetEditorHandler.Dock = DockStyle.Fill;
            tilesetEditorHandler.AddListener(this);
        }

        public void OnMapSelected(string mapName)
        {
            map = new Map($"./Resources/MapFiles/testmaps/{mapName}.map");
            tileEditor.Map = map;
            dimensionsEditorHandler.Map = map;
            tilesetEditorHandler.Map = map;
        }

        public void OnDimensionsUpdated(int width, int height)
        {
            ReloadMapTiles();
            tileEditor.Map = map;
            tileEditor.Invalidate();
        }

        public void OnTilesetInfoUpdated(string tilesetName, int scale)
        {
            ReloadMapTiles();
            tileEditor.Map = map;
            tileEditor.Invalidate();
        }

        public void ReloadMapTiles()
        {
            int heightCounter = 0;
            for (int i = 0; i < map.MapTiles.Length; i++)
            {
                int tileIndex = map.MapTiles[i].Index;
                int column = i % map.Width;
                if (i != 0 && i % map.Width == 0)
                {
                    heightCounter++;
                }
                int row = heightCounter;

                int tileX = column * map.Tileset.TilesetScaledWidth;
                int tileY = row * map.Tileset.TilesetScaledHeight;
                int tileWidth = map.Tileset.TilesetScaledWidth;
                int tileHeight = map.Tileset.TilesetScaledHeight;

                Tile tile = new Tile(tileIndex, map.Tileset.GetTileSubImage(tileIndex));
                tile.SetLocation(tileX, tileY);
                tile.SetDimensions(tileWidth, tileHeight);
                map.MapTiles[i] = tile;
            }
        }

        public void SaveMap()
        {
            map.SaveMap();
        }
    }
}
