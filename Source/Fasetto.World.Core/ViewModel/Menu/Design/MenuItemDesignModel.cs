﻿namespace Fasetto.World.Core
{
    /// <summary>
    /// The design-time data for a <see cref="MenuItemViewModel"/> 
    /// </summary>
    public class MenuItemDesignModel:MenuItemViewModel
    {

        #region Public Properties

        /// <summary>
        /// A single instance of design model
        /// </summary>
        public static MenuItemDesignModel Instance => new MenuItemDesignModel();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuItemDesignModel()
        {
            Text = "Hello World";
            Icon = IconType.File;

        }

        #endregion

    }
}
