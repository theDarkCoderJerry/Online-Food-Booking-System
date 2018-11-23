using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodBooking.DataAccess.ElasticSearch
{
    public class ElasticSearchConfig
    {
        ElasticClient client = null;

        public ElasticSearchConfig()
        {
            var settings = new ConnectionSettings(new Uri("http://localhost:9200").DefaultIndex("orders");
));
        }
    }
}
