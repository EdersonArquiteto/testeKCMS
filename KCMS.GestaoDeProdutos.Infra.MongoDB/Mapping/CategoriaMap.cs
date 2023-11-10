using KCMS.GestaoDeProdutos.Domain.Entities;
using MongoDB.Bson.Serialization;

namespace KCMS.GestaoDeProdutos.Infra.MongoDB.Mapping
{
    public class CategoriaMap
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<Categoria>(map =>
            {
                map.AutoMap();
                map.MapIdMember(x=>x.Id);
                map.MapExtraElementsMember(c => c.Produtos);
                
                
            });
        }
    }
}
