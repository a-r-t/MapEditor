using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.TileEditor
{
    public interface TileEditorListener
    {
        void OnMapLoad(Map map);
    }
}
