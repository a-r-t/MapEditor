﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.MapList
{
    public partial class MapList : ObservableUserControl<MapListListener>
    {
        public MapList()
        {
            InitializeComponent();
        }

        private void MapList_Load(object sender, EventArgs e)
        {

            ImageList imageList = new ImageList();
            imageList.Images.Add("folder", Image.FromFile("./Resources/Images/folder-icon.png"));
            imageList.Images.Add("file", Image.FromFile("./Resources/Images/file-icon.png"));
            mapTreeView.ImageList = imageList;

            Queue<string> paths = new Queue<string>();
            string rootDir = Path.Combine(".", "Resources", "MapFiles");
            foreach (string dirPath in GetSubdirsInDir(rootDir))
            {
                string[] pathParts = dirPath.Split(Path.DirectorySeparatorChar);
                string dirName = pathParts[pathParts.Length - 1];
                paths.Enqueue(dirPath);
                mapTreeView.Nodes.Add(dirName, dirName);
                mapTreeView.Nodes[dirName].ImageKey = "folder";
                mapTreeView.Nodes[dirName].SelectedImageKey = "folder";
            }
            foreach (string filePath in GetFilesInDir(rootDir))
            {
                string[] pathParts = filePath.Split(Path.DirectorySeparatorChar);
                string fileName = Path.GetFileNameWithoutExtension(pathParts[pathParts.Length - 1]);
                mapTreeView.Nodes.Add(fileName, fileName);
                mapTreeView.Nodes[fileName].ImageKey = "file";
                mapTreeView.Nodes[fileName].SelectedImageKey = "file";
            }

            while (paths.Count > 0)
            {
                string path = paths.Dequeue();
                string[] pathParts = path.Split(Path.DirectorySeparatorChar);

                TreeNode temp = mapTreeView.Nodes[pathParts[3]];
                for (int i = 4; i < pathParts.Length - 1; i++)
                {
                    temp = temp.Nodes[pathParts[i]];
                }
                if (Directory.Exists(path))
                {
                    foreach (string subdirPath in GetSubdirsInDir(path))
                    {
                        string[] subdirPathParts = subdirPath.Split(Path.DirectorySeparatorChar);
                        paths.Enqueue(subdirPath);
                        string subdirName = subdirPathParts[subdirPathParts.Length - 1];
                        temp.Nodes.Add(subdirName, subdirName);
                        temp.Nodes[subdirName].ImageKey = "folder";
                        temp.Nodes[subdirName].SelectedImageKey = "folder";
                    }

                    foreach (string filePath in GetFilesInDir(path))
                    {
                        paths.Enqueue(filePath);
                    }
                }
                else if (File.Exists(path))
                {
                    string fileName = Path.GetFileNameWithoutExtension(pathParts[pathParts.Length - 1]);
                    temp.Nodes.Add(fileName, fileName);
                    temp.Nodes[fileName].ImageKey = "file";
                    temp.Nodes[fileName].SelectedImageKey = "file";
                }
            }
            mapTreeView.ExpandAll();
            
        }

        private string[] GetSubdirsInDir(string dir)
        {
            return Directory.GetDirectories(dir);
        }

        private string[] GetFilesInDir(string dir)
        {
            return Directory.GetFiles(dir);
        }
    }
}
