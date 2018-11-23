using Nest;
using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticSearch.WebApi.Model
{
    public class ElasticSearchModel : IElasticSearchModel
    {
        ElasticClient client = null;
        public ElasticSearchModel()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200")).DefaultIndex("onlinefoodmenu");
            client = new ElasticClient(settings);
        }
        public void Post(FoodMenuApplicationModel foodMenuApplicationModel)
        {
            var request = new IndexRequest<FoodMenuApplicationModel>(foodMenuApplicationModel) { };
            var response = client.Index<FoodMenuApplicationModel>(request);
           
        }
        public List<FoodMenuApplicationModel> GetSearchResult(string stringToSearch)
        {
            var searchResults = client.Search<FoodMenuApplicationModel>(p => p
            .From(0)
            .Size(10)
            .Query(q => q
            .Match(m => m.Field(f => f.FoodItem)
            .Query(stringToSearch)
            )
           )
         );
            return searchResults.Documents.ToList();
        }
    }
}
