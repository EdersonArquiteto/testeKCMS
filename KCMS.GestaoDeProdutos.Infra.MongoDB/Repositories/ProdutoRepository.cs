using KCMS.GestaoDeProdutos.Domain.Core;
using KCMS.GestaoDeProdutos.Domain.Entities;
using KCMS.GestaoDeProdutos.Domain.Interfaces.Repositories;
using KCMS.GestaoDeProdutos.Infra.MongoDB.Contexts;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KCMS.GestaoDeProdutos.Infra.MongoDB.Repositories
{
    public class ProdutoRepository : IBaseRepository<Produto, Guid>, IProdutoRepository
    {
        private readonly MongoDBContext _context;

        public ProdutoRepository(MongoDBContext context)
        {
            _context = context;
        }

        public void Create(Produto entity)
        {
            _context.Produtos.InsertOne(entity);
        }
        public void Update(Produto entity)
        {
            var filter = Builders<Produto>.Filter.Eq(e => e.Id, entity.Id);
            _context.Produtos.ReplaceOne(filter, entity);
        }
        public void Delete(Produto entity)
        {
            var filter = Builders<Produto>.Filter.Eq(e => e.Id, entity.Id);
            _context.Produtos.DeleteOne(filter);
        }

        public List<Produto> GetAll()
        {
            var produtos = _context.Produtos.AsQueryable().Where(p => true);
            var query = from p in produtos
                        join c in _context.Categorias.AsQueryable() on p.Categoria.Id equals c.Id into ProdutoCategoria
                        select new Produto()
                        {
                            Id = p.Id,
                            NomeProduto = p.NomeProduto,
                            Descricao=p.Descricao,
                            Valor= p.Valor,
                            CategoriaId = p.CategoriaId,
                            Categoria = p.Categoria
                        };
            var produtoCompleto = query.ToList();
            return produtoCompleto;

            

        }

        public Produto GetById(Guid id)
        {
            var filter = Builders<Produto>.Filter.Eq(e => e.Id, id);
            return _context.Produtos.Find(filter).FirstOrDefault();

        }
        public List<Produto> ListProdutosByCategoriaId(Guid id)
        {
            var filter = Builders<Produto>.Filter.Eq(e=>e.CategoriaId,id);
            return _context.Produtos.Find(filter).ToList();
            
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

       
    }
}
