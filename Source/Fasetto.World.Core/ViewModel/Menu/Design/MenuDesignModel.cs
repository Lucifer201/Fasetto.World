using System.Collections.Generic;

namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="MenuViewModel"/> 
    /// </summary>
    public class MenuDesignModel:MenuViewModel
    {
        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static MenuDesignModel Instance => new MenuDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>(new[]
            {
                new MenuItemViewModel{Type=MenuItemType.Header,Text="Design time view"},
                new MenuItemViewModel{Text="MenuItem 1",Icon=IconType.Picture},
                new MenuItemViewModel{Text="MenuItem 2",Icon=IconType.File},
            });
        }

        #endregion

    }
}
