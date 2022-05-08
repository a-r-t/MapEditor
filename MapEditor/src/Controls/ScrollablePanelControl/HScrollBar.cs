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
    public partial class HScrollBar : ObservableUserControl<HScrollBarListener>
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
                int oldHScrollOffset = hScrollOffset;
                if (value < MinHScrollOffset)
                {
                    hScrollOffset = MinHScrollOffset;
                }
                else if (value > MaxHScrollOffset)
                {
                    hScrollOffset = MaxHScrollOffset;
                }
                else
                {
                    hScrollOffset = value;
                }
                HScrollBarXLocation = hScrollOffset + (leftScrollButtonImage.Width + 1);

                int scrollDifference = hScrollOffset - oldHScrollOffset;
                if (scrollDifference != 0)
                {
                    foreach (HScrollBarListener listener in listeners)
                    {
                        listener.onHScroll(scrollDifference);
                    }
                }
            }
        }

        public int MinHScrollOffset { get; set; }
        private int maxHScrollOffset;
        public int MaxHScrollOffset
        {
            get
            {
                return maxHScrollOffset;
            }
            set
            {
                maxHScrollOffset = value;
                if (HScrollOffset > MaxHScrollOffset)
                {
                    HScrollOffset = MaxHScrollOffset;
                }
            }
        }

        public bool IsHScrollLeftDisabled
        {
            get
            {
                return HScrollOffset <= MinHScrollOffset;
            }
        }

        public bool IsHScrollRightDisabled
        {
            get
            {
                return HScrollOffset >= MaxHScrollOffset;
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

        private int hScrollBarXLocation;
        public int HScrollBarXLocation
        {
            get
            {
                return hScrollBarXLocation;
            }
            set
            {
                hScrollBarXLocation = value;
                hScrollBarPanel.Invalidate();
            }
        }
        private int hScrollBarYLocation;

        private int hScrollBarWidth;
        public int HScrollBarWidth
        {
            get
            {
                return hScrollBarWidth;
            }
            set
            {
                hScrollBarWidth = value;
            }
        }
        private int hScrollBarHeight;

        private bool hScrollBarHovered;
        private bool hScrollBarSelected;

        private int initialMouseX = 0;
        private int initialMouseY = 0; // mouse's initial location relative to scroll bar graphic
        private int previousMouseX = 0;
        private int previousMouseY = 0; // mouse's previous location relative to scroll bar panel
        private bool scrollBarMouseRight = false;
        private bool scrollButtonMouseRight = false;
        public int ScrollButtonsScrollOffset { get; set; }
        public int MouseWheelScrollOffset { get; set; }
        private const int BUTTON_TIMER_INITIAL_INTERVAL_DELAY = 200;
        private const int BUTTON_TIMER_INTERVAL_DELAY = 10;

        private Timer scrollTimer;
        private Timer buttonTimer;

        public HScrollBar()
        {
            InitializeComponent();
            hScrollBarPanel.DoubleBuffered(true);
            hScrollBarPanel.BackColor = Color.FromArgb(241, 241, 241);
            hScrollBarPanel.MouseWheel += new MouseEventHandler(hScrollBarPanel_MouseWheel);
            HScrollOffset = 0;

            HScrollBarXLocation = 18;
            hScrollBarYLocation = 2;
            hScrollBarWidth = 70; // temp for testing
            hScrollBarHeight = 13; 

            scrollTimer = new Timer();
            scrollTimer.Interval = 1;
            scrollTimer.Tick += new EventHandler(ScrollTimer_Tick);

            buttonTimer = new Timer();
            buttonTimer.Interval = BUTTON_TIMER_INITIAL_INTERVAL_DELAY;
            buttonTimer.Tick += new EventHandler(ButtonTimer_Tick);

            ScrollButtonsScrollOffset = 5;
            MouseWheelScrollOffset = 20;
        }

        private void hScrollBarPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                HScrollOffset += MouseWheelScrollOffset;
            }
            else if (e.Delta > 0)
            {
                HScrollOffset -= MouseWheelScrollOffset;
            }
        }

        private void hScrollBarPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(getLeftScrollButtonImageToPaint(), LeftScrollButtonLocation);
            e.Graphics.DrawImage(getRightScrollButtonImageToPaint(), RightScrollButtonLocation);

            Brush brush = new SolidBrush(getHScrollBarColor());
            e.Graphics.FillRectangle(brush, new Rectangle(HScrollBarXLocation, hScrollBarYLocation, hScrollBarWidth, hScrollBarHeight));
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

        private Color getHScrollBarColor()
        {

            if (hScrollBarSelected)
            {
                return Color.FromArgb(120, 120, 120);
            }
            else if (hScrollBarHovered)
            {
                return Color.FromArgb(168, 168, 168);
            }
            else
            {
                return Color.FromArgb(193, 193, 193);
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
            hScrollBarHovered = false;
            hScrollBarPanel.Invalidate();
        }

        private void hScrollBarPanel_MouseMove(object sender, MouseEventArgs e)
        {
            bool oldLeftScrollButtonHoveredValue = leftScrollButtonHovered;
            leftScrollButtonHovered = e.X > LeftScrollButtonLocation.X && e.X < LeftScrollButtonLocation.X + leftScrollButtonImage.Width && e.Y > LeftScrollButtonLocation.Y && e.Y < LeftScrollButtonLocation.Y + leftScrollButtonImage.Height;

            bool oldRightScrollButtonHoveredValue = rightScrollButtonHovered;
            rightScrollButtonHovered = e.X > RightScrollButtonLocation.X && e.X < RightScrollButtonLocation.X + rightScrollButtonImage.Width && e.Y > RightScrollButtonLocation.Y && e.Y < RightScrollButtonLocation.Y + rightScrollButtonImage.Height;

            bool oldHScrollBarHoveredValue = hScrollBarHovered;
            hScrollBarHovered = e.X > HScrollBarXLocation && e.X < HScrollBarXLocation + hScrollBarWidth && e.Y > hScrollBarYLocation && e.Y < hScrollBarYLocation + hScrollBarHeight;

            if (oldLeftScrollButtonHoveredValue != leftScrollButtonHovered
                || oldRightScrollButtonHoveredValue != rightScrollButtonHovered
                || oldHScrollBarHoveredValue != hScrollBarHovered)
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
                if (leftScrollButtonSelected && !scrollButtonMouseRight)
                {
                    HScrollOffset -= ScrollButtonsScrollOffset;
                    scrollButtonMouseRight = true;
                    buttonTimer.Interval = BUTTON_TIMER_INITIAL_INTERVAL_DELAY;
                    buttonTimer.Start();
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
                if (rightScrollButtonSelected && !scrollButtonMouseRight)
                {
                    HScrollOffset += ScrollButtonsScrollOffset;
                    scrollButtonMouseRight = true;
                    buttonTimer.Interval = BUTTON_TIMER_INITIAL_INTERVAL_DELAY;
                    buttonTimer.Start();
                }

                bool oldHScrollBarSelected = hScrollBarSelected;
                if (hScrollBarHovered)
                {
                    hScrollBarSelected = true;
                }
                else
                {
                    hScrollBarSelected = false;
                }

                if (hScrollBarSelected && !scrollBarMouseRight)
                {
                    scrollBarMouseRight = true;
                    previousMouseX = e.X;
                    previousMouseY = e.Y;

                    initialMouseX = e.X - HScrollBarXLocation;
                    initialMouseY = e.Y - hScrollBarYLocation;

                    scrollTimer.Start();
                }

                // if nothing else is selected but mouse was pressed, it happened on the "empty" parts of the scrollbar, which should trigger a jump
                if (!leftScrollButtonSelected && !rightScrollButtonSelected && !hScrollBarSelected)
                {
                    if (e.X < HScrollBarXLocation)
                    {
                        HScrollOffset -= hScrollBarWidth;
                    }
                    else if (e.X > HScrollBarXLocation)
                    {
                        HScrollOffset += hScrollBarWidth;
                    }
                }

                if (oldLeftScrollButtonSelected != leftScrollButtonSelected
                    || oldRightScrollButtonSelected != rightScrollButtonSelected
                    || oldHScrollBarSelected != hScrollBarSelected)
                {
                    hScrollBarPanel.Invalidate();
                }
            }
        }

        private void hScrollBarPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                scrollBarMouseRight = false;
                scrollButtonMouseRight = false;
                leftScrollButtonSelected = false;
                rightScrollButtonSelected = false;
                hScrollBarSelected = false;
                scrollTimer.Stop();
                buttonTimer.Stop();
                hScrollBarPanel.Invalidate();
            }
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            if (scrollBarMouseRight)
            {
                Point mouseCoords = hScrollBarPanel.PointToClient(new Point(Cursor.Position.X, Cursor.Position.Y));

                int differenceX = mouseCoords.X - previousMouseX;

                HScrollOffset += differenceX;

                if (HScrollOffset < MinHScrollOffset)
                {
                    HScrollOffset = MinHScrollOffset;
                }
                if (HScrollOffset > MaxHScrollOffset)
                {
                    HScrollOffset = MaxHScrollOffset;
                }

                previousMouseX = mouseCoords.X;
                previousMouseY = mouseCoords.Y;

                // keep scroll bar relative to where it was originally pressed
                if (mouseCoords.X - HScrollBarXLocation != initialMouseX)
                {
                    HScrollOffset += ((mouseCoords.X - HScrollBarXLocation) - initialMouseX);
                }

                if (differenceX != 0)
                {
                    hScrollBarPanel.Invalidate();
                }
            }
        }

        private void ButtonTimer_Tick(object sender, EventArgs e)
        {
            if (scrollButtonMouseRight)
            {
                if (leftScrollButtonSelected)
                {
                    HScrollOffset -= ScrollButtonsScrollOffset;
                }
                else if (rightScrollButtonSelected)
                {
                    HScrollOffset += ScrollButtonsScrollOffset;
                }
                if (buttonTimer.Interval == BUTTON_TIMER_INITIAL_INTERVAL_DELAY)
                {
                    buttonTimer.Interval = BUTTON_TIMER_INTERVAL_DELAY;
                }
            }
        }

        private void HScrollBar_Load(object sender, EventArgs e)
        {
            MinHScrollOffset = 0;
            MaxHScrollOffset = hScrollBarPanel.Width - HScrollBarWidth - 36;
        }

        private void hScrollBarPanel_Resize(object sender, EventArgs e)
        {
            MaxHScrollOffset = hScrollBarPanel.Width - HScrollBarWidth - 36;
            hScrollBarPanel.Refresh();
        }
    }
}
