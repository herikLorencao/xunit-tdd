using System.Linq;
using Alura.LeilaoOnline.Core;
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
            var leilao = new Leilao("Pç. Teste");
            var fulano = new Interessada("Fulano", leilao);
            var ciclano = new Interessada("Ciclano",leilao);
            
            leilao.IniciaPregao();

            for (int i = 0; i < valoresLances.Length; i++)
            {
                defineLancesIntercalados(leilao, fulano, ciclano, valoresLances[i], i);

                if (qtdLancesEsperados == leilao.Lances.Count())
                    leilao.TerminaPregao();
            }

            Assert.Equal(qtdLancesEsperados, leilao.Lances.Count());
        }

        private void defineLancesIntercalados(Leilao leilao, Interessada cliente1, Interessada cliente2, double valor, int indice)
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