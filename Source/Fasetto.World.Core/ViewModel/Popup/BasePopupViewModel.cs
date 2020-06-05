namespace Fasetto.World.Core
{
    /// <summary>
    /// A view model for any popup menus
    /// </summary>
    public class BasePopupViewModel:BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The background color of the bubble in A RGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        /// <summary>
        /// The arrow alignment in a bubble
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The content inside of this popup menu
        /// </summary>
        public BaseViewModel Content { get; set; }

        #endregion

        #region Constructor

        public BasePopupViewModel()
        {
            //Set the default
            //TODO: Move color into core and make use of it here
            BubbleBackground = "ffffff";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion
    }
}
