using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MapEditor.src.ExtensionMethods;

namespace MapEditor.src.Controls.ScrollablePanelControl
{
    public partial class VScrollBar : ObservableUserControl<VScrollBarListener>
    {
        private readonly Bitmap upScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButton.png");
        private readonly Bitmap upScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonDisabled.png");
        private readonly Bitmap upScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonHovered.png");
        private readonly Bitmap upScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonSelected.png");

        private readonly Bitmap downScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButton.png");
        private readonly Bitmap downScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonDisabled.png");
        private readonly Bitmap downScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonHovered.png");
        private readonly Bitmap downScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonSelected.png");

        private int vScrollOffset;
        public int VScrollOffset
        {
            get
            {
                return vScrollOffset;
            }
            set
            {
                vScrollOffset = value;
            }
        }

        public int MinVScrollOffset { get; set; }
        public int MaxVScrollOffset { get; set; }

        public bool IsVScrollUpDisabled
        {
            get
            {
                return MinVScrollOffset == VScrollOffset;
            }
        }

        public bool IsVScrollDownDisabled
        {
            get
            {
                return MaxVScrollOffset == VScrollOffset;
            }
        }

        public Point UpScrollButtonLocation
        {
            get
            {
                return new Point(0, 0);
            }
        }

        public Point DownScrollButtonLocation
        {
            get
            {
                return new Point(0, vScrollBarPanel.Height - downScrollButtonImage.Height);
            }
        }

        private bool upScrollButtonHovered;
        private bool downScrollButtonHovered;

        private bool upScrollButtonSelected;
        private bool downScrollButtonSelected;

        private int vScrollBarXLocation;
        private int vScrollBarYLocation;
        public int VScrollBarYLocation
        {
            get
            {
                return vScrollBarYLocation;
            }
            set
            {
                vScrollBarYLocation = value;
                vScrollBarPanel.Invalidate();
            }
        }

        private int vScrollBarWidth;
        private int vScrollBarHeight;
        public int VScrollBarHeight
        {
            get
            {
                return vScrollBarHeight;
            }
            set
            {
                vScrollBarHeight = value;
            }
        }

        private bool vScrollBarHovered;
        private bool vScrollBarSelected;

        public VScrollBar()
        {
            InitializeComponent();
            vScrollBarPanel.DoubleBuffered(true);
            vScrollBarPanel.BackColor = Color.FromArgb(241, 241, 241);
            vScrollBarPanel.Resize += (s, e) => vScrollBarPanel.Refresh();
            VScrollOffset = 0;
            MinVScrollOffset = 0;
            MaxVScrollOffset = 300; // temp for testing
            vScrollBarXLocation = 2;
            VScrollBarYLocation = 18;
            vScrollBarWidth = 13;
            vScrollBarHeight = 70; // temp for testing

        }

        private void vScrollBarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(getUpScrollButtonImageToPaint(), UpScrollButtonLocation);
            e.Graphics.DrawImage(getDownScrollButtonImageToPaint(), DownScrollButtonLocation);

            Brush brush = new SolidBrush(getVScrollBarColor());
            e.Graphics.FillRectangle(brush, new Rectangle(vScrollBarXLocation, VScrollBarYLocation, vScrollBarWidth, vScrollBarHeight));
        }

        private Bitmap getUpScrollButtonImageToPaint()
        {
            if (!IsVScrollUpDisabled)
            {
                if (!upScrollButtonHovered)
                {
                    return upScrollButtonImage;
                }
                else
                {
                    if (!upScrollButtonSelected)
                    {
                        return upScrollButtonHoveredImage;
                    }
                    else
                    {
                        return upScrollButtonSelectedImage;
                    }
                }
            }
            else
            {
                return upScrollButtonDisabledImage;
            }
        }

        private Bitmap getDownScrollButtonImageToPaint()
        {
            if (!IsVScrollDownDisabled)
            {
                if (!downScrollButtonHovered)
                {
                    return downScrollButtonImage;
                }
                else
                {
                    if (!downScrollButtonSelected)
                    {
                        return downScrollButtonHoveredImage;
                    }
                    else
                    {
                        return downScrollButtonSelectedImage;
                    }
                }
            }
            else
            {
                return downScrollButtonDisabledImage;
            }
        }

        private Color getVScrollBarColor()
        {
            if (!vScrollBarHovered)
            {
                return Color.FromArgb(193, 193, 193);
            }
            else
            {
                if (!vScrollBarSelected)
                {
                    return Color.FromArgb(168, 168, 168);
                }
                else
                {
                    return Color.FromArgb(120, 120, 120);
                }
            }
        }

        private void vScrollBarPanel_MouseEnter(object sender, EventArgs e)
        {

        }

        private void vScrollBarPanel_MouseLeave(object sender, EventArgs e)
        {
            upScrollButtonHovered = false;
            downScrollButtonHovered = false;
            upScrollButtonSelected = false;
            downScrollButtonSelected = false;
            vScrollBarHovered = false;
            vScrollBarPanel.Invalidate();
        }

        private void vScrollBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool oldUpScrollButtonHoveredValue = upScrollButtonHovered;
            upScrollButtonHovered = e.X > UpScrollButtonLocation.X && e.X < UpScrollButtonLocation.X + upScrollButtonImage.Width && e.Y > UpScrollButtonLocation.Y && e.Y < UpScrollButtonLocation.Y + upScrollButtonImage.Height;

            bool oldDownScrollButtonHoveredValue = downScrollButtonHovered;
            downScrollButtonHovered = e.X > DownScrollButtonLocation.X && e.X < DownScrollButtonLocation.X + downScrollButtonImage.Width && e.Y > DownScrollButtonLocation.Y && e.Y < DownScrollButtonLocation.Y + downScrollButtonImage.Height;

            bool oldVScrollBarHoveredValue = vScrollBarHovered;
            vScrollBarHovered = e.X > vScrollBarXLocation && e.X < vScrollBarXLocation + vScrollBarWidth && e.Y > vScrollBarYLocation && e.Y < vScrollBarYLocation + vScrollBarHeight;

            if (oldUpScrollButtonHoveredValue != upScrollButtonHovered
                || oldDownScrollButtonHoveredValue != downScrollButtonHovered
                || oldVScrollBarHoveredValue != vScrollBarHovered)
            {
                vScrollBarPanel.Invalidate();
            }
        }

        private void vScrollBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool oldUpScrollButtonSelected = upScrollButtonSelected;
                if (upScrollButtonHovered)
                {
                    upScrollButtonSelected = true;
                }
                else
                {
                    upScrollButtonSelected = false;
                }

                bool oldDownScrollButtonSelected = downScrollButtonSelected;
                if (downScrollButtonHovered)
                {
                    downScrollButtonSelected = true;
                }
                else
                {
                    downScrollButtonSelected = false;
                }

                bool oldVScrollBarSelected = vScrollBarSelected;
                if (vScrollBarHovered)
                {
                    vScrollBarSelected = true;
                }
                else
                {
                    vScrollBarSelected = false;
                }

                if (oldUpScrollButtonSelected != upScrollButtonSelected
                    || oldDownScrollButtonSelected != downScrollButtonSelected
                    || oldVScrollBarSelected != vScrollBarSelected)
                {
                    vScrollBarPanel.Invalidate();
                }
            }
        }

        private void vScrollBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            upScrollButtonSelected = false;
            downScrollButtonSelected = false;
            vScrollBarSelected = false;
            vScrollBarPanel.Invalidate();
        }
    }
}
