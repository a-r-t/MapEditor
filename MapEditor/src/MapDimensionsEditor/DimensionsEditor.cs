using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.MapBuilder;
using MapEditor.src.TileEditor;

namespace MapEditor.src.MapDimensionsEditor
{
    public partial class DimensionsEditor : ObservableUserControl<DimensionsEditorListener>
    {
        public Map Map { get; set; }

        public DimensionsEditor()
        {
            InitializeComponent();
            errorMessageLabel.Visible = false;
        }

        public void Reset()
        {
            editWidthTextbox.Text = Map.Width.ToString();
            editHeightTextbox.Text = Map.Height.ToString();
            widthChangeLeftRadioButton.Checked = false;
            widthChangeRightRadioButton.Checked = true;
            heightChangeTopRadioButton.Checked = false;
            heightChangeBottomRadioButton.Checked = true;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            errorMessageLabel.Visible = false;
            bool isValid = true;

            // validate width
            int newWidth = 0;
            try
            {
                newWidth = int.Parse(editWidthTextbox.Text);
            }
            catch (Exception ex)
            {
                isValid = false;
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    ShowChangeDimensionsError("Width must be an int");
                }
                else
                {
                    ShowChangeDimensionsError(ex.Message);
                }
            }
            if (newWidth < 0)
            {
                isValid = false;
                ShowChangeDimensionsError("Width must be >= 0");
            }

            // validate height
            int newHeight = 0;
            try
            {
                newHeight = int.Parse(editHeightTextbox.Text);
            }
            catch (Exception ex)
            {
                isValid = false;
                if (ex is ArgumentNullException || ex is FormatException || ex is OverflowException)
                {
                    ShowChangeDimensionsError("Height must be an int");
                }
                else
                {
                    ShowChangeDimensionsError(ex.Message);
                }
            }
            if (newHeight < 0)
            {
                isValid = false;
                ShowChangeDimensionsError("Height must be >= 0");
            }

            if (isValid)
            {
                UpdateMapDimensions(newWidth, newHeight);
            }
        }

        private void UpdateMapDimensions(int newWidth, int newHeight)
        {
            if (newWidth != Map.Width)
            {
                UpdateWidth(newWidth);
            }
            if (newHeight != Map.Height)
            {
                UpdateHeight(newHeight);
            }
            foreach (DimensionsEditorListener listener in listeners)
            {
                listener.OnDimensionsUpdated(newWidth, newHeight);
            }
        }

        private void UpdateWidth(int newWidth)
        {
            if (widthChangeLeftRadioButton.Checked)
            {

            }
            else if (widthChangeRightRadioButton.Checked)
            {
                int difference = newWidth - Map.Width;
                Tile[] tiles = new Tile[newWidth * Map.Height];

                int widthCounter = 0;
                int heightCounter = 0;
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (i > 0 && i % newWidth == 0)
                    {
                        heightCounter++;
                        widthCounter = 0;
                    }
                    if (widthCounter < Map.Width)
                    {
                        tiles[i] = Map.MapTiles[i - (heightCounter * difference)];
                    }
                    else
                    {
                        Tile tile = new Tile(0, Map.Tileset.GetTileSubImage(0));
                        int tileX = widthCounter * Map.Tileset.TilesetScaledWidth;
                        int tileY = heightCounter * Map.Tileset.TilesetScaledHeight;
                        int tileWidth = Map.Tileset.TilesetScaledWidth;
                        int tileHeight = Map.Tileset.TilesetScaledHeight;
                        tile.SetLocation(tileX, tileY);
                        tile.SetDimensions(tileWidth, tileHeight);
                        tiles[i] = tile;
                    }
                    widthCounter++;
                }
                   
                Map.MapTiles = tiles;
                Map.Width = newWidth;
            }
        }

  
        private void UpdateHeight(int newHeight)
        {
            if (heightChangeTopRadioButton.Checked)
            {

            }
            else if (heightChangeBottomRadioButton.Checked)
            {
                Tile[] tiles = new Tile[Map.Width * newHeight];

                int widthCounter = 0;
                int heightCounter = 0;
                for (int i = 0; i < tiles.Length; i++)
                {
                    if (i > 0 && i % Map.Width == 0)
                    {
                        heightCounter++;
                        widthCounter = 0;
                    }
                    if (heightCounter < Map.Height)
                    {
                        tiles[i] = Map.MapTiles[i];
                    }
                    else
                    {
                        Tile tile = new Tile(0, Map.Tileset.GetTileSubImage(0));
                        int tileX = widthCounter * Map.Tileset.TilesetScaledWidth;
                        int tileY = heightCounter * Map.Tileset.TilesetScaledHeight;
                        int tileWidth = Map.Tileset.TilesetScaledWidth;
                        int tileHeight = Map.Tileset.TilesetScaledHeight;
                        tile.SetLocation(tileX, tileY);
                        tile.SetDimensions(tileWidth, tileHeight);
                        tiles[i] = tile;
                    }
                    widthCounter++;
                }

                Map.MapTiles = tiles;
                Map.Height = newHeight;
            }
        }

        private void ShowChangeDimensionsError(string errorMessage)
        {
            errorMessageLabel.Visible = true;
            errorMessageLabel.Text = $"Error: {errorMessage}";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            foreach (DimensionsEditorListener listener in listeners)
            {
                listener.OnDimensionsUpdateCanceled();
            }
        }
    }
}
