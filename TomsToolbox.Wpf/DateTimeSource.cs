﻿namespace TomsToolbox.Wpf
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Data;
    using TomsToolbox.Desktop;

    /// <summary>
    /// Provides values for date and time suitable for bindings.
    /// </summary>
    /// <remarks>
    /// This expression in XAML would be static, since the Source is never updated and would always have 
    /// it's initial value, <see cref="BindingExpression.UpdateTarget"/> won't have any effect.
    /// <para/>
    /// MyDayOfWeek="{Binding Path=DayOfWeek, Source={x:Static system:DateTime.Today}}"
    /// <para/>
    /// Using <see cref="DateTimeSource"/> instead, <see cref="BindingExpression.UpdateTarget"/> will work, 
    /// and MyDayOfWeek will be updated with the actual value:
    /// <para/>
    /// MyDayOfWeek="{Binding Path=Today.DayOfWeek, Source={x:Static toms:DateTimeSource.Default}}"
    /// </remarks>
    public class DateTimeSource : ObservableObject
    {
        /// <summary>
        /// The default singleton object. Use this as a source for binding that supports updating.
        /// </summary>
        public static readonly DateTimeSource Default = new DateTimeSource();

        private DateTimeSource()
        {
        }

        /// <summary>
        /// Gets a <see cref="T:System.DateTime"/> object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> whose value is the current local date and time.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Should only be accessible via the Default singleton.")]
        public DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> set to today's date, with the time component set to 00:00:00.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Should only be accessible via the Default singleton.")]
        public DateTime Today
        {
            get
            {
                return DateTime.Today;
            }
        }

        /// <summary>
        /// Gets a <see cref="T:System.DateTime"/> object that is set to the current date and time on this computer, expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.DateTime"/> whose value is the current UTC date and time.
        /// </returns>
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Should only be accessible via the Default singleton.")]
        public DateTime UtcNow
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
