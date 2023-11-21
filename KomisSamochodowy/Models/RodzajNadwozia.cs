namespace KomisSamochodowy.Models
{
    public class RodzajNadwozia
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Samochod> Samochods { get; } = new List<Samochod>();
    }
}
