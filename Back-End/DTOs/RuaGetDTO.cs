namespace Back_End.DTOs
{
    public class RuaGetDTO
    {
        public string cep { get; set; } = string.Empty;
        public string rua { get; set; } = string.Empty;
        public string bairro { get; set; } = string.Empty;
        public string cidade { get; set; } = string.Empty;
        public string uf { get; set; } = string.Empty;
        public double km { get; set; }
    }
}
