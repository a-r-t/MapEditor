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
    public partial class ScrollablePanel : UserControl
    {
        private readonly Bitmap upScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButton.png");
        private readonly Bitmap upScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonDisabled.png");
        private readonly Bitmap upScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonHovered.png");
        private readonly Bitmap upScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/UpScrollButtonSelected.png");

        private readonly Bitmap downScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButton.png");
        private readonly Bitmap downScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonDisabled.png");
        private readonly Bitmap downScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonHovered.png");
        private readonly Bitmap downScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/DownScrollButtonSelected.png");

        private readonly Bitmap leftScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButton.png");
        private readonly Bitmap leftScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonDisabled.png");
        private readonly Bitmap leftScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonHovered.png");
        private readonly Bitmap leftScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonSelected.png");

        private readonly Bitmap rightScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButton.png");
        private readonly Bitmap rightScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonDisabled.png");
        private readonly Bitmap rightScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonHovered.png");
        private readonly Bitmap rightScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonSelected.png");

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

        private int hScrollOffset;
        public int HScrollOffset
        {
            get
            {
                return hScrollOffset;
            }
            set
            {
                hScrollOffset = value;
            }
        }

        public int MinVScrollOffset { get; set; }
        public int MaxVScrollOffset { get; set; }
        public int MinHScrollOffset { get; set; }
        public int MaxHScrollOffset { get; set; }

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

        public bool IsHScrollLeftDisabled
        {
            get
            {
                return MinHScrollOffset == HScrollOffset;
            }
        }

        public bool IsHScrollRightDisabled
        {
            get
            {
                return MaxHScrollOffset == HScrollOffset;
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

        public Point LeftScrollButtonLocation
        {
            get
            {
                return new Point(0, 0);
            }
        }

        public Point RightScrollButtonLocation
        {
            get
            {
                return new Point(hScrollBarPanel.Width - rightScrollButtonImage.Width, 0);
            }
        }

        private bool upScrollButtonHovered;
        private bool downScrollButtonHovered;
        private bool leftScrollButtonHovered;
        private bool rightScrollButtonHovered;

        private bool upScrollButtonSelected;
        private bool downScrollButtonSelected;
        private bool leftScrollButtonSelected;
        private bool rightScrollButtonSelected;

        public ScrollablePanel()
        {
            InitializeComponent();
            imagePanel.DoubleBuffered(true);
            vScrollBarPanel.DoubleBuffered(true);
            hScrollBarPanel.DoubleBuffered(true);
            vScrollBarPanel.Resize += (s, e) => vScrollBarPanel.Refresh();
            hScrollBarPanel.Resize += (s, e) => hScrollBarPanel.Refresh();
            VScrollOffset = 0;
            HScrollOffset = 0;
            MinVScrollOffset = 0;
            MaxVScrollOffset = imagePanel.Height;
            MinHScrollOffset = 0;
            MaxHScrollOffset = imagePanel.Width;
            imagePanel.BackColor = Color.White;
            vScrollBarPanel.BackColor = Color.FromArgb(241, 241, 241);
            hScrollBarPanel.BackColor = Color.FromArgb(241, 241, 241);
        }

        protected virtual void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            // TODO: Override me
        }

        private void vScrollBarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(getUpScrollButtonImageToPaint(), UpScrollButtonLocation);
            e.Graphics.DrawImage(getDownScrollButtonImageToPaint(), DownScrollButtonLocation);
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

        private void vScrollBarPanel_MouseEnter(object sender, EventArgs e)
        {

        }

        private void vScrollBarPanel_MouseLeave(object sender, EventArgs e)
        {
            upScrollButtonHovered = false;
            downScrollButtonHovered = false;
            upScrollButtonSelected = false;
            downScrollButtonSelected = false;
            vScrollBarPanel.Invalidate();
        }

        private void vScrollBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool oldUpScrollButtonHoveredValue = upScrollButtonHovered;
            upScrollButtonHovered = e.X > UpScrollButtonLocation.X && e.X < UpScrollButtonLocation.X + upScrollButtonImage.Width && e.Y > UpScrollButtonLocation.Y && e.Y < UpScrollButtonLocation.Y + upScrollButtonImage.Height;
            
            bool oldDownScrollButtonHoveredValue = downScrollButtonHovered;
            downScrollButtonHovered = e.X > DownScrollButtonLocation.X && e.X < DownScrollButtonLocation.X + downScrollButtonImage.Width && e.Y > DownScrollButtonLocation.Y && e.Y < DownScrollButtonLocation.Y + downScrollButtonImage.Height;

            if (oldUpScrollButtonHoveredValue != upScrollButtonHovered || oldDownScrollButtonHoveredValue != downScrollButtonHovered)
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

                if (oldUpScrollButtonSelected != upScrollButtonSelected || oldDownScrollButtonSelected != downScrollButtonSelected)
                {
                    vScrollBarPanel.Invalidate();
                }
            }
        }

        private void vScrollBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            upScrollButtonSelected = false;
            downScrollButtonSelected = false;
            vScrollBarPanel.Invalidate();
        }

        private void hScrollBarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(getLeftScrollButtonImageToPaint(), LeftScrollButtonLocation);
            e.Graphics.DrawImage(getRightScrollButtonImageToPaint(), RightScrollButtonLocation);
        }

        private Bitmap getLeftScrollButtonImageToPaint()
        {
            if (!IsHScrollLeftDisabled)
            {
                if (!leftScrollButtonHovered)
                {
                    return leftScrollButtonImage;
                }
                else
                {
                    if (!leftScrollButtonSelected)
                    {
                        return leftScrollButtonHoveredImage;
                    }
                    else
                    {
                        return leftScrollButtonSelectedImage;
                    }
                }
            }
            else
            {
                return leftScrollButtonDisabledImage;
            }
        }

        private Bitmap getRightScrollButtonImageToPaint()
        {
            if (!IsHScrollRightDisabled)
            {
                if (!rightScrollButtonHovered)
                {
                    return rightScrollButtonImage;
                }
                else
                {
                    if (!rightScrollButtonSelected)
                    {
                        return rightScrollButtonHoveredImage;
                    }
                    else
                    {
                        return rightScrollButtonSelectedImage;
                    }
                }
            }
            else
            {
                return rightScrollButtonDisabledImage;
            }
        }

        private void hScrollBarPanel_MouseEnter(object sender, EventArgs e)
        {

        }

        private void hScrollBarPanel_MouseLeave(object sender, EventArgs e)
        {
            leftScrollButtonHovered = false;
            rightScrollButtonHovered = false;
            leftScrollButtonSelected = false;
            rightScrollButtonSelected = false;
            hScrollBarPanel.Invalidate();
        }

        private void hScrollBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool oldLeftScrollButtonHoveredValue = leftScrollButtonHovered;
            leftScrollButtonHovered = e.X > LeftScrollButtonLocation.X && e.X < LeftScrollButtonLocation.X + leftScrollButtonImage.Width && e.Y > LeftScrollButtonLocation.Y && e.Y < LeftScrollButtonLocation.Y + leftScrollButtonImage.Height;

            bool oldRightScrollButtonHoveredValue = rightScrollButtonHovered;
            rightScrollButtonHovered = e.X > RightScrollButtonLocation.X && e.X < RightScrollButtonLocation.X + rightScrollButtonImage.Width && e.Y > RightScrollButtonLocation.Y && e.Y < RightScrollButtonLocation.Y + rightScrollButtonImage.Height;

            if (oldLeftScrollButtonHoveredValue != leftScrollButtonHovered || oldRightScrollButtonHoveredValue != rightScrollButtonHovered)
            {
                hScrollBarPanel.Invalidate();
            }
        }

        private void hScrollBarPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                bool oldLeftScrollButtonSelected = leftScrollButtonSelected;
                if (leftScrollButtonHovered)
                {
                    leftScrollButtonSelected = true;
                }
                else
                {
                    leftScrollButtonSelected = false;
                }

                bool oldRightScrollButtonSelected = rightScrollButtonSelected;
                if (rightScrollButtonHovered)
                {
                    rightScrollButtonSelected = true;
                }
                else
                {
                    rightScrollButtonSelected = false;
                }

                if (oldLeftScrollButtonSelected != leftScrollButtonSelected || oldRightScrollButtonSelected != rightScrollButtonSelected)
                {
                    hScrollBarPanel.Invalidate();
                }
            }
        }

        private void hScrollBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            leftScrollButtonSelected = false;
            rightScrollButtonSelected = false;
            hScrollBarPanel.Invalidate();
        }
    }
}
