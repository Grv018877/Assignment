using System;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace Assignment_gamanet.UI.Behaviors
{
    /// <summary>
    /// A behavior for automatically resetting a ComboBox selection and reopening the dropdown on selection change.
    /// </summary>
    public class ComboBoxAutoResetBehavior : Behavior<ComboBox>
    {
        /// <summary>
        /// Attaches the behavior to the ComboBox and subscribes to the SelectionChanged event.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        /// <summary>
        /// Detaches the behavior from the ComboBox and unsubscribes from the SelectionChanged event.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }

        /// <summary>
        /// Handles the SelectionChanged event to reset the ComboBox's selected value and reopen the dropdown.
        /// </summary>
        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AssociatedObject.SelectedValue = null;
            AssociatedObject.IsDropDownOpen = true;
        }
    }
}
