using System.Linq;
using Alura.LeilaoOnline.Core;
using Xunit;

namespace Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void RecebeVariosLances(double valorEsperado, double[] valorLances)
        {
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();
            LeilaoTestUtils.RealizaLancesIntercaladosComDoisInteressados(leilao, valorLances);
            leilao.TerminaPregao();
            
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }
        
        [Fact]
        public void NaoRecebeLances()
        {
            var leilao = new Leilao("Van Gogh");
            
            leilao.TerminaPregao();
            
            Assert.Null(leilao.Ganhador.Cliente);
        }

        [Theory]
        [InlineData(1, new double[] { 1000, 2000 })]
        public void NaoPermiteLancesConsectivosDoMesmoCliente(int qtdLancesEsperados, double[] valoresLances)
        {
            var leilao = new Leilao("Da Vinci");
            var fulano = new Interessada("Fulano", leilao);
            
            leilao.IniciaPregao();

            foreach (var valorLance in valoresLances)
            {
                leilao.RecebeLance(fulano, valorLance);
            }
            
            Assert.Equal(qtdLancesEsperados, leilao.Lances.Count());
        }
    }
}