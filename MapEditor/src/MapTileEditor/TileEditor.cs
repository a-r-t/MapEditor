using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.TilePicker;
using MapEditor.src.ExtensionMethods;
using MapEditor.src.MapList;
using MapEditor.src.Models;

namespace MapEditor.src.MapTileEditor
{
    public partial class TileEditor : ObservableUserControl<TileEditorListener>, TilePickerListener
    {
        private Map map;
        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                LoadMap();
            }
        }

        private Point hoveredTileIndex = new Point(-1, -1);
        private Tile selectedTile;
        private TilePicker.TilePicker tilePicker;

        public TileEditor()
        {
            InitializeComponent();
            tilePicker = new TilePicker.TilePicker();
            tilePickerPanel.Controls.Add(tilePicker);
            tilePicker.Dock = DockStyle.Fill;

            tilePicker.AddListener(this);
            this.AddListener(tilePicker);
            mapPanel.DoubleBuffered(true);
        }

        private void MapBuilder_Load(object sender, EventArgs e)
        {
            mapPanel.ClientSize = new Size(0, 0);
            splitContainer1.SplitterDistance = 688;
        }

        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            if (map != null)
            {
                map.Paint(e.Graphics);
                if (hoveredTileIndex.X != -1 && hoveredTileIndex.Y != -1)
                {
                    int borderSize = map.Tileset.TileScale + 1;
                    Pen pen = new Pen(Color.Yellow, borderSize);
                    e.Graphics.DrawRectangle(
                        pen,
                        new Rectangle(
                            (hoveredTileIndex.X * map.MapTileWidth) + (borderSize / 2.0f).Round(),
                            (hoveredTileIndex.Y * map.MapTileHeight) + (borderSize / 2.0f).Round(),
                            map.MapTileWidth - borderSize,
                            map.MapTileHeight - borderSize
                        )
                    );
                }
            }
        }

        private void mapPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (map != null)
            {
                hoveredTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                selectedTileIndexLabel.Text = $"X: {hoveredTileIndex.X}, Y: {hoveredTileIndex.Y}";
                selectedTileIndexLabel.Location = new Point(heightLabel.Location.X + heightLabel.Width + 10, selectedTileIndexLabel.Location.Y);

                if (e.Button == MouseButtons.Left)
                {
                    if (selectedTile != null)
                    {
                        Point selectedTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                        int convertedTileIndex = map.GetConvertedIndex(selectedTileIndex.X, selectedTileIndex.Y);
                        if (convertedTileIndex >= 0 && convertedTileIndex < map.Width * map.Height)
                        {
                            Tile tileToReplace = map.GetMapTile(selectedTileIndex.X, selectedTileIndex.Y);
                            tileToReplace.Index = selectedTile.Index;
                            tileToReplace.Image = (Bitmap)selectedTile.Image.Clone();
                        }
                    }
                }

                mapPanel.Invalidate();
            }
        }

        private void mapPanelBox_MouseLeave(object sender, EventArgs e)
        {
            selectedTileIndexLabel.Visible = false;
            hoveredTileIndex = new Point(-1, -1);

            mapPanel.Invalidate();
        }

        private void mapPanel_MouseEnter(object sender, EventArgs e)
        {
            selectedTileIndexLabel.Visible = true;
        }

        public void OnTileSelect(Tile tile)
        {
            selectedTile = tile;
        }

        private void mapPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selectedTile != null)
                {
                    Point selectedTileIndex = map.GetTileIndexByPosition(e.X - map.MapTileWidth / 2, e.Y - map.MapTileHeight / 2);
                    int convertedTileIndex = map.GetConvertedIndex(selectedTileIndex.X, selectedTileIndex.Y);

                    if (convertedTileIndex >= 0 && convertedTileIndex < map.Width * map.Height)
                    {
                        Tile tileToReplace = map.GetMapTile(selectedTileIndex.X, selectedTileIndex.Y);
                        tileToReplace.Index = selectedTile.Index;
                        tileToReplace.Image = selectedTile.Image;

                        mapPanel.Invalidate();

                        foreach (TileEditorListener listener in listeners)
                        {
                            listener.OnTileEdited(convertedTileIndex, tileToReplace);
                        }
                    }
                }
            }
        }

        private void mapPanel_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void LoadMap()
        {
            //mapPictureBox.Image = new Bitmap(map.WidthInPixels, map.HeightInPixels);
            //mapPictureBox.ClientSize = mapPictureBox.Image.Size;
            mapPanel.ClientSize = new Size(map.WidthInPixels, map.HeightInPixels);
            widthLabel.Text = $"Width: {map.Width}";
            heightLabel.Text = $"Height: {map.Height}";
            heightLabel.Location = new Point(widthLabel.Location.X + widthLabel.Width + 10, heightLabel.Location.Y);
            mapPanel.Invalidate();

            foreach (TileEditorListener listener in listeners)
            {
                listener.OnTileEditorLoad(map);
            }
        }
    }
}
