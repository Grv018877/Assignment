using Assignment_gamanet.Common;

namespace Assignment_gamanet.Model
{
    /// <summary>
    /// Represents an entity that can be selected, with a name and selection state.
    /// </summary>
    public class SelectableEntity : PropertyChangedBase
    {
        // Private backing fields
        private string _name = string.Empty;
        private bool _isSelected = false;

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetField(ref _name, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the entity is selected.
        /// </summary>
        public bool IsSelected
        {
            get => _isSelected;
            set => SetField(ref _isSelected, value);
        }
    }
}
