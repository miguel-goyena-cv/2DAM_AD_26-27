namespace GrsEFDataBaseFirst.Dtos
{
    public class GrConEtapasDTO
    {
        public string Id { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public List<EtapaDto> Etapas { get; set; } = new();

    }

}
