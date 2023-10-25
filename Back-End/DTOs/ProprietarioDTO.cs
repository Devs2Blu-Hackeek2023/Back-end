namespace Back_End.DTOs
{
    public class ProprietarioDTO
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CNH { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
    }
}
