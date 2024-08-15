using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sQpets_Backend.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        [Key]
        public Guid iduser {get; set;}
        public required string nome {get; set;}
        public required string email {get; set;}
        public required string senha{get; set;}
    }
}