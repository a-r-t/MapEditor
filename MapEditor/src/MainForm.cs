﻿using MapEditor.src.ExtensionMethods;
using MapEditor.src.MapBuilder;
using MapEditor.src.MapList;
using MapEditor.src.TilePicker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor
{
    public partial class MainForm : Form, MapListListener
    {
        private MapBuilder mapBuilder;
        private MapList mapList;
        private TilePicker tilePicker;

        public MainForm()
        {
            InitializeComponent();
            mapBuilder = new MapBuilder();
            mapList = new MapList();
            tilePicker = new TilePicker();

            mapBuilderPanel.Controls.Add(mapBuilder);
            mapBuilder.Dock = DockStyle.Fill;
            mapBuilder.Hide();

            mapListPanel.Controls.Add(mapList);
            mapList.Dock = DockStyle.Fill;
            
            tilePickerPanel.Controls.Add(tilePicker);
            tilePicker.Dock = DockStyle.Fill;
            tilePicker.Hide();

            tilePicker.AddListener(mapBuilder);

            mapBuilder.AddListener(tilePicker);

            mapList.AddListener(this);
            mapList.AddListener(mapBuilder);
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            //tilePicker.SetupTilePicker();
            //tilePicker.TilePickerRepaint = true;
            //tilePicker.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // eliminates flickering from inside split containers... https://stackoverflow.com/a/13941011
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            int style = NativeWinApi.GetWindowLong(this.Handle, NativeWinApi.GWL_EXSTYLE);
            style |= NativeWinApi.WS_EX_COMPOSITE;
            NativeWinApi.SetWindowLong(this.Handle, NativeWinApi.GWL_EXSTYLE, style);

            saveButton.Image = Image.FromFile("./Resources/Images/save-icon.png");
        }

        public void OnMapSelected(string mapName)
        {
            mapBuilder.Show();
            tilePicker.Show();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveMap();
        }

        private void SaveMap()
        {
            mapBuilder.SaveMap();
        }
    }
}
