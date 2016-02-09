﻿namespace TomsToolbox.Wpf.Converters
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// A converter that converts the specified value by replacing text using a regular expression.
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    public class ReplaceTextConverter : IValueConverter
    {
        /// <summary>
        /// Gets or sets the regular expression to find.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets or sets the text to replace.
        /// </summary>
        public string Replacement { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RegexOptions"/> used to find the string.
        /// </summary>
        public RegexOptions Options { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to replace all found instances or only the first.
        /// </summary>
        public bool ReplaceAll { get; set; }

        private object Convert(string value)
        {
            return Convert(value, Pattern, Replacement, Options, ReplaceAll);
        }

        /// <summary>
        /// Converts the specified value by replacing text using a regular expression.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="pattern">The regular expression to find.</param>
        /// <param name="replacement">The replacing text.</param>
        /// <param name="options">The options for the regular expression.</param>
        /// <param name="replaceAll">if set to <c>true</c> all occurrences will be replaces; otherwise only the first.</param>
        /// <returns>The converted value.</returns>
        public static object Convert(string value, string pattern, string replacement, RegexOptions options, bool replaceAll)
        {
            if (value == null)
                return null;

            if (string.IsNullOrEmpty(pattern))
                return value;

            replacement = replacement ?? string.Empty;

            var regex = new Regex(pattern, options);
            regex.Replace(value, replacement, replaceAll ? -1 : 1);

            return value;
        }

        /// <summary>
        /// Converts a value.
        /// Null and UnSet are unchanged.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value == DependencyProperty.UnsetValue)
                return value;

            try
            {
                return Convert((string)value);
            }
            catch (Exception ex)
            {
                PresentationTraceSources.DataBindingSource.TraceEvent(TraceEventType.Error, 9000, "{0} failed: {1}", GetType().Name, ex.Message);
                return DependencyProperty.UnsetValue;
            }
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new InvalidOperationException();
        }
    }
}