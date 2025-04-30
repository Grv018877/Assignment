using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Assignment_gamanet.Model
{
    public class PersonRepository
    {
        // Private backing field for the Persons collection
        private ObservableCollection<PersonEntity> _persons = new ObservableCollection<PersonEntity>();

        /// <summary>
        /// Gets the collection of persons.
        /// </summary>
        public ObservableCollection<PersonEntity> Persons => _persons;

        /// <summary>
        /// Loads the persons into the repository.
        /// </summary>
        /// <param name="persons">The collection of persons to load.</param>
        public void LoadPersons(IEnumerable<PersonEntity> persons)
        {
            _persons.Clear();
            foreach (var person in persons)
            {
                _persons.Add(person);
            }
        }
    }

}
