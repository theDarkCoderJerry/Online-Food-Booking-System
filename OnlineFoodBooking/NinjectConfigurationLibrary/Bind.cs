using ElasticSearch.WebApi.Model;
using Ninject;
using OnlineFoodBooking.Application.Abstraction;
using OnlineFoodBooking.Application_Layer;
using OnlineFoodBooking.DataAccess.Abstraction;
using OnlineFoodBooking.DataAcess;
using OnlineFoodBooking.DataAcess.Mongo;
using OnlineFoodBooking.Domain_Layer;
using OnlineFoodBooking.Domain_Layer.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjectConfigurationLibrary
{
    public static class Bind
    {
        public static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDataAccessRespository>().To<DataAccessRepository>();
            kernel.Bind<IFoodMenuDomainMethods>().To<FoodMenuDomainMethods>();
            kernel.Bind<IFoodMenuApplicationMethods>().To<FoodMenuApplicationMethods>();
            kernel.Bind<IMongoDataRepository>().To<MongoDataRepository>();
             kernel.Bind<IElasticSearchModel>().To<ElasticSearchModel>();
            kernel.Bind<IOrderApplicationMethods>().To<OrderApplicationMethods>();
            kernel.Bind<IOrderDomainMethods>().To<OrderDomainMethods>();
            kernel.Bind<IOrderRepository>().To <OrderSqlRepostiory>();
        }
    }
}
