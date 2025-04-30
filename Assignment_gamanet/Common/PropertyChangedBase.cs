using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment_gamanet.Common
{
    /// <summary>
    /// Provides base functionality for property change notifications, implementing INotifyPropertyChanged.
    /// </summary>
    public class PropertyChangedBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Event that is triggered when a property changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Sets the field value and triggers the PropertyChanged event if the value changes.
        /// </summary>
        /// <typeparam name="T">The type of the field.</typeparam>
        /// <param name="field">The field to set the value to.</param>
        /// <param name="value">The new value to set the field to.</param>
        /// <param name="propertyName">The name of the property being set (auto-filled by caller).</param>
        /// <returns>True if the field was changed, otherwise false.</returns>
        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            // Compare values to avoid redundant UI updates
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        /// <summary>
        /// Invokes the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">The name of the property that changed.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
