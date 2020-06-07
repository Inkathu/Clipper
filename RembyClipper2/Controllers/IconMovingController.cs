using System;
using System.Drawing;
using System.Windows.Forms;
using RembyClipper2.Config;

namespace RembyClipper2.Controllers
{
    public class IconMovingController
    {

        public event EventHandler IconMovedToUnproperlyPlace;
        
        private readonly Form _form;
        int _mX;
        private int _mY;
        private Rectangle _screenBounds;

        private Timer _animationTimer;

        private const int ICON_SIZE = 32;
        private const int MOVE_TIME = 2;//sec
        private const int TIMER_INTERVAL = 20; //msec
        public bool IconAtProperlyPlace { get; private set; }
        public IconMovingController(Form form)
        {
            _form = form;
            form.MouseDown += FormMouseDown;
            form.MouseUp += FormMouseUp;
            form.MouseMove += FormMouseMove;
            _screenBounds = Screen.PrimaryScreen.WorkingArea;
            _animationTimer = new Timer();
            _animationTimer.Interval = TIMER_INTERVAL;
            _animationTimer.Tick += new EventHandler(_animationTimer_Tick);
            IconAtProperlyPlace = isFormPlacedProperly();

        }


        void FormMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _mX = e.X;
            _mY = e.Y;
        }

        void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            if (_mX != -1 && _mY != -1)
            {
                int x = Cursor.Position.X - _mX;
                //_mX = x;
                int y = Cursor.Position.Y - _mY;
                //_mY = y;
                if (x < _screenBounds.X)
                {
                    x = _screenBounds.X;
                }
                else if (x > (_screenBounds.Right - 32))
                {
                    x = _screenBounds.Right - 32;
                }
                _form.Location = new Point(x, y);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        ///  screen quadrants:
        ///  !----!----!
        ///  ! 1  !  2 !
        ///  !----!----!
        ///  ! 3  !  4 !
        ///  !----!----!
        /// </remarks>
        void FormMouseUp(object sender, MouseEventArgs e)
        {
            _screenBounds = Screen.PrimaryScreen.WorkingArea;
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _mX = -1;
            _mY = -1;
            int xHalf = _screenBounds.Width/2;
            int yHalf = _screenBounds.Height/2;
            int hW = _form.Width/2;
            int x = _form.Location.X+hW;
            int hh = _form.Height/2;
            int y = _form.Location.Y +hh;
            _form.Location = new Point(0, 0);
            int nX = x - hW;
            int nY = y - hh;
            #region 1st quadrant

            if(x <= xHalf && y<= yHalf)
            {
                //1st quadrant
                if(x < y)
                {
                    //stick to the left
                    _form.Location = new Point(_screenBounds.Left, nY);
                }
                else
                {
                    //stick to the top
                    _form.Location = new Point(nX, _screenBounds.Top);
                }
            }

                #endregion

            #region 2nd quadrant
            else if (x > xHalf && y <= yHalf)
            {
                //2nd quadrant
                if(_screenBounds.Right-x < y)
                {
                    //stick to right
                    _form.Location = new Point(_screenBounds.Right - ICON_SIZE, nY);
                } else
                {
                    //stick to the top
                    _form.Location = new Point(nX, _screenBounds.Top);
                    
                }
            }
            #endregion
            
            #region 3rd quadrant
            else if (x <= xHalf && y > yHalf)
            {
                //3rd quadrant
                if (x < _screenBounds.Bottom - y)
                {
                    //stick to left
                    _form.Location = new Point(_screenBounds.Left, nY);
                }
                else
                {
                    //stick to the bottom
                    _form.Location = new Point(nX, _screenBounds.Bottom - ICON_SIZE);

                }

            }
            #endregion

            #region 4th quadrant
            else if (x > xHalf && y > yHalf)
            {
                //4th quadrant
                if (_screenBounds.Right - x < _screenBounds.Bottom - y)
                {
                    //stick to right
                    _form.Location = new Point(_screenBounds.Right - ICON_SIZE, nY);
                }
                else
                {
                    //stick to the bottom
                    _form.Location = new Point(nX, _screenBounds.Bottom - ICON_SIZE);

                }

            }
            #endregion
            if(_form.Location.Y > (yHalf + yHalf/2))
            {
                EventHandler handler = IconMovedToUnproperlyPlace;
                if(handler != null)
                {
                    handler(this, EventArgs.Empty);
                }
                IconAtProperlyPlace = false;
            } else
            {
                IconAtProperlyPlace = true;
            }

            AppConfig.Instance.TopNavPosition = _form.Location;
            AppConfig.Instance.Store();
        }

        private bool isFormPlacedProperly()
        {
            int yHalf = _screenBounds.Height/2;
             if(_form.Location.Y > (yHalf + yHalf/2))
             {
                 return false;
             }

            return true;
        }

        private void AnimatedMoving(Point from, Point to)
        {
            //_animationTimer
            int dx = from.X - to.X;
            int dy = from.Y - to.Y;
            int distance = (int)Math.Sqrt(dx*dx + dy*dy);
            int pxPerMSec = distance/MOVE_TIME*1000; //velocity - pixels per millisecond

        }

        void _animationTimer_Tick(object sender, EventArgs e)
        {
            
        }


    }
}