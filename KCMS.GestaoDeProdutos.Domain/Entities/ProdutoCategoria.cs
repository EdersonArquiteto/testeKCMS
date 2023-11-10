using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCMS.GestaoDeProdutos.Domain.Entities
{
    public class ProdutoCategoria
    {
        public Guid ProdutoId { get; set; }
        public string NomeProduto { get; set; }
        public Guid CategoriaId { get; set; }
        public string NomeCategoria { get; set; }
    }
}
