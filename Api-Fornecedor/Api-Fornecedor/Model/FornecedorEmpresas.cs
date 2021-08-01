using Api_Fornecedor.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Model
{
    [Table("fornecedor_empresas")]
    public class FornecedorEmpresas:BaseEntity
    {
        public long FornecedorId { get; set; }
        public long EmpresaId { get; set; }
        [Column("empresas")]
        public Empresas Empresas { get; set; }
        [Column("fornecedor")]
        public Fornecedor Fornecedor{ get; set; }
    }
}
