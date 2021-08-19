using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapEditor.src.MapBuilder
{
    public class Tile
    {
        public int Index { get; set; }
        public Bitmap Image { get; set; }

        public Tile(int index, Bitmap image)
        {
            Index = index;
            Image = image;
        }

        public void Paint(Graphics graphics, int x, int y, int width, int height)
        {
            graphics.DrawImage(Image, x, y, width, height);
        }
    }
}
