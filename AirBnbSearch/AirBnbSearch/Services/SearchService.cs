using AirBnbSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AirBnbSearch.Services
{
    class SearchService
    {
        private List<Search> _searches;
        public SearchService()
        {
            _searches = new List<Search>
            {
                new Search { Id = 1,Location = "Jakarta", CheckIn = DateTime.Today, CheckOut = DateTime.Today},
                new Search { Id = 2,Location = "Bali", CheckIn = DateTime.Today, CheckOut = DateTime.Today},
                new Search { Id = 3,Location = "Yogyakarta", CheckIn = DateTime.Today, CheckOut = DateTime.Today},
                new Search { Id = 4,Location = "Surabaya", CheckIn = DateTime.Today, CheckOut = DateTime.Today},
                new Search { Id = 5,Location = "Medan", CheckIn = DateTime.Today, CheckOut = DateTime.Today}
            };
        }
        public IEnumerable<Search> GetSearches(string filter = null)
        {  
            if(filter != null)
            {
                return _searches.Where(x => x.Location.Contains(filter)).ToList();
            }
            return _searches;
        }

        public void DeleteSearch(int searchId)
        {
            var deletedPlace = _searches.Find(x => x.Id == searchId);
            _searches.Remove(deletedPlace);
        }
    }
}
