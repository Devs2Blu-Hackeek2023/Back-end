namespace Back_End.Model
{
    public class EmissaoModel
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public double? CO2 { get; set; }
        public int VeiculoId { get; set; }
        public VeiculoModel Veiculo { get; set; }
        public int RuaId { get; set; }

        public RuaModel Rua { get; set; }
    }
}
