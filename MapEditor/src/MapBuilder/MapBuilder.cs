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

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, 
        MapListListener, 
        DimensionsDisplayListener,
        DimensionsEditorListener
    {
        private Map map;
        private TileEditor.TileEditor tileEditor;
        private DimensionsDisplay dimensionsDisplay;
        private DimensionsEditor dimensionsEditor;

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
        }

        public void SaveMap()
        {
            map.SaveMap();
        }
    }
}
