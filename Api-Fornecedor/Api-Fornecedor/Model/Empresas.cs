using Api_Fornecedor.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Model
{
    [Table("Empresas")]
    public class Empresas:BaseEntity
    {
        [Column("empresas_cnpj")]
        public string Cnpj { get; set; }
        public virtual List<Fornecedor> Fornecedores { get; set; }
    }
}
