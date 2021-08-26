using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.src.MapTilesetEditor
{
    public partial class TilesetEditor : ObservableUserControl<TilesetEditorListener>
    {
        public TilesetEditor()
        {
            InitializeComponent();
        }
    }
}
