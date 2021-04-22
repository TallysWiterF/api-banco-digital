﻿using Dominio.Entidades.Bases;
using Dominio.ValuesType;
using System;
using Crosscuting.Extensions;
using System.Collections.Generic;
using Dominio.Validators.EntidadesValidator;

namespace Dominio.Entidades
{
    public class Cartao : Base
    {
        public Guid IdCliente { get; set; }
        public string Numero { get; private set; }
        public DateTime Vencimento { get; private set; }
        public EnumTipoCartao Tipo { get; set; }
        public Cliente Cliente { get; set; }
        public Cartao()
        {
            Numero = GerarNumero();
            Vencimento = DateTime.Now.AddYears(4);
        }
        public bool IsVencido() => this.Vencimento < DateTime.Now;
        private string GerarNumero() =>  
                        $"{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $" {Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}" +
                        $" {Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}{Numero.RandonsNumbers()}";

        protected override (bool IsValido, IReadOnlyList<string> Erros) Validar() =>
            base.Validar(new CartaoValidator(), this);
    }
}
