
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2022RR656_2022ZL650.Models
{
    public class libros
    {
        [Key]
        public int id { get; set; }

        [Required, MaxLength(255)]
        public string nombre { get; set; }

        [MaxLength(255)]
        public string descripcion { get; set; }

        [MaxLength(255)]
        public string url_imagen { get; set; }


        public int id_autor { get; set; }
   


        public int id_categoria { get; set; }
    

        [Required]
        public decimal precio { get; set; }

        [Required]
        public char estado { get; set; }

    }
}
