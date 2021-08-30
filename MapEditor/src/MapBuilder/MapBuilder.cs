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

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, 
        MapListListener, 
        DimensionsDisplayListener,
        DimensionsEditorListener,
        TilesetDisplayListener,
        TilesetEditorListener
    {
        private Map map;
        private TileEditor.TileEditor tileEditor;
        private DimensionsDisplay dimensionsDisplay;
        private DimensionsEditor dimensionsEditor;
        private TilesetDisplay tilesetDisplay;
        private TilesetEditor tilesetEditor;

        public MapBuilder()
        {
            InitializeComponent();

            tileEditor = new TileEditor.TileEditor();
            tileEditorTab.Controls.Add(tileEditor);
            tileEditor.Dock = DockStyle.Fill;

            dimensionsDisplay = new DimensionsDisplay();
            dimensionsTab.Controls.Add(dimensionsDisplay);
            dimensionsDisplay.Dock = DockStyle.Fill;
            dimensionsDisplay.AddListener(this);

            dimensionsEditor = new DimensionsEditor();
            dimensionsTab.Controls.Add(dimensionsEditor);
            dimensionsEditor.Dock = DockStyle.Fill;
            dimensionsEditor.Hide();
            dimensionsEditor.AddListener(this);

            tilesetDisplay = new TilesetDisplay();
            tilesetTab.Controls.Add(tilesetDisplay);
            tilesetDisplay.Dock = DockStyle.Fill;
            tilesetDisplay.AddListener(this);

            tilesetEditor = new TilesetEditor();
            tilesetTab.Controls.Add(tilesetEditor);
            tilesetEditor.Dock = DockStyle.Fill;
            tilesetEditor.Hide();
            tilesetEditor.AddListener(this);
        }

        public void OnChangeDimensionsRequested()
        {
            dimensionsEditor.Reset();
            dimensionsDisplay.Hide();
            dimensionsEditor.Show();
        }

        public void OnDimensionsUpdateCanceled()
        {
            dimensionsDisplay.Show();
            dimensionsEditor.Hide();
            dimensionsEditor.Reset();
        }

        public void OnDimensionsUpdated(int width, int height)
        {
            map.SaveMap();
            tileEditor.LoadMap(map);
            tileEditor.Invalidate();
            dimensionsDisplay.Show();
            dimensionsEditor.Hide();
            dimensionsDisplay.Reset();
            dimensionsEditor.Reset();
        }

        public void OnMapSelected(string mapName)
        {
            map = new Map($"./Resources/MapFiles/testmaps/{mapName}.map");
            tileEditor.LoadMap(map);
            
            dimensionsDisplay.Map = map;
            dimensionsDisplay.Reset();

            dimensionsEditor.Map = map;
            dimensionsEditor.Reset();

            tilesetDisplay.Map = map;
            tilesetDisplay.Reset();

            tilesetEditor.Map = map;
            tilesetEditor.Reset();
        }

        public void SaveMap()
        {
            map.SaveMap();
        }
    }
}
