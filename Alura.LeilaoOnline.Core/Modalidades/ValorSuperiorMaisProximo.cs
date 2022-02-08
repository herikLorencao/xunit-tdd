using System.Linq;

namespace Alura.LeilaoOnline.Core.Modalidades
{
    public class ValorSuperiorMaisProximo : IModalidade
    {
        public double ValorDestino { get; }

        public ValorSuperiorMaisProximo(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public Lance Avaliar(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(lance => lance.Valor > ValorDestino)
                .OrderBy(lance => lance.Valor)
                .FirstOrDefault();
        }
    }
}