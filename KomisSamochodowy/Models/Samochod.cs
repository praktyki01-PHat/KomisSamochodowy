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
        public int MarkaId { get; set; }
        public Marka? Marka { get; set; } = null!;
        public int ModelId { get; set; }
        public Model? Model { get; set; } = null!;
        public int RodzajNadwoziaId { get; set; }
        public RodzajNadwozia? RodzajNadwozia { get; set; } = null!;
        public int RodzajPaliwaId { get; set; }
        public RodzajPaliwa? RodzajPaliwa { get; set; } = null!;
    }
}
