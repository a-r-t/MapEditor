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

namespace MapEditor.src.MapBuilder
{
    public partial class MapBuilder : ObservableUserControl<MapBuilderListener>, MapListListener
    {
        private Map map;
        private TileEditor.TileEditor tileEditor;

        public MapBuilder()
        {
            InitializeComponent();

            tileEditor = new TileEditor.TileEditor();
            tileEditorTab.Controls.Add(tileEditor);
            tileEditor.Dock = DockStyle.Fill;
        }

        public void OnMapSelected(string mapName)
        {
            map = new Map($"./Resources/MapFiles/testmaps/{mapName}.map");
            tileEditor.LoadMap(map);
        }

        public void SaveMap()
        {
            map.SaveMap();
        }
    }
}
