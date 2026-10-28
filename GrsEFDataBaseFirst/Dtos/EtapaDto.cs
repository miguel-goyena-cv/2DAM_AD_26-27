namespace GrsEFDataBaseFirst.Dtos
{
    public class EtapaDto
    {
        public string IdGr { get; set; } = null!;
        public int NumEtapa { get; set; }
        public string? NombreZona { get; set; }
        public int? Km { get; set; }
        public int? Desnivel { get; set; }
    }

}
