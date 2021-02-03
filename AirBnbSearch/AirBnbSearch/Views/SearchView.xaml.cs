using AirBnbSearch.Models;
using AirBnbSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirBnbSearch.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        private SearchService _service;
        private List<Search> _places;
        private List<SearchGroup> _groupes;


        public SearchView()
        {
            InitializeComponent();
            _service = new SearchService();

            _places = (List<Search>)_service.GetSearches();
            PopulateItemSource(_places);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            _places = (List<Search>)_service.GetSearches(e.NewTextValue);
            PopulateItemSource(_places);
        }

        private void PopulateItemSource(List<Search> places)
        {
            _groupes = new List<SearchGroup>
            {
                new SearchGroup("Recent Searches", places)
            };
            ListPlaces.ItemsSource = _groupes;
        }

        private void List_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var searchSelected = e.SelectedItem as Search;
            DisplayAlert("Location", searchSelected.Location, "OK");
        }

        private void List_Refreshed(object sender, EventArgs e)
        {
            string filter = SearchBar.Text;
            List<Search> places = (List<Search>)_service.GetSearches(filter);
            PopulateItemSource(places);
            ListPlaces.EndRefresh();
        }

        private void DeletePlace_Clicked(object sender, EventArgs e)
        {
            var itemSelected = (sender as MenuItem).CommandParameter as Search;
             _groupes[0].Remove(itemSelected);
            _service.DeleteSearch(itemSelected.Id);

        }
    }
}