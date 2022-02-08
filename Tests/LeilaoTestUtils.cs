using Alura.LeilaoOnline.Core;

namespace Tests
{
    public class LeilaoTestUtils
    {
        public static void RealizaLancesIntercaladosComDoisInteressados(Leilao leilao, double[] valores)
        {
            Interessada fulano = new Interessada("Fulano", leilao);
            Interessada ciclano = new Interessada("Ciclano", leilao);

            for (int i = 0; i < valores.Length; i++)
            {
                RealizaLance(leilao, fulano, ciclano, valores[i], i);
            }
        }

        private static void RealizaLance(Leilao leilao, Interessada cliente1, Interessada cliente2, double valor,
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