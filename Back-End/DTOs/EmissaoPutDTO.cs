namespace Back_End.DTOs
{
	public class EmissaoPutDTO
	{
		public int Id { get; set; }
		public DateTime? DataFim { get; set; }
		public double? CO2 { get; set; }

		public EmissaoPutDTO(int id, DateTime? dataFim, double? cO2)
		{
			Id = id;
			DataFim = dataFim;
			CO2 = cO2;
		}
	}
}
