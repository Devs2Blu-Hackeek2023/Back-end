namespace Back_End.DTOs
{
    public class VeiculoPutDTO
    {
        public string Placa { get; set; } = string.Empty;
        public string Combustivel { get; set; } = string.Empty;
        public double KmL { get; set; }
        public int ProprietarioId { get; set; }
        public string Modificacoes { get; set; } = string.Empty;
    }
}
