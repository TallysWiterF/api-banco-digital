﻿using Dominio.Entidades;
using Dominio.Interfaces.Repositorio;
using Dominio.Interfaces.Repositorio.Bases;
using Dominio.Interfaces.Service;
using Service.Services.Bases;
using Service.Services.ServicesBase;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Services
{
    public class TransferenciaService : BaseService<Transferencia>, ITransferenciaService
    {
        private readonly IContaRepositorio _contaRepositorio;
        private readonly IMovimentacaoRepositorio _movimentacao;
        public TransferenciaService(ITransferenciaRepositorio repositorio, InjectorServiceBase injector, 
                                    IContaRepositorio contaRepositorio, IMovimentacaoRepositorio movimentacao)
            : base(repositorio, injector)
        {
            _contaRepositorio = contaRepositorio;
            _movimentacao = movimentacao;
        }

        public new async Task<Transferencia> AddAsync(Transferencia entidade)
        {
            var contas = (await _contaRepositorio.GetAsync(x => x.Id == entidade.Movimentacao.IdConta || x.Id == entidade.IdContaDestino)).ToList();
            entidade.ContaDestino = contas?.FirstOrDefault(x => x.Id == entidade.IdContaDestino);
            entidade.Movimentacao.Conta = contas?.FirstOrDefault(x => x.Id == entidade.Movimentacao.IdConta);
            if (!base.ValidarEntidade(entidade)) return null;
            entidade.Transferir();
            await _contaRepositorio.UpdatePropsAsync(entidade.ContaDestino, nameof(Conta.Saldo));
            await _contaRepositorio.UpdatePropsAsync(entidade.Movimentacao.Conta, nameof(Conta.Saldo));
            await _movimentacao.AddAsync(entidade.ContaDestino.Movimentacoes.First());
            await base.AddAsync(entidade);
            await base.CommitAsync();
            return entidade;
        }
    }
}
