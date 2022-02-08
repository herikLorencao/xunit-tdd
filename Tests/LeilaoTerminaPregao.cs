using System;
using System.Linq;
using Alura.LeilaoOnline.Core;
using Alura.LeilaoOnline.Core.Modalidades;
using Xunit;

namespace Tests
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(3, new double[] {100, 200, 300, 900})]
        [InlineData(4, new double[] {100, 200, 300, 400, 600})]
        public void DeveriaNaoAdicionarLancesAposTermino(int qtdLancesEsperados, double[] valoresLances)
        {
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Pç. Teste", modalidade);
            var fulano = new Interessada("Fulano", leilao);
            var ciclano = new Interessada("Ciclano", leilao);

            leilao.IniciaPregao();

            for (int i = 1; i < valoresLances.Length; i++)
            {
                DefineLancesIntercalados(leilao, fulano, ciclano, valoresLances[i], i);

                if (qtdLancesEsperados == i)
                    leilao.TerminaPregao();
            }

            Assert.Equal(qtdLancesEsperados, leilao.Lances.Count());
        }

        [Fact]
        public void LancaInvalidOperationExceptionQuandoPregaoNaoIniciado()
        {
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Teste", modalidade);
            var exception = Assert.Throws<InvalidOperationException>(() => leilao.TerminaPregao());
            Assert.Equal("Para terminar o pregão é necessário iniciá-lo", exception.Message);
        }

        [Theory]
        [InlineData(1200, 1250, new double[] {700, 800, 1250, 1400})]
        public void GanhadorPossuiValorSuperiorMaisProximoDoValorDestino(double valorDestino, double valorEsperado,
            double[] ofertas)
        {
            var modalidade = new ValorSuperiorMaisProximo(valorDestino);
            var leilao = new Leilao("Teste", modalidade);

            leilao.IniciaPregao();
            LeilaoTestUtils.RealizaLancesIntercaladosComDoisInteressados(leilao, ofertas);
            leilao.TerminaPregao();

            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }

        private void DefineLancesIntercalados(Leilao leilao, Interessada cliente1, Interessada cliente2, double valor,
            int indice)
        {
            if (indice % 2 == 0)
            {
                leilao.RecebeLance(cliente1, valor);
                return;
            }

            leilao.RecebeLance(cliente2, valor);
        }
    }
}