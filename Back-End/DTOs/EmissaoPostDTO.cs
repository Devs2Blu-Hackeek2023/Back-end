﻿using Back_End.Model;

namespace Back_End.DTOs
{
    public class EmissaoPostDTO
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public int VeiculoId { get; set; }
        public int RuaId { get; set; }

    }
}