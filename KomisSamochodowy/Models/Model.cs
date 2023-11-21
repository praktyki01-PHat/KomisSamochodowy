namespace KomisSamochodowy.Models
{
    public class Model
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Samochod> Samochods { get; } = new List<Samochod>();
    }
}
