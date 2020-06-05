﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fasetto.World
{
    /// <summary>
    /// A base converter that allows directly XAML usage
    /// </summary>
    /// <typaparam name="T">The type of this value converter</typaparam>
    public abstract class BaseValueConverter<T> : MarkupExtension, IValueConverter
        where T:class,new()
    {
        #region Private Members
        /// <summary>
        /// A single static instance of this converter
        /// </summary>
        private static T Converter = null;

        #endregion

        #region Markup Extension Method

        /// <summary>
        /// Provides a static instance of this converter
        /// </summary>
        /// <param name="serviceProvider">The service provider</param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Converter ?? (Converter = new T());
        }

        #endregion

        #region Value Converter Methods

        /// <summary>
        /// The method to convert one to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);


        /// <summary>
        /// The method to convert a value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);


        #endregion
    }
}