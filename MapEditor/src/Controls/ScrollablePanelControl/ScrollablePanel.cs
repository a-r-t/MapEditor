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

        private readonly Bitmap leftScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButton.png");
        private readonly Bitmap leftScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonDisabled.png");
        private readonly Bitmap leftScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonHovered.png");
        private readonly Bitmap leftScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/LeftScrollButtonSelected.png");

        private readonly Bitmap rightScrollButtonImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButton.png");
        private readonly Bitmap rightScrollButtonDisabledImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonDisabled.png");
        private readonly Bitmap rightScrollButtonHoveredImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonHovered.png");
        private readonly Bitmap rightScrollButtonSelectedImage = new Bitmap(@"./Resources/Images/ScrollablePanelControl/RightScrollButtonSelected.png");

        

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

      
        public int MinHScrollOffset { get; set; }
        public int MaxHScrollOffset { get; set; }

       

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

        
        private bool leftScrollButtonHovered;
        private bool rightScrollButtonHovered;

       
        private bool leftScrollButtonSelected;
        private bool rightScrollButtonSelected;

        private VScrollBar vScrollBar;

        public ScrollablePanel()
        {
            InitializeComponent();
            imagePanel.DoubleBuffered(true);
            hScrollBarPanel.DoubleBuffered(true);
            hScrollBarPanel.Resize += (s, e) => hScrollBarPanel.Refresh();
            HScrollOffset = 0;

            MinHScrollOffset = 0;
            MaxHScrollOffset = imagePanel.Width;
            imagePanel.BackColor = Color.White;
            hScrollBarPanel.BackColor = Color.FromArgb(241, 241, 241);

            vScrollBar = new VScrollBar();
            vScrollBarContainer.Controls.Add(vScrollBar);
            vScrollBar.Location = new Point(this.Width - vScrollBar.Width, 0);
            vScrollBar.Dock = DockStyle.Fill;

        }

        protected virtual void imagePanel_Paint(object sender, PaintEventArgs e)
        {
            // TODO: Override me
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
