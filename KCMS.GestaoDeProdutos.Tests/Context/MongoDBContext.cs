using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Tests.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KCMS.GestaoDeProdutos.Tests.Context
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings? _mongoDBSettings;
        private IMongoDatabase _mongoDatabase;
        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings.Value;

            #region Conectando no banco de dados

            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Host));

            if (_mongoDBSettings.IsSSL)
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                };

            _mongoDatabase = new MongoClient(client).GetDatabase(_mongoDBSettings.Name);

            #endregion
        }
        public IMongoCollection<Categoria> Categorias => _mongoDatabase.GetCollection<Categoria>("Categorias");
        public IMongoCollection<Produto> Produtos => _mongoDatabase.GetCollection<Produto>("Produtos");
    }
}
