using RestApi.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApi.Entities.Usuarios
{
    [Table("Usuario")]
    public class Usuario : EntitiesRestApi<int>
    {
        [StringLength(150)]
        public virtual string Nome { get; set; }

        [StringLength(150)]
        public virtual string SobreNome { get; set; }

        [StringLength(300)]
        public virtual string NomeCompleto => Nome + " " + SobreNome;

        public virtual int ProfissaoId { get; set; }

        [StringLength(200)]
        public virtual string Email { get; set; }

        [StringLength(20)]
        public virtual string CpfRg { get; set; }

        [StringLength(15)]
        public virtual string Telefone { get; set; }
    }
}
