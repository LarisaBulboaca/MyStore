using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ShipperModel
    {
        public int Shipperid { get; set; }

        [Required]
        public string Companyname { get; set; } = null!;

        [Required]
        [MinLength(6, ErrorMessage = "Trebuie sa fie un numar de telefon valid.")]
        [MaxLength(15)]
        public string Phone { get; set; } = null!;
    }
}
