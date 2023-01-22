using RestApi.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Entities.Profissoes
{
    [Table("Profissao")]
    public class Profissao : EntitiesRestApi<int>
    {
        public virtual string Descricao { get; set; }
        public virtual decimal Salario { get; set; }
    }
}
