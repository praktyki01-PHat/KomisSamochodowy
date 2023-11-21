namespace KomisSamochodowy.Models
{
    public class RodzajPaliwa
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Samochod> Samochods { get; } = new List<Samochod>();
    }
}
