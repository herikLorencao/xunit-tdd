using Alura.LeilaoOnline.Core;
using Xunit;

namespace Tests
{
    public class LeilaoTest
    {
        [Fact]
        public void LeilaoComVariosInteressados()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            leilao.RecebeLance(fulano, 700);
            leilao.RecebeLance(maria, 800);
            leilao.RecebeLance(fulano, 1000);
            leilao.RecebeLance(maria, 990);

            leilao.TerminaPregao();
            
            Assert.Equal(1000, leilao.Ganhador.Valor);
        }
        
        [Fact]
        public void LeilaoComUmInteressado()
        {
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            
            leilao.RecebeLance(fulano, 700);
            
            leilao.TerminaPregao();
            
            Assert.Equal(700, leilao.Ganhador.Valor);
        }
    }
}