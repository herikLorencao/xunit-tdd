using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class Leilao
    {
        private IList<Lance> _lances;
        private Situacao _situacao;
        private Interessada _ultimoCliente;
        private double _valorDestino;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; set; }

        public Leilao(string peca, double valorDestino = 0)
        {
            Peca = peca;
            _valorDestino = valorDestino;
            _lances = new List<Lance>();
            _situacao = Situacao.Iniciado;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (!ehLanceValido(cliente)) return;

            _lances.Add(new Lance(cliente, valor));
            _ultimoCliente = cliente;
        }

        public void IniciaPregao()
        {
            _situacao = Situacao.Andamento;
        }

        public void TerminaPregao()
        {
            if (_situacao != Situacao.Andamento)
                throw new InvalidOperationException("Para terminar o pregão é necessário iniciá-lo");

            if (_valorDestino > 0)
            {
                Ganhador = Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .Where(lance => lance.Valor > _valorDestino)
                    .OrderBy(lance => lance.Valor)
                    .FirstOrDefault();
            }
            else
            {
                Ganhador = Lances
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(lance => lance.Valor)
                    .LastOrDefault();
            }

            _situacao = Situacao.Finalizado;
        }

        private bool ehLanceValido(Interessada cliente)
        {
            return cliente != _ultimoCliente && _situacao == Situacao.Andamento;
        }
    }
}