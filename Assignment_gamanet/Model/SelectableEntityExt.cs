using System;

namespace Assignment_gamanet.Model
{
    public static class SelectableEntityExt
    {
        /// <summary>
        /// Copies the properties of the source SelectableEntity to the target SelectableEntity.
        /// </summary>
        /// <param name="target">The target SelectableEntity to copy values to.</param>
        /// <param name="source">The source SelectableEntity to copy values from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the source is null.</exception>
        public static void CopyFrom(this SelectableEntity target, SelectableEntity source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            target.Name = source.Name;
            target.IsSelected = source.IsSelected;
        }
    }
}
