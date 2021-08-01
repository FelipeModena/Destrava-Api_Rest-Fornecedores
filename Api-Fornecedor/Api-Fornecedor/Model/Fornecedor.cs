using Api_Fornecedor.Model.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Fornecedor.Model
{
    [Table("fornecedor")]
    public class Fornecedor : BaseFornecedor
    {
        [Column("empresa")]
        public virtual Empresas Empresas { get; set; }

    }
}
