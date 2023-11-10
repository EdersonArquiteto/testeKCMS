using KCMS.GestaoDeProdutos.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace KCMS.GestaoDeProdutos.Infra.MongoDB.Mapping
{
    public class ProdutoMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Produto>(map =>
            {
                map.AutoMap();
                map.MapIdMember(x=> x.Id);
                map.MapIdMember(x => x.Categoria).SetIsRequired(true);
            });
        }
    }
}
