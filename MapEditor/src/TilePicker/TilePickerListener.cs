﻿using MapEditor.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.TilePicker
{
    public interface TilePickerListener
    {
        void OnTileSelect(Tile tile);
    }
}
