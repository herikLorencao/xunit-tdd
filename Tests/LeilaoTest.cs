using Alura.LeilaoOnline.Core;
using Xunit;

namespace Tests
{
    public class LeilaoTest
    {
        [Theory]
        [InlineData(1200, new double[] { 800, 900, 1000, 1200 })]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(800, new double[] { 800 })]
        public void LeilaoComVariosLances(double valorEsperado, double[] valorLances)
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);

            foreach (var valorLance in valorLances)
            {
                leilao.RecebeLance(fulano, valorLance);
            }

            leilao.TerminaPregao();
            
            Assert.Equal(valorEsperado, leilao.Ganhador.Valor);
        }
        
        [Fact]
        public void LeilaoSemLances()
        {
            var leilao = new Leilao("Van Gogh");
            
            leilao.TerminaPregao();
            
            Assert.Null(leilao.Ganhador.Cliente);
        }
    }
}