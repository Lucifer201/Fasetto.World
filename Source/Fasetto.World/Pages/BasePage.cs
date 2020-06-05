using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;
using Fasetto.World.Core;
using System.ComponentModel;

namespace Fasetto.World
{
    /// <summary>
    /// The base page for all pages to gain base functionality
    /// </summary>
    public class BasePage:UserControl
    {
        #region Private Members

        /// <summary>
        ///The view model associated with this page 
        /// </summary>
        private object mViewModel;

        #endregion

        #region Public Properties

        /// <summary>
        ///The view model associated with this page 
        /// </summary>
        public object ViewModelObject
        {
            get => mViewModel;
            set
            {
                //If nothing changes, return
                if (mViewModel == value)
                    return;

                //Update the value 
                mViewModel = value;

                //Fire the view model changed mothod
                OnViewModelChanged();

                //Set the data context for this page 
                DataContext = mViewModel;
            }
        }

        /// <summary>
        /// The annimation to play when the page is first loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// The annimation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnLoadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// The time any animation takes to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        /// <summary>
        /// A flag indicate if this page should animate out on load
        /// Useful for when we are moving the page to another frame 
        /// </summary>
        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            //Don't bother animating in design time
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            //If we are animating in, hide to begin with
            if (PageLoadAnimation != PageAnimation.None)
                Visibility = Visibility.Collapsed;

            //listen out for the page loading
            Loaded += BasePage_LoadedAsync;

        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded, perform any requied animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            //If we are setup to animate out on load
            if (ShouldAnimateOut)
                //Animate out the page
                await AnimateOutAsync();
            else
                //Animate the page in
                await AnimateInAsync();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            //Make sure we have something to do
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:

                    //Start the animation
                    await this.SlideAndFadeInAsync(AnimationSlideInDirection.Right, false,SlideSeconds,size:(int)Application.Current.MainWindow.Width);

                    break;

            }
        }

        /// <summary>
        /// Animates this page out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            //Make sure we have something to do
            if (PageUnLoadAnimation == PageAnimation.None)
                return;

            switch (PageUnLoadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:

                    //Start the animation
                    await this.SlideAndFadeOutAsync(AnimationSlideInDirection.Left,SlideSeconds);

                    break;
            }
        }

        #endregion

        /// <summary>
        /// Fired when the view model changes
        /// </summary>
        protected virtual void OnViewModelChanged() { }

    }

    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    public class BasePage<VM>:BasePage
        where VM:BaseViewModel,new()
    {
        #region Public Properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => (VM)ViewModelObject;
            set => ViewModelObject = value;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            //Create a default view model
            ViewModel = IoC.Get<VM>();
        }

        /// <summary>
        /// Constructor with specific view model
        /// </summary>
        public BasePage(VM specificViewModel = null) : base()
        {
            //If we do have a sepecific view model, Set it
            if (specificViewModel != null)
                ViewModel = specificViewModel;
            //Otherwise, Create a default view model
            else
                ViewModel = IoC.Get<VM>();
        }

        #endregion

    }
}
