using System.ComponentModel.DataAnnotations.Schema;

namespace DiasFestivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        [Column("Id")]
        public int Id { get; set; }

        [Column("Tipo")]
        public int Tipos { get; set; }

    }
}
