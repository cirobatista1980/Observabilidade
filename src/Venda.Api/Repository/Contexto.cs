using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;

namespace Venda.Api.Repository
{
    public class Contexto
    {
        private readonly IMongoDatabase _mongoDatabase;
        public Contexto(IConfiguration configuration)
        {
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            var client = new MongoClient(configuration.GetSection("ConnectionString").Value);
            _mongoDatabase = client.GetDatabase(configuration.GetSection("Database").Value);
        }
        public IMongoCollection<Models.Venda> Venda => _mongoDatabase.GetCollection<Models.Venda>(nameof(Venda));
    }
}