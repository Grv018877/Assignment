using System;

namespace Assignment_gamanet.Model
{
    /// <summary>
    /// Represents the context for the main panel, providing access to the person repository.
    /// </summary>
    public class _MainPanelContext
    {
        /// <summary>
        /// Gets the repository for managing person data.
        /// </summary>
        public PersonRepository PersonRepo { get; } = new PersonRepository();
    }
}
