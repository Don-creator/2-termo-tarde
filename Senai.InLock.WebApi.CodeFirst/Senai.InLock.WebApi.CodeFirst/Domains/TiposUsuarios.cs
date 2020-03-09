using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.CodeFirst.Domains
{
    //Define o nome da tabela que será criada no banco de dados
    [Table("TiposUsuario")]
    public class TiposUsuarios
    {
        //Define que será uma chave primaria
        [Key]
        //Define o auto-incremento
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTipoUsuario { get; set; }
        
        // Define o tipo da coluna do banco de dados
        [Column(TypeName = "VARCHAR (255)")]
        //Define que o campo é obrigatorio
        [Required(ErrorMessage = "O titulo do tipo usuario é obrigatorio")]
        public string  Titulo { get; set; }
    }
}
