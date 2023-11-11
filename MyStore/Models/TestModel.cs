using MyStore.Domain;

namespace MyStore.Models
{
    public class TestModel
    {
        public string Testid { get; set; } = null!;

        public virtual ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
