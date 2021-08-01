using Api_Fornecedor.Model.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api_Fornecedor.Model
{
    [Table("log_desenvolvedor")]
    public class LogDesenvolvedor:BaseEntity
    {
        [Column("date_time")]
        public DateTime DateTime { get; set; }
        [Column("error")]
        public string Error { get; set; }
    }
}
