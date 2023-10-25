using Back_End.Model;

namespace Back_End.DTOs
{
    public class EmissaoPutDTO
    {
        public int Id { get; set; }
        public DateTime? DataFim { get; set; }
        public double? CO2 { get; set; }
    }
}
