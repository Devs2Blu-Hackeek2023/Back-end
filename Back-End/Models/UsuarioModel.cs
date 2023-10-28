namespace Back_End.Model
{
	public class UsuarioModel
	{
		public int Id { get; set; }
		public string Nome { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string PasswordHash { get; set; } = string.Empty;
		public string Cargo { get; set; } = string.Empty;
	}
}