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
        private IModalidade _modalidade;

        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; set; }

        public Leilao(string peca, IModalidade modalidade)
        {
            Peca = peca;
            _lances = new List<Lance>();
            _situacao = Situacao.Iniciado;
            _modalidade = modalidade;
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

            _modalidade.Avaliar(this);
            _situacao = Situacao.Finalizado;
        }

        private bool ehLanceValido(Interessada cliente)
        {
            return cliente != _ultimoCliente && _situacao == Situacao.Andamento;
        }
    }
}