﻿using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core.DTO.ContaDTOs
{
    public class ContaUpdateRequest
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
    
    public class ContaUpdateResponse
    {
        public Guid Id { get; set; }
        public Guid IdCliente { get; set; }
        public string Numero { get; set; }
        public EnumTipoConta Tipo { get; set; }
        public decimal Saldo { get; set; }
    }
}
