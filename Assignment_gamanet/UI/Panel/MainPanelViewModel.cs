using Assignment_gamanet.Common;
using Assignment_gamanet.Model;
using Assignment_gamanet.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Assignment_gamanet.UI.Panel
{
    /// <summary>
    /// ViewModel for the main panel.
    /// </summary>
    public class MainPanelViewModel : PropertyChangedBase
    {
        private readonly _MainPanelContext _mpContext;

        private SortByOptions _selectedSortOption;

        /// <summary>
        /// Gets the collection view for persons, enabling sorting and filtering.
        /// </summary>
        public ICollectionView PersonsView { get; private set; }

        /// <summary>
        /// Gets or sets the selected sorting option for the persons list.
        /// </summary>
        public SortByOptions SelectedSortOption
        {
            get
            {
                return _selectedSortOption;
            }

            set
            {
                if (SetField(ref _selectedSortOption, value))
                {
                    SortList();
                }
            }
        }

        private List<SelectableEntity> _countries;

        /// <summary>
        /// Gets or sets the list of selectable countries for filtering the persons list.
        /// </summary>
        public List<SelectableEntity> Countries
        {
            get
            {
                return _countries;
            }

            set
            {
                SetField(ref _countries, value);
            }
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        /// <param name="context">mainPanelContext</param>
        public MainPanelViewModel(_MainPanelContext context)
        {
            _mpContext = context;
            var service = new CsvDataLoaderService(_mpContext);
            var persons = service.LoadDataFromCsv(@"Resource\PersonsDemo.csv").ToList();

            // Load persons into the repository
            _mpContext.PersonRepo.LoadPersons(persons);

            // Initialize the list of selectable countries for filtering
            Countries = _mpContext.PersonRepo.Persons
                                    .Select(person => person.Country)
                                    .Distinct()
                                    .Select(country => new SelectableEntity() { Name = country })
                                    .OrderBy(x => x.Name)
                                    .ToList();

            // Subscribe to the IsSelected property of each country entity to trigger filter updates
            Countries.SubscribeToProperty(nameof(SelectableEntity.IsSelected), entity => {
                ApplyCountryFilter();
            });

            // Initialize the persons view for sorting and filtering
            PersonsView = CollectionViewSource.GetDefaultView(_mpContext.PersonRepo.Persons);
        }

        /// <summary>
        /// Sorts the persons list based on the selected sort option.
        /// </summary>
        private void SortList()
        {
            PersonsView.SortDescriptions.Clear();
            PersonsView.SortDescriptions.Add(new SortDescription(SelectedSortOption.ToString(), ListSortDirection.Ascending));
        }

        /// <summary>
        /// Applies a filter to the persons list based on the selected countries.
        /// </summary>
        private void ApplyCountryFilter()
        {
            var selectedCountries = Countries.Where(c => c.IsSelected).Select(c => c.Name).ToList();

            // Apply filter on PersonsView based on selected countries
            if (selectedCountries.Any())
            {
                PersonsView.Filter = item => {
                    var person = item as PersonEntity;
                    return person != null && selectedCountries.Contains(person.Country);
                };
            }
            else
            {
                PersonsView.Filter = null; // No filter if no country is selected
            }
        }
    }
}
