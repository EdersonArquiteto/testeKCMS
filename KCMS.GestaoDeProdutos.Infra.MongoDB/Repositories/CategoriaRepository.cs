using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using KCMS.GestaoDeProdutos.Infra.MongoDB.Contexts;
using MongoDB.Driver;

namespace KCMS.GestaoDeProdutos.Infra.MongoDB.Repositories
{
    public class CategoriaRepository : IBaseRepository<Categoria, Guid>, ICategoriaRepository
    {
        private readonly MongoDBContext _context;

        public CategoriaRepository(MongoDBContext context)
        {
            _context = context;
        }

        public void Create(Categoria entity)
        {
            _context.Categorias.InsertOne(entity);
        }
        public void Update(Categoria entity)
        {
            var filter = Builders<Categoria>.Filter.Eq(e=>e.Id,entity.Id); 
            _context.Categorias.ReplaceOne(filter, entity);
        }

        public void Delete(Categoria entity)
        {
            var filter = Builders<Categoria>.Filter.Eq(e => e.Id, entity.Id);
            _context.Categorias.DeleteOne(filter);
        }

        public List<Categoria> GetAll()
        {
            var filter = Builders<Categoria>.Filter.Where(e => true);
            return _context.Categorias.Find(filter).ToList();
        }

        public Categoria GetById(Guid id)
        {
            var filter = Builders<Categoria>.Filter.Eq(e => e.Id, id);
            return _context.Categorias.Find(filter).FirstOrDefault();
        }

        
    }
}
