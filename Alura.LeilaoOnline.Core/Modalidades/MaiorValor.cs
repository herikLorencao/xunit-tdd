using System.Linq;

namespace Alura.LeilaoOnline.Core.Modalidades
{
    public class MaiorValor : IModalidade
    {
        public Lance Avaliar(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(lance => lance.Valor)
                .LastOrDefault();
        }
    }
}