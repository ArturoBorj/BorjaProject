using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BorjaProject.iws.api.Models.Dto
{
    public class BorjaP_Dto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        public int Edad { get; set; }
        public int Peso { get; set; }
    }
}
