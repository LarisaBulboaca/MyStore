using MyStore.Domain;

namespace MyStore.Models
{
    public class ScoreModel
    {
        public string Testid { get; set; } = null!;

        public string Studentid { get; set; } = null!;

        public byte Score1 { get; set; }

        public virtual Test Test { get; set; } = null!;
    }
}
