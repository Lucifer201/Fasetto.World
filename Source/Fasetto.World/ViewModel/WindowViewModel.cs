using Fasetto.World.Core;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.World
{
    public class WindowViewModel:BaseViewModel
    {
        #region Private Member
        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;


        /// <summary>
        /// The windowr resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition=WindowDockPosition.Undocked;

        /// <summary>
        /// The margin around the window to drop a shadow
        /// </summary>
        private Thickness mOuterMarginSize = new Thickness(5);

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        #endregion

        #region Command

        /// <summary>
        /// The command to minimize the window
        /// </summary>

        public ICommand MinimizeCommand { get; set; }


        /// <summary>
        /// The command to maximize the window
        /// </summary>

        public ICommand MaximizeCommand { get; set; }


        /// <summary>
        /// The command to close the window
        /// </summary>

        public ICommand CloseCommand { get; set; }


        /// <summary>
        /// The command to show the system of the window
        /// </summary>

        public ICommand MenuCommand { get; set; }


        #endregion

        #region Public Properties

        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// The smallest heigth the window can go to
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// True if the window is currently being moved/dragged
        /// </summary>
        public bool BeingMoved { get; set; }

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless =>(mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); 

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 4;

        /// <summary>
        /// The size of the resize border around the window, taking into account of the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(OuterMarginSize.Left + ResizeBorder, 
                                                                OuterMarginSize.Top + ResizeBorder, 
                                                                OuterMarginSize.Right + ResizeBorder,
                                                                OuterMarginSize.Bottom + ResizeBorder);

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// The margin around the window to drop a shadow
        /// </summary>
        public Thickness OuterMarginSize
        {
            //If it is maximized or docked, no border
            get => mWindow.WindowState == WindowState.Maximized ? mWindowResizer.CurrentMonitorMargin : (Borderless ? new Thickness(0) : mOuterMarginSize);
            set => mOuterMarginSize = value;

        }


        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            //If it is maximized or docked, no corneradius
            get => Borderless ? 0 : mWindowRadius;
            set=>mWindowRadius = value;
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The rectangle border around the window when docked
        /// </summary>
        public int FlatBorderThickness => Borderless && mWindow.WindowState != WindowState.Maximized ? 1 : 0;


        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>

        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The height of the title bar/caption of the window
        /// </summary>

        public GridLength TitleHeightGridLength=> new GridLength(TitleHeight+ResizeBorder);

        /// <summary>
        /// True if we should have a dimmed overlay on the window
        /// such as when a popup is visible or the window is not focused
        /// </summary>
        public bool DimmableOverlayVisible { get; set; }

        public SettingsViewModel SettingMenu { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window"></param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            //Liston out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                //Fire off events for all properties that are affected by resize
                WindowResized();
            };

            //Create commands
            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            //Fix the issue of the window with style none
            mWindowResizer = new WindowResizer(mWindow);

            //Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                //Store last position
                mDockPosition = dock;

                //Fire off resize events
                WindowResized();
            };


            //On window being moved/dragged
            mWindowResizer.WindowStartedMove += () =>
            {
                //Update being moved flag
                BeingMoved = true;
            };

            //Fix dropping an undocked window at top 
            //which should be positioned at the very top of screen
            mWindowResizer.WindowFinishedMove += () =>
            {
                //Update being moved flag
                BeingMoved = false;

                //Check for moved to top of window and not at an ede
                if (mDockPosition == WindowDockPosition.Undocked && mWindow.Top == mWindowResizer.CurrentScreenSize.Top)
                    //If so, move it to the true top (the border size)
                    mWindow.Top = -OuterMarginSize.Top;
            };

        }
        #endregion

        #region Helpers

        /// <summary>
        /// Gets the mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            //Add the window postion so it's a "ToScreen"
            return mWindowResizer.GetCursorPosition();
        }

        private void WindowResized()
        {
            //Fire off events for all properties that are affected by resize
            OnPropertyChanged(nameof(Borderless));
            OnPropertyChanged(nameof(FlatBorderThickness));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
