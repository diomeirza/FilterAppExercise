using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AirBnbSearch.Models
{
    class SearchGroup : ObservableCollection<Search>
    {
        public string Title { get; set; }
        public SearchGroup(string title,List<Search> searches = null) : base(searches)
        {
            Title = title;
        }
        
    }
}
