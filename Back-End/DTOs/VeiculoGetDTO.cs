﻿using Back_End.Model;

namespace Back_End.DTOs
{
    public class VeiculoGetDTO
    {
        public int Id { get; set; }
        public string Placa { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Motor { get; set; } = string.Empty;
        public string Combustivel { get; set; } = string.Empty;
        public double KmL { get; set; }
        public int ProprietarioId { get; set; }
        public string Modificacoes { get; set; } = string.Empty;
    }
}
