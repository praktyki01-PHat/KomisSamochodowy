namespace KomisSamochodowy.Models
{
    public class Samochod
    {
        public int Id { get; set; }
        public string Kolor { get; set; }
        public float PojemnoscSilnika { get; set; }
        public float Przebieg { get; set; }
        public string NumerVIN { get; set; }
        public float Cena { get; set; }
    }
}
