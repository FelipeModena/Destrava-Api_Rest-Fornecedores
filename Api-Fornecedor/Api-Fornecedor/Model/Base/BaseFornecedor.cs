using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Model.Base
{
    public class BaseFornecedor:BaseEntity
    {
        [Column("cnpj")]
        public string Cnpj { get; set; }
        [Column("razao_social")]
        public string RazaoSocial { get; set; }
        [Column("nome_fantasia")]
        public string NomeFantasia { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }
        [Column("status")]
        public bool Status { get; set; }
    }
}
