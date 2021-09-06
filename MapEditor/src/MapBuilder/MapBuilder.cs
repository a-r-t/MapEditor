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
using MapEditor.src.MapTileEditor;

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, 
        MapListListener, 
        DimensionsEditorHandlerListener,
        TilesetEditorHandlerListener
    {
        private Map map;
        private TileEditor tileEditor;
        private DimensionsEditorHandler dimensionsEditorHandler;
        private TilesetEditorHandler tilesetEditorHandler;

        public MapBuilder()
        {
            InitializeComponent();

            tileEditor = new TileEditor();
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
            map.ReloadMapTiles();
            tileEditor.Map = map;
            tileEditor.Invalidate();
        }

        public void OnTilesetInfoUpdated(string tilesetName, int scale)
        {
            map.ReloadMapTiles();
            tileEditor.Map = map;
            tileEditor.Invalidate();
        }

        public void SaveMap()
        {
            map.SaveMap();
        }
    }
}
