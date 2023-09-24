using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class SupplierModel
    {
        public int Supplierid { get; set; }

        [Required]
        public string Companyname { get; set; } = null!;

        [Required]
        public string Contactname { get; set; } = null!;

        public string Contacttitle { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

        [Required]
        public string? Region { get; set; }

        [Required]
        public string? Postalcode { get; set; }

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        public string Phone { get; set; } = null!;

        public string? Fax { get; set; }
    }
}
