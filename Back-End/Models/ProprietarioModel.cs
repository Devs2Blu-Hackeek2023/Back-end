namespace Back_End.Model
{
    public class ProprietarioModel
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string CNH { get; set; } = string.Empty;
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }



    }
}
